using NUnit.Framework;
using System;
using System.Reflection;
using System.Linq;

[TestFixture]
public class ExtendedDbTests
{
    [Test]
    public void 
        AddingPersonWithExistingNameThrowsInvalidOperationException()
    {
        Database database = new Database();

        Person personFirst = new Person(134, "Peshoo");
        Person personSecond = new Person(135, "Peshoo");

        database.Add(personFirst);

        Assert.Throws<InvalidOperationException>(() => database.Add(personSecond));
    }

    [Test]
    public void
    AddingPersonWithExistingIdThrowsInvalidOperationException()
    {
        Database database = new Database();

        Person personFirst = new Person(134, "Spartak");
        Person personSecond = new Person(134, "pesak");

        database.Add(personFirst);

        Assert.Throws<InvalidOperationException>(() => database.Add(personSecond));
    }

    [Test]
    public void TestingIfRemovingPersonWorks()
    {
        Database database = new Database();

        Person personFirst = new Person(134, "Spartak");
        Person personSecond = new Person(33, "pesak");

        database.Add(personFirst);
        database.Add(personSecond);

        var expectedResult = database.Remove();

        Assert.That(personSecond, Is.EqualTo(expectedResult));
    }

    [Test]
    public void FindByUsernameWithgivenNullParamThrowArgumentNullException()
    {
        Database database = new Database();

        Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
    }

    [Test]
    public void FindByUsernameDoesntContainNameThrowsInvalidOperationException()
    {
        Database database = new Database();

        Assert.Throws<InvalidOperationException>(() => database.FindByUsername("LoL"));
    }

    [Test]
    public void FindByIdDoesntContainIdThrowsInvalidOperationException()
    {
        Database database = new Database();

        Assert.Throws<InvalidOperationException>(() => database.FindById(1323));
    }

    [Test]
    public void FindByIdIfIdIsNegativeThrowsArgumentExceptions()
    {
        Database database = new Database();

        Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-22));
    }

    [Test]
    public void TestIfAddWorksCorrectly()
    {
        Database database = new Database();

        Person personFirst = new Person(134, "Spartak");

        database.Add(personFirst);

        var expectedFirst = personFirst;

        Assert.That(personFirst, Is.EqualTo(expectedFirst));
    }

    [Test]
    public void FindByIdReturnsCorrectPerson()
    {
        Database database = new Database();

        Person person = new Person(134, "Spartak");

        database.Add(person);

        var expected = database.FindById(134);

        Assert.That(person, Is.EqualTo(expected));
    }

    [Test]
    public void FindByUsernameReturnsCorrectPerson()
    {
        Database database = new Database();

        Person person = new Person(134, "Spartak");

        database.Add(person);

        var expected = database.FindByUsername("Spartak");

        Assert.That(person, Is.EqualTo(expected));
    }
}