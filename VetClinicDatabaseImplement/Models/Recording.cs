using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicDatabaseImplement.Models
{
    [DataContract]
    public class Recording
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        [Required]
        public decimal TotalSum { get; set; }

        [DataMember]
        public RecordingStatus RecordingStatus { get; set; }

        [DataMember]
        [Required]
        public DateTime DateCreate { get; set; }

        [DataMember]
        public DateTime? DateImplement { get; set; }

        public virtual Client Client { get; set; }

        [ForeignKey("RecordingId")]
        public virtual List<RecordingService> RecordingServices { get; set; }
    }
}
