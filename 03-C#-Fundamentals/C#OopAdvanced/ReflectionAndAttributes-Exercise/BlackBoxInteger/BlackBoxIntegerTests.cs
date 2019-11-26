namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var classType = typeof(BlackBoxInteger);
            var blackBox = (BlackBoxInteger)Activator.CreateInstance(classType, true);

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split('_');
                string methodName = tokens[0];
                int value = int.Parse(tokens[1]);

                classType.GetMethod(
                    methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Invoke(blackBox, new object[] { value });

                int currentValue = (int)classType.GetField(
                    "innerValue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .GetValue(blackBox);

                Console.WriteLine(currentValue);
                input = Console.ReadLine();
            }
        }
    }
}
