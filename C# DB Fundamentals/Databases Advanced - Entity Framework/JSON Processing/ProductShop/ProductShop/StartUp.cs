using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //var usersInput = File.ReadAllText(@"../../../Datasets/users.json");
            //var productsInput = File.ReadAllText(@"../../../Datasets/products.json");
            //var categoriesInput = File.ReadAllText(@"../../../Datasets/ategories.json");
            //var categoryProductsInput = File.ReadAllText(@"../../../Datasets/categories-products.json");

            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length >= 3)
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length >= 3)
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null && c.Name.Length >= 3 && c.Name.Length <= 15)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var validCategoryIds = context
                .Categories
                .Select(x => x.Id)
                .ToHashSet();

            var validProductIds = context
                .Products
                .Select(x => x.Id)
                .ToHashSet();

            CategoryProduct[] categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)
                .Where(x => validCategoryIds.Contains(x.CategoryId) && validProductIds.Contains(x.ProductId))
                .ToArray();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();

            var json = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var fillteredUsers = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(ps => ps.Buyer != null)
                        .Select(ps => new
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                            BuyerFirstName = ps.Buyer.FirstName,
                            BuyerLastName = ps.Buyer.LastName
                        })
                        .ToArray()
                })
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(fillteredUsers,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = contractResolver
                });

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = $"{x.CategoryProducts.Average(c => c.Product.Price):F2}",
                    TotalRevenue = $"{x.CategoryProducts.Sum(c => c.Product.Price)}"
                })
                .ToList();

            string json = JsonConvert.SerializeObject(categories,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy(),
                    },

                    Formatting = Formatting.Indented
                }
            );

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var fillteredUsers = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(ps => ps.Buyer != null),

                        Products = u.ProductsSold
                        .Where(ps => ps.Buyer != null)
                        .Select(ps => new
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .ToArray()
                    }
                })
                .ToArray();

            var result = new
            {
                UsersCount = fillteredUsers.Length,
                Users = fillteredUsers
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(result,
            new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }
    }
}