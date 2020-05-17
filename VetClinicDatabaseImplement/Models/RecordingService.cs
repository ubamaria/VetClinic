using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicDatabaseImplement.Models
{
    [DataContract]
    public class RecordingService
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public int RecordingId { get; set; }
        [DataMember]
        [Required]
        public int Count { get; set; }
        public virtual Service Service { get; set; }
        public virtual Recording Recording { get; set; }
    }
}
