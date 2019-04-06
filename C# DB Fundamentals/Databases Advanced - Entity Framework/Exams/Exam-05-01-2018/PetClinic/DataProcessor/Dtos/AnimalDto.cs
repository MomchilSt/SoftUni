using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.DataProcessor.Dtos
{
    public class AnimalDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Range(1, 666)]
        public int Age { get; set; }

        public PassportDto Passport { get; set; }
    }

    public class PassportDto
    {
        [RegularExpression("^[a-zA-Z]{7}[0-9]{3}$")]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string OwnerName { get; set; }

        [Required]
        [RegularExpression(@"^(\+359|0)[0-9]{9}$")]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        public string RegistrationDate { get; set; }
    }
}
