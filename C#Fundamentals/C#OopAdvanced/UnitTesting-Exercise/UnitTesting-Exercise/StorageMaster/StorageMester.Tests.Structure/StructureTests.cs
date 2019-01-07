using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class StructureTests
    {
        private Type vehicle;

        [SetUp]
        public void SetUp()
        {
            this.vehicle = this.GetType("Vehicle");
        }

        [Test]
        public void ValidateAllVehicles()
        {
            var types = new[]
            {
                "Semi",
                "Truck",
                "Van",
                "Vehicle"
            };

            foreach (var type in types)
            {
                var currentType = GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{type} doesn't exists");
            }
        }

        [Test]
        public void ValidateVehicleConstructor()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;

            var constructor = this.vehicle.GetConstructors(flags).FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, "Constructor doesn't exists");

            var constructorsParams = constructor.GetParameters();

            Assert.That(constructorsParams[0].ParameterType, Is.EqualTo(typeof(int)));
        }

        [Test]
        public void ValidateVehicleChildClasses()
        {
            var derivedTypes = new[]
            {
                GetType("Semi"),
                GetType("Truck"),
                GetType("Van"),
            };

            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(vehicle), $"{derivedType} doesn't inherit {vehicle}!");
            }
        }

        [Test]
        public void ValidateVehicleProperties()
        {
            var actualProperties = vehicle.GetProperties();

            var expectedProperties = new Dictionary<string, Type>
            {
                { "Capacity", typeof(int) },
                { "Trunk", typeof(IReadOnlyCollection<Product>) },
                { "IsFull", typeof(bool) },
                { "IsEmpty", typeof(bool) }
            };

            foreach (var actualProperty in actualProperties)
            {
                var isValidProperty = expectedProperties.Any(x => x.Key == actualProperty.Name && actualProperty.PropertyType == x.Value);

                Assert.That(isValidProperty, $"{actualProperty.Name} doesn't exists!");
            }
        }

        [Test]
        public void ValidateVehicleMethods()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(void), "LoadProduct", typeof(Product)),
                new Method(typeof(Product), "Unload")
            };

            foreach (var expectedMethod in expectedMethods)
            {
                var currentMethod = vehicle.GetMethod(expectedMethod.Name);

                Assert.That(currentMethod, Is.Not.Null, $"{expectedMethod.Name} method doesn't exists");

                var currentMethodReturnType = currentMethod.ReturnType == expectedMethod.ReturnType;

                Assert.That(currentMethodReturnType, $"{expectedMethod.Name} invalid return type");

                var expectedMethodParms = expectedMethod.InputParamateres;
                var actualParms = currentMethod.GetParameters();

                for (int i = 0; i < expectedMethodParms.Length; i++)
                {
                    var actualParam = actualParms[i].ParameterType;
                    var expectedParam = expectedMethodParms[i];

                    Assert.AreEqual(expectedParam, actualParam);
                }
            }
        }

        [Test]
        public void ValidateVehicleIsAbstract()
        {
            Assert.That(vehicle.IsAbstract, $"Vehicle class must be abstract!");
        }

        [Test]
        public void ValidateVehicleFields()
        {
            var trunkField = vehicle.GetField("trunk", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(trunkField, Is.Not.Null, $"Invalid field");
        }

        private Type GetType(string type)
        {
            var targetType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            return targetType;
        }

        [Test]
        public void CheckIfProductClassExists()
        {
            Type productExists = typeof(Product);

            Assert.AreEqual("Product", productExists.Name);
        }

        [Test]
        public void TestProductsFields()
        {
            Type productExists = typeof(Product);
            FieldInfo field = productExists.GetField("price", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.AreEqual("price", field.Name);
        }

        [Test]
        public void TestProductProperties()
        {
            Type productExists = typeof(Product);
            PropertyInfo property1 = productExists.GetProperty("Price");
            PropertyInfo property2 = productExists.GetProperty("Weight");

            Assert.AreEqual(true, property1.SetMethod.IsPrivate);
        }

        [Test]
        public void ProductPriceProperty()
        {
            Product Gpu = new Gpu(2.5);

            Assert.AreEqual(2.5, Gpu.Price);
        }

        [Test]
        public void ProductPricePropertyShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => { Product Gpu = new Gpu(-2.5); });
        }

        [Test]
        public void GpuInheritance()
        {
            Gpu gpu = new Gpu(2.5);

            Assert.IsInstanceOf<Product>(gpu);
        }

        [Test]
        public void TestGpuFields()
        {
            Gpu gpu = new Gpu(5);

            Assert.AreEqual(0.7, gpu.Weight);
        }

        [Test]
        public void HDDInheritance()
        {
            HardDrive hardDrive = new HardDrive(2.5);

            Assert.IsInstanceOf<Product>(hardDrive);
        }

        [Test]
        public void TestHddFields()
        {
            HardDrive hdd = new HardDrive(5);

            Assert.AreEqual(1, hdd.Weight);
        }

        [Test]
        public void RamInheritance()
        {
            Ram ram = new Ram(2.5);

            Assert.IsInstanceOf<Product>(ram);
        }

        [Test]
        public void TestRamFields()
        {
            Ram ram = new Ram(5);

            Assert.AreEqual(0.1, ram.Weight);
        }

        [Test]
        public void SSDInheritance()
        {
            SolidStateDrive solidStateDrive = new SolidStateDrive(2.5);

            Assert.IsInstanceOf<Product>(solidStateDrive);
        }

        [Test]
        public void TestSSDFields()
        {
            SolidStateDrive solidStateDrive = new SolidStateDrive(5);

            Assert.AreEqual(0.2, solidStateDrive.Weight);
        }

        [Test]
        public void CheckIfStorageClassExists()
        {
            Type productExists = typeof(Storage);

            Assert.AreEqual("Storage", productExists.Name);
        }

        [Test]
        public void TestStorageFields()
        {
            Type productExists = typeof(Storage);
            FieldInfo field1 = productExists.GetField("garage", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo field2 = productExists.GetField("products", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.AreEqual("garage", field1.Name);
            Assert.AreEqual("products", field2.Name);
            Assert.AreEqual(true, field1.IsInitOnly);
            Assert.AreEqual(true, field2.IsInitOnly);
        }

        [Test]
        public void TestStorageName()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual("Pesho", warehouse.Name);
        }

        [Test]
        public void TestStorageCapacity()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(10, warehouse.Capacity);
        }

        [Test]
        public void TestStorageGarageSlots()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(10, warehouse.GarageSlots);
        }

        [Test]
        public void TestStorageIsFull()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(false, warehouse.IsFull);
        }

        [Test]
        public void TestStorageGarageForIReadonly()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(true, typeof(Warehouse).GetProperty("Garage").CanWrite == false);
        }

        [Test]
        public void TestStorageProductForIReadonly()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(true, typeof(Warehouse).GetProperty("Products").CanWrite == false);
        }

        [Test]
        public void TestGetVehicle()
        {
            Storage storage = new Warehouse("Pesho");

            Assert.AreEqual("Semi", storage.GetVehicle(0).GetType().Name);
        }

        [Test]
        public void TestGetVehicleWithIOE1()
        {
            Storage storage = new Warehouse("Pesho");

            Assert.Throws<InvalidOperationException>(() => { storage.GetVehicle(11); });
        }

        [Test]
        public void TestGetVehicleWithIOE2()
        {
            Storage storage = new Warehouse("Pesho");

            Assert.Throws<InvalidOperationException>(() => { storage.GetVehicle(5); });
        }

        [Test]
        public void TestSendVehicle()
        {
            Storage storage = new Warehouse("Pesho");
            Storage destination = new Warehouse("Gosho");

            Assert.AreEqual(3, storage.SendVehicleTo(2, destination));
            Assert.Throws<InvalidOperationException>(() => { storage.SendVehicleTo(3, destination); });
        }

        [Test]
        public void TestSendVehicleWithIOE()
        {
            Storage storage = new Warehouse("Pesho");
            Storage destination = new Warehouse("Gosho");

            Assert.Throws<InvalidOperationException>(() => { storage.SendVehicleTo(3, destination); });
        }

        [Test]
        public void TestSendVehicleWithIOE2()
        {
            Storage storage = new Warehouse("Pesho");
            Storage destination = new DistributionCenter("Gosho");

            storage.SendVehicleTo(0, destination);
            storage.SendVehicleTo(1, destination);

            Assert.Throws<InvalidOperationException>(() => { storage.SendVehicleTo(2, destination); });
        }

        [Test]
        public void TestUnloadVehicle()
        {
            Storage storage = new DistributionCenter("Pesho");

            Assert.AreEqual(0, storage.UnloadVehicle(1));
        }

        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParams)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParamateres = inputParams;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputParamateres { get; set; }
        }
    }
}
