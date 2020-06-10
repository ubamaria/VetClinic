using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicDatabaseImplement.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        public string PetName { get; set; }
       [Required]
        public int ClientId { get; set; }
        [Required]
        public string Kind { get; set; } //вид
        [Required]
        public string Breed { get; set; } //порода
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; } //пол

    }
}
