using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicDatabaseImplement.Models
{
    [DataContract]
    public class Pet
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string PetName { get; set; }
        [DataMember]
        [Required]
        public string Kind { get; set; } //вид
        [DataMember]
        [Required]
        public string Breed { get; set; } //порода
        [DataMember]
        [Required]
        public int Age { get; set; }
        [DataMember]
        [Required]
        public string Gender { get; set; } //пол
        [ForeignKey("PetId")]
        public virtual List<ClientPet> ClientPets { get; set; }
    }
}
