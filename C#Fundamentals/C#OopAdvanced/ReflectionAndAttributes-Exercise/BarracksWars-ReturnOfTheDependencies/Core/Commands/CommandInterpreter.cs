using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static _03BarracksFactory.Core.Core.Commands.AddCommand;

namespace BarracksWars_TheCommandsStrikeBack.Core.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            if (type == null)
            {
                throw new ArgumentException("Invalid Command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(type))
            {
                throw new ArgumentException($"{commandName} Is Not A Command!");
            }

            FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] costrArgs = new object[] { data }.Concat(injectArgs).ToArray();

            var instance = (IExecutable)Activator.CreateInstance(type, costrArgs);

            return instance;
        }
    }
}
