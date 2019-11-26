namespace FestivalManager
{
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

			Stage stage = new Stage();

			IFestivalController festivalController = new FestivalController(
                stage,
                new SetFactory(),
                new InstrumentFactory());

			ISetController setController = new SetController(stage);

			var engine = new Engine(reader, writer, festivalController, setController);

			engine.Run();
		}
	}
}