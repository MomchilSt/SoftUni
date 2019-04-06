namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var allDepartments = JsonConvert.DeserializeObject<Department[]>(jsonString);

            var sb = new StringBuilder();

            var departments = new List<Department>();

            foreach (var department in allDepartments)
            {
                var isValid = IsValid(department) && 
                    department.Cells.All(IsValid);

                if (isValid)
                {
                    departments.Add(department);
                    sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonersMails[]>(jsonString);

            var sb = new StringBuilder();

            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto) || !prisonerDto.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var releaseDate = prisonerDto.ReleaseDate == null
                    ? (DateTime?)null
                    : DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = prisonerDto.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    })
                    .ToArray()
                };

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficersPrisoners[]),
                new XmlRootAttribute("Officers"));

            var officersDto = (ImportOfficersPrisoners[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                var weaponCheck = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weapon);
                var positionCheck = Enum.TryParse<Position>(officerDto.Position, out Position position);

                if (!IsValid(officerDto) || !weaponCheck || !positionCheck)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = officerDto.Prisoners.Select(
                        p => new OfficerPrisoner
                        {
                            PrisonerId = p.Id
                        })
                        .ToArray()
                };

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}