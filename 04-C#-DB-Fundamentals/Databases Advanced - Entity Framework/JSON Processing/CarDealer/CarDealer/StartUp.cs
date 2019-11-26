using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));

            var context = new CarDealerContext();

            var suppliersInput = File.ReadAllText(@"../../../Datasets/suppliers.json");
            var partsInput = File.ReadAllText(@"../../../Datasets/parts.json");
            var carInput = File.ReadAllText(@"../../../Datasets/cars.json");
            var customersInput = File.ReadAllText(@"../../../Datasets/customers.json");
            var salesInput = File.ReadAllText(@"../../../Datasets/sales.json");

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var existingSuppliers = context.Suppliers.Select(s => s.Id).ToArray();

            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => existingSuppliers.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<CarDto[]>(inputJson);
            var mappedCars = new List<Car>();

            foreach (var car in cars)
            {
                Car vehicle = Mapper.Map<CarDto, Car>(car);
                mappedCars.Add(vehicle);
            }

            context.Cars.AddRange(mappedCars);
            context.SaveChanges();

            mappedCars = context.Cars.ToList();

            var parts = new List<PartCar>();

            foreach (var car in mappedCars)
            {
                var partIds = cars.FirstOrDefault(x => x.Make == car.Make
                && x.Model == car.Model && x.TravelledDistance == car.TravelledDistance)
                .PartsId
                .Distinct()
                .ToList();

                if (partIds == null)
                    continue;

                partIds.ForEach(id =>
                {
                    var currentPair = new PartCar()
                    {
                        Car = car,
                        PartId = id
                    };

                    parts.Add(currentPair);
                }
                );
            }

            context.PartCars.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Include(c => c.PartCars)
                .ThenInclude(c => c.Part)
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },

                    parts = c.PartCars
                    .Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:f2}"
                    })
                    .ToArray()
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(s => s.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .Where(c => c.Sales.Count >= 1)
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales.Sum(p => p.Car.PartCars.Sum(s => s.Part.Price))
                })
                .ToArray()
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToArray();


            var json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = $"{x.Discount:F2}",
                    price = $"{x.Car.PartCars.Sum(y => y.Part.Price):F2}",
                    priceWithDiscount = $"{x.Car.PartCars.Sum(y => y.Part.Price) - (x.Car.PartCars.Sum(y => y.Part.Price) * (x.Discount / 100)):F2}",
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(sales, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            });

            return json;
        }
    }   
}