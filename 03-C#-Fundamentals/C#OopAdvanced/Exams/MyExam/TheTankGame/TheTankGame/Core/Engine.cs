namespace TheTankGame.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

        }

        public void Run()
        {

            while (true)
            {
                var input = reader.ReadLine();

                var tokens = input.Split().ToList();

                if (tokens[0] == "Terminate")
                {
                    writer.WriteLine(commandInterpreter.ProcessInput(tokens));
                    break;
                }

                writer.WriteLine(commandInterpreter.ProcessInput(tokens));
            }


        }
    }
}