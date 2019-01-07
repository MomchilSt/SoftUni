 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var classType = typeof(HarvestingFields);

            string input = Console.ReadLine();

            while (input != "HARVEST")
            {
                var result = ReturnsNeededFields(classType, input);

                foreach (var field in result)
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
                }

                input = Console.ReadLine();
            }
        }

        private static FieldInfo[] ReturnsNeededFields(Type classType, string input)
        {
            switch (input)
            {
                case "private":
                    var privateFields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsPrivate).ToArray();
                    return privateFields;

                case "protected":
                    var protectedFields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsFamily).ToArray();
                    return protectedFields;

                case "public":
                    var publicFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public).Where(x => x.IsPublic).ToArray();
                    return publicFields;

                case "all":
                    var allFields = classType.GetFields(
                    BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                    return allFields;

                default:
                    return null;
            }
        }
    }
}
