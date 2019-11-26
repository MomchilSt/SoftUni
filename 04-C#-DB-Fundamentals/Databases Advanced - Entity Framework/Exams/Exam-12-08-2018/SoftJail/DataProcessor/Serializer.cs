namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System.Xml.Serialization;
    using System.IO;
    using System.Text;
    using System.Xml;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(on =>on.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(s => s.Officer.Salary)
                })
                .OrderBy(pn => pn.Name)
                .ThenBy(pi => pi.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(',');

            var prisoners = context.Prisoners
                .Where(p => names.Contains(p.FullName))
                .Select(p => new PrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                    .Select(m => new EncryptedMessagesDto
                    {
                        Description = ReverseString(m.Description)
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var serializer = new XmlSerializer(typeof(PrisonerDto[]),
                new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), prisoners, 
                new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString().TrimEnd();
        }

        private static string ReverseString(string description)
        {
            return string.Join("", description.Reverse());
        }
    }
}