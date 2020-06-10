using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicDatabaseImplement.Models
{
    public class ClientPet
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PetId { get; set; }
        public string ClientFIO { get; set; }
        public int Count { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual Client Client { get; set; }
    }
}
