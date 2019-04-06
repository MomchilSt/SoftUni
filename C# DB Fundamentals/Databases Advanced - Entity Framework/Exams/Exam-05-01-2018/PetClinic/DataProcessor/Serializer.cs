namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dtos;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context
                .Animals
                .Where(p => p.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new
                {
                    OwnerName = x.Passport.OwnerName,
                    AnimalName = x.Name,
                    Age = x.Age,
                    SerialNumber = x.Passport.SerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate
                })
                .OrderBy(a => a.Age)
                .OrderBy(s => s.SerialNumber)
                .ToArray();

            string result = JsonConvert.SerializeObject(animals, Formatting.Indented, new JsonSerializerSettings() { DateFormatString = "dd-MM-yyyy" });

            return result;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                    .OrderBy(p => p.DateTime)
                    .ThenBy(p => p.Animal.Passport.SerialNumber)
                    .Select(p => new ExportProcedures
                    {
                        Passport = p.Animal.Passport.SerialNumber,
                        OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                        DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                        AnimalAids = p.ProcedureAnimalAids.Select(map => new AnimalAidsDto
                        {
                            Name = map.AnimalAid.Name,
                            Price = map.AnimalAid.Price
                        })
                        .ToArray(),
                        TotalPrice = p.ProcedureAnimalAids.Select(paa => paa.AnimalAid.Price).Sum(),
                    })
                    .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProcedures[]), new XmlRootAttribute("Procedures"));

            var namespaces = new XmlSerializerNamespaces(new[]
                {
                   XmlQualifiedName.Empty,
                });

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), procedures, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
