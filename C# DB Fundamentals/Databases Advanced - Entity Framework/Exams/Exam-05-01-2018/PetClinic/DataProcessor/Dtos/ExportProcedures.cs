using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dtos
{
    [XmlType("Procedure")]
    public class ExportProcedures
    {
        public string Passport { get; set; }

        public string OwnerNumber { get; set; }

        public string DateTime { get; set; }

        [XmlArray]
        public AnimalAidsDto[] AnimalAids { get; set; }

        public decimal TotalPrice { get; set; }
    }

    [XmlType("AnimalAid")]
    public class AnimalAidsDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
