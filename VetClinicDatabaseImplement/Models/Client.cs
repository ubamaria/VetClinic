using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicDatabaseImplement.Models
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string ClientFIO { get; set; }
        [DataMember]
        [Required]
        public string Email { get; set; }
        [DataMember]
        [Required]
        public string Password { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<Recording> Recordings { get; set; }
    }
}
