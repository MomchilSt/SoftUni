using System.Collections.Generic;
using System.Linq;
using CosmosX.Core.Contracts;

namespace CosmosX.Core
{
    public class CommandParser : ICommandParser
    {
        private readonly IManager reactorManager;

        public CommandParser(IManager reactorManager)
        {
            this.reactorManager = reactorManager;
        }

        public string Parse(IList<string> arguments)
        {
            string command = arguments[0];

            string[] commandArguments = arguments.Skip(1).ToArray();

            string result = string.Empty;


            result = (string)this.reactorManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name.Contains(command))
                .Invoke(this.reactorManager, new object[] { commandArguments });

            return result;
        }
    }
}