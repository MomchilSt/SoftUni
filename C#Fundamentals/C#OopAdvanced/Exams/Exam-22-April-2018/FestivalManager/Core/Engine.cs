using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using IO.Contracts;

	public class Engine : IEngine
	{
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
        }

        public void Run()
		{
			while (true)
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;

                string result;

                try
                {
                    result = this.ProcessCommand(input);
                }
                catch (TargetInvocationException ex)
                {
                    result = "ERROR: " + ex.InnerException.Message;

                }
                catch (Exception ex)
                {
                    result = "ERROR: " + ex.Message;
                }

                this.writer.WriteLine(result.Trim());
            }

            var report = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(report);
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split();

			var command = tokens[0];
            string result;

			if (command == "LetsRock")
			{
                result = this.setCоntroller.PerformSets();
			}
            else 
            {
                string[] commandParams = tokens
                                        .Skip(1)
                                        .ToArray();

                var festivalcontrolfunction = this.festivalCоntroller
                    .GetType()
                    .GetMethods()
                    .FirstOrDefault(m => m.Name == command);

                result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { commandParams });
            }

            return result;
		}
	}
}