using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
        }

        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();
                var tokens = input.Split();

                if (tokens[0] == "Exit")
                {
                    writer.WriteLine(commandParser.Parse(tokens));

                    break;
                }
                writer.WriteLine(commandParser.Parse(tokens));
            }
        }
    }
}