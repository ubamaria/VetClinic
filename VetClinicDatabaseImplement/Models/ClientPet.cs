using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicDatabaseImplement.Models
{
    [DataContract]
    public class ClientPet
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PetId { get; set; }
        [DataMember]
        [Required]
        public string ClientFIO { get; set; }
        [DataMember]
        [Required]
        public int Count { get; set; }
        public virtual Client Client { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
