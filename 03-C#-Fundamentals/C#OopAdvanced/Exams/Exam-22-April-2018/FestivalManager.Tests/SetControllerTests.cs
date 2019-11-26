// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
        public object IStage { get; private set; }

        [Test]
	    public void SetControllerShouldReturnFailMessage()
	    {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            stage.AddSet(set);

            string actualResult = setController.PerformSets();
            string expectedResult = "1. Set1:\r\n-- Did not perform";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
		}

        [Test]
        public void SetControllerShouldReturnSucessMessage()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Pesho", 12);
            performer.AddInstrument(new Guitar());
            set.AddPerformer(performer);

            ISong song = new Song("Song", new TimeSpan(0, 2, 30));
            set.AddSong(song);

            stage.AddSet(set);

            string actualResult = setController.PerformSets();
            string expectedResult = setController.PerformSets();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PerformSetsShouldDecreaseInstrumentWear()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Pesho", 12);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddPerformer(performer);

            ISong song = new Song("Song", new TimeSpan(0, 2, 30));
            set.AddSong(song);

            stage.AddSet(set);

            double instrumentBeforePerforming = instrument.Wear;

            setController.PerformSets();

            double instrumentAfterPerforming = instrument.Wear;

            Assert.That(instrumentAfterPerforming, Is.Not.EqualTo(instrumentBeforePerforming));
        }
	}
}