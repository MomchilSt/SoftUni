using Databasee;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DatabaseTests
{
    [TestFixture]
    public class DbTests
    {
        private const int Capacity = 16;
        private const int intialIndex = -1;

        [Test]
        public void EmptyConstructorsShouldInitializeData()
        {
            var db = new Database();

            var type = typeof(Database);

            var field = (int[])type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == "data")
                .GetValue(db);

            var lenght = field.Length;

            Assert.That(lenght, Is.EqualTo(Capacity), "Internal Array is null!");
        }

        [Test]
        public void EmptyConstructorsShouldInitializeIndex()
        {
            var db = new Database();

            var type = typeof(Database);

            var field = (int)type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == "index")
                .GetValue(db);

            Assert.That(field, Is.EqualTo(intialIndex), "Wrong index value!");
        }

        [Test]
        public void CtorShouldThrowInvalidOperationExceptionWithLargerArray()
        {
            int[] arr = new int[17];

            Assert.Throws<InvalidOperationException>(() => new Database(arr));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] {13})]
        [TestCase(new int[] {13, 42, 69})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void CtorShouldSetIndexCorrectly(int[] values)
        {
            Database database = new Database(values);

            Type type = typeof(Database);

            int expectedIndex = values.Length - 1;

            var index = (int)type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == "index")
                .GetValue(database);

            Assert.That(index, Is.EqualTo(expectedIndex));
        }

        [Test]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddShouldIncreaceIndexCorrectly(int[] values)
        {
            Database database = new Database(values);

            Type type = typeof(Database);

            var index = (int)type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(f => f.Name == "index")
            .GetValue(database);

            int expectedIndex = values.Length;

            Assert.That(index, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void AddWhenDatabaseIsFullShouldThrowInvalidOperationException()
        {
            int[] arr = new int[16];

            Database db = new Database(arr);

            Assert.Throws<InvalidOperationException>(() => db.Add(1));
        }
    }
}
