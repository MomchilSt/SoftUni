namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dtos;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string FailureMessage = "Error: Invalid data.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var allAnimalAids = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            var sb = new StringBuilder();

            var validAnimalAids = new List<AnimalAid>();

            foreach (var animalAid in allAnimalAids)
            {
                bool entityExists = validAnimalAids.Any(x => x.Name == animalAid.Name);

                if (!IsValid(animalAid) || entityExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                validAnimalAids.Add(animalAid);
                sb.AppendLine(string.Format(SuccessMessage, animalAid.Name));
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var allAnimals = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            var sb = new StringBuilder();

            var validAnimals = new List<Animal>();

            foreach (var currAninmal in allAnimals)
            {
                bool animalIsValid = IsValid(currAninmal);
                bool passportIsValid = IsValid(currAninmal.Passport);

                bool alreadyExists = validAnimals.Any(a => a.Passport.SerialNumber == currAninmal.Passport.SerialNumber);

                if (!animalIsValid || !passportIsValid || alreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var animal = new Animal
                {
                    Name = currAninmal.Name,
                    Type = currAninmal.Type,
                    Age = currAninmal.Age,
                    Passport = new Passport
                    {
                        SerialNumber = currAninmal.Passport.SerialNumber,
                        OwnerName = currAninmal.Passport.OwnerName,
                        OwnerPhoneNumber = currAninmal.Passport.OwnerPhoneNumber,
                        RegistrationDate = DateTime.ParseExact(currAninmal.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                    }
                };


                validAnimals.Add(animal);
                sb.AppendLine($"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(VetDto[]),
                new XmlRootAttribute("Vets"));

            var vetDtos = (VetDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var vets = new List<Vet>();

            foreach (var vetDto in vetDtos)
            {
                bool isValid = IsValid(vetDto);
                bool alreadyExists = vets.Any(x => x.PhoneNumber == vetDto.PhoneNumber);

                if (!isValid || alreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var vet = new Vet
                {
                    Name = vetDto.Name,
                    Profession = vetDto.Profession,
                    Age = vetDto.Age,
                    PhoneNumber = vetDto.PhoneNumber
                };

                vets.Add(vet);
                sb.AppendLine(string.Format(SuccessMessage, vet.Name));
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProcedureDto[]),
                new XmlRootAttribute("Procedures"));

            var procedureDtos = (ProcedureDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var procedures = new List<Procedure>();


            foreach (var procedureDto in procedureDtos)
            {

                int? vetId = context.Vets.SingleOrDefault(v => v.Name == procedureDto.Vet)?.Id;
                bool dateIsValid = DateTime.TryParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);
                bool passportExists = context.Passports.Any(p => p.SerialNumber == procedureDto.Animal);

                if (vetId == null || !passportExists || procedureDto.AnimalAids == null || !dateIsValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var animalAidsIds = new List<int>();
                bool allAidsExist = true;

                foreach (var aid in procedureDto.AnimalAids)
                {
                    string aidName = aid.Name;

                    int? aidId = context.AnimalAids.SingleOrDefault(a => a.Name == aidName)?.Id;

                    if (aidId == null || animalAidsIds.Any(id => id == aidId))
                    {
                        allAidsExist = false;
                        break;
                    }

                    animalAidsIds.Add(aidId.Value);
                }


                if (!allAidsExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var procedure = new Procedure
                {
                    VetId = vetId.Value,
                    AnimalId = context.Animals.Single(a => a.PassportSerialNumber == procedureDto.Animal).Id,
                    DateTime = dateTime,
                };

                foreach (var id in animalAidsIds)
                {
                    var mapping = new ProcedureAnimalAid()
                    {
                        Procedure = procedure,
                        AnimalAidId = id
                    };

                    procedure.ProcedureAnimalAids.Add(mapping);
                }

                bool isValid = IsValid(procedure);

                if (!isValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                procedures.Add(procedure);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(procedures);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}
