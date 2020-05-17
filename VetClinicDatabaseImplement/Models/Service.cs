using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicDatabaseImplement.Models
{
    [DataContract]
    public class Service
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string ServiceName { get; set; }
        [DataMember]
        [Required]
        public int Price { get; set; }
        [ForeignKey("ServiceId")]
        public virtual List<RecordingService> RecordingServices { get; set; }
    }
}
