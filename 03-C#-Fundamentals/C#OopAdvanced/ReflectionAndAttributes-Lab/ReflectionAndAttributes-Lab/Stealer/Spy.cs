using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] requestedFields)
    {
        var classType = Type.GetType(className);

        var classFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {className}");

        Object classInstance = Activator.CreateInstance(classType);

        foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}
