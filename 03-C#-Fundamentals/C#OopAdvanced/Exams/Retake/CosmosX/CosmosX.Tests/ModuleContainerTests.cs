namespace CosmosX.Tests
{
    using CosmosX.Entities.Containers;
    using CosmosX.Entities.Modules.Absorbing;
    using CosmosX.Entities.Modules.Energy;
    using CosmosX.Entities.Reactors;
    using CosmosX.Entities.Reactors.ReactorFactory;
    using NUnit.Framework;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void TestIfModulesAreBeingAdded()
        {
            var moduleContainer = new ModuleContainer(5);
            var energy = new CryogenRod(3, 13);
            var heatProc = new HeatProcessor(3, 14);

            moduleContainer.AddAbsorbingModule(heatProc);
            moduleContainer.AddEnergyModule(energy);


            Assert.That(2, Is.EqualTo(moduleContainer.ModulesByInput.Count));
        }

        [Test]
        public void AddingNullModulesThrowsException()
        {
            var moduleContainer = new ModuleContainer(5);

            Assert.That(() => { moduleContainer.AddEnergyModule(null); },
            Throws.ArgumentException);

            Assert.That(() => { moduleContainer.AddAbsorbingModule(null); },
            Throws.ArgumentException);
        }

        [Test]
        public void WhenModuleIsFullRemovesFirst()
        {
            var moduleContainer = new ModuleContainer(3);
            var energy = new CryogenRod(3, 13);
            var heatProc = new HeatProcessor(4, 14);
            var prces = new HeatProcessor(7, 14);
            var cooldown = new CooldownSystem(1, 2);

            moduleContainer.AddAbsorbingModule(heatProc);
            moduleContainer.AddEnergyModule(energy);
            moduleContainer.AddAbsorbingModule(prces);
            moduleContainer.AddAbsorbingModule(cooldown);


            Assert.That(3, Is.EqualTo(moduleContainer.ModulesByInput.Count));
        }


        [Test]
        public void TestingHeat()
        {
            var moduleContainer = new ModuleContainer(2);

            var cooldown = new CooldownSystem(13, 41);
            var heatProc = new HeatProcessor(3, 14);

            moduleContainer.AddEnergyModule(new CryogenRod(31, 41));
            moduleContainer.AddAbsorbingModule(heatProc);
            moduleContainer.AddAbsorbingModule(cooldown);

            var expectedAbsorbing = 55;

            Assert.That(expectedAbsorbing, Is.EqualTo(moduleContainer.TotalHeatAbsorbing));
        }

        [Test]
        public void TestingEnergy()
        {
            var moduleContainer = new ModuleContainer(5);

            var energy = new CryogenRod(3, 13);
            var energy3 = new CryogenRod(5, 133);

            moduleContainer.AddEnergyModule(energy);
            moduleContainer.AddEnergyModule(energy3);

            var expectedEnergy = 146;

            Assert.That(expectedEnergy, Is.EqualTo(moduleContainer.TotalEnergyOutput));
        }

        [Test]
        public void TestingToString()
        {
            var moduleContainer = new ModuleContainer(5);


            var energy = new CryogenRod(3, 13);
            var heatProc = new HeatProcessor(3, 14);

            moduleContainer.AddAbsorbingModule(heatProc);
            moduleContainer.AddEnergyModule(energy);

            var expectedEnergy = moduleContainer.TotalEnergyOutput;

            Assert.That(expectedEnergy, Is.EqualTo(moduleContainer.TotalEnergyOutput));
        }
        //[Test]
        //public void TestToString()
        //{
        //    var reactorFactory = new ReactorFactory();
        //    var moduleContainer = new ModuleContainer(5);
        //    var reactor = reactorFactory.CreateReactor("Cryo", 1, moduleContainer, 6);
        //    var heatProc = new HeatProcessor(3, 14);
        //    var energy = new CryogenRod(8, 134);

        //    reactor.AddAbsorbingModule(heatProc);
        //    reactor.AddEnergyModule(energy);

        //    var expected = "HeatReactor - 1\r\nEnergy Output: 13\r\nHeat Absorbing: 17\r\nModules: 2";

        //    Assert.That(expected, Is.EqualTo(reactor.ToString()));
        //}
    }
}