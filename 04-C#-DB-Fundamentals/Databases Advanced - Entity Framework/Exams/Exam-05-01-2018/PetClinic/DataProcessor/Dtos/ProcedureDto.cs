using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dtos
{
    [XmlType("Procedure")]
    public class ProcedureDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Vet { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]{7}[0-9]{3}$")]
        public string Animal { get; set; }

        [Required]
        public string DateTime { get; set; }

        [XmlArray]
        public AnimalAidDto[] AnimalAids
        {
            get; set;
        }

        [XmlType("AnimalAid")]
        public class AnimalAidDto
        {
            [Required]
            [StringLength(30, MinimumLength = 3)]
            public string Name { get; set; }
        }
    }
}
