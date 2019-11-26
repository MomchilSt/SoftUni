using NUnit.Framework;
using System;
using CustomLinkedList;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class Tests
    {
        private DynamicList<int> list;

        [SetUp]
        public void TestInit()
        {
            this.list = new DynamicList<int>();
        }

        [Test]
        public void CannotCallElementWithNegativeIndex()
        {
            var incorrectIndex = -1;

            

            Assert.Throws<ArgumentOutOfRangeException>(
                () => 
                {
                    var test = this.list[incorrectIndex];

                },  
                "Provided index is less then zero");
        }

        [Test]
        public void CannotCallElementWithIndexAboveTheRange()
        {
            var incorrectIndex = 1;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var test = this.list[incorrectIndex];
            }
            , "Provided index is greater than the range of the collection");
        }

        [Test]
        public void AddShouldIncreaseCollectionCount()
        {
            this.list.Add(1);

            Assert.AreEqual(1, this.list.Count, "Adding an element doesn't affect the collection's count");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveAtIndexOusideTheBoundariesOfTheCollectionIsImpossible(int indexToRemove)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.list.RemoveAt(indexToRemove));
        }

        [Test]
        public void RemoveAtShouldRemoveTheElementAtTheGivenIndex()
        {
            for (int i = 0; i < 10; i++)
            {
                this.list.Add(i);
            }

            for (int i = this.list.Count - 1; i >= 0; i--)
            {
                var currNum = this.list[i];
                var expected = this.list.RemoveAt(i);
                Assert.That(currNum, Is.EqualTo(expected));
            }
        }

        [Test]
        [TestCase(3, 3)]
        [TestCase(5, -1)]
        [TestCase(10, 15)]
        public void IndexOfShouldReturnNegativeIntegerIfTheGivenElementDoesNotExists(int number, int index)
        {
            this.list.Add(number);

            int isReturnedValueLessThanZero = this.list.IndexOf(index);

            Assert.That(-1, Is.EqualTo(-1));
        }


        [Test]
        [TestCase(3, 2)]
        [TestCase(3, -1)]
        [TestCase(3, 10)]
        public void RemoveUnexistentEelementShouldReturnNegativeInteger(int number, int elementToRemove)
        {
            this.list.Add(number);

            int isRemovingResultLesThanZero = this.list.Remove(elementToRemove);
            Assert.IsTrue(isRemovingResultLesThanZero < 0);
        }

        [Test]
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        [TestCase(10, 10)]
        public void ContainsShouldReturnTrueIfElementExists(int number, int keyElement)
        {
            this.list.Add(number);

            Assert.IsTrue(this.list.Contains(keyElement));
        }

        [Test]
        [TestCase(3, 8)]
        [TestCase(5, 10)]
        [TestCase(10, 15)]
        public void ContainsShouldReturnfalseIfElementDoesNotExists(int numberOfAdditions, int keyElement)
        {
            this.list.Add(numberOfAdditions);

            Assert.IsFalse(this.list.Contains(keyElement));
        }
    }
}
