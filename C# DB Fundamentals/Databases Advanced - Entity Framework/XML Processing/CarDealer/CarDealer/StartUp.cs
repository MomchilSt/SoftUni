using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            var salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            using (CarDealerContext context = new CarDealerContext())
            {
                var usersResult = GetSalesWithAppliedDiscount(context);
                Console.WriteLine(usersResult);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]),
                new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]),
                new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            var suppliers = context.Suppliers.Select(x => x.Id).ToArray();

            foreach (var partDto in partsDto)
            {
                if (!suppliers.Contains(partDto.SupplierId))
                {
                    continue;
                }

                var part = new Part
                {
                    Name = partDto.Name,
                    Price = partDto.Price,
                    Quantity = partDto.Quantity,
                    SupplierId = partDto.SupplierId
                };

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsParsed = XDocument.Parse(inputXml)
                .Root
                .Elements()
                .ToList();

            var cars = new List<Car>();

            var existingPartsIds = context.Parts
                .Select(x => x.Id)
                .ToArray();

            foreach (var x in carsParsed)
            {
                Car currentCar = new Car()
                {
                    Make = x.Element("make").Value,
                    Model = x.Element("model").Value,
                    TravelledDistance = Convert.ToInt64(x.Element("TraveledDistance").Value)
                };

                var partIds = new HashSet<int>();

                foreach (var id in x.Element("parts").Elements())
                {
                    var pid = Convert.ToInt32(id.Attribute("id").Value);
                    partIds.Add(pid);
                }

                foreach (var pid in partIds)
                {
                    if (existingPartsIds.Contains(pid) == false)
                        continue;

                    PartCar currentPair = new PartCar()
                    {
                        Car = currentCar,
                        PartId = pid
                    };

                    currentCar.PartCars.Add(currentPair);
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            var customersDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDtos)
            {
                var customer = new Customer
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]),
                new XmlRootAttribute("Sales"));

            var salesDtos = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var carIds = context.Cars.Select(x => x.Id).ToArray();

            var sales = new List<Sale>();

            foreach (var saleDto in salesDtos)
            {
                if (!carIds.Contains(saleDto.CarId))
                {
                    continue;
                }

                var sale = new Sale
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(x => new ExportCarsWithDistance
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistance[]),
                new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(x => new ExportCarsFromBMW
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsFromBMW[]),
                new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(x => new ExportLocalSuppliers
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliers[]),
                new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .Select(x => new ExportCarsWithParts
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new ExportPartDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithParts[]),
                new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(x => new ExportTotalSalesByCustomer
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(t => t.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportTotalSalesByCustomer[]),
                new XmlRootAttribute("customers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(x => new ExportSalesWithDiscount
                {
                    Car = new CarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },

                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = $"{x.Car.PartCars.Sum(z => z.Part.Price) - (x.Car.PartCars.Sum(w => w.Part.Price) * (x.Discount / 100))}".TrimEnd('0')
                })
                .ToArray();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSalesWithDiscount[]),
                new XmlRootAttribute("sales"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}