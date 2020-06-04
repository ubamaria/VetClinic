using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicDatabaseImplement.Models
{
    public class ReceptionService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int ReceptionId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Service Service { get; set; }
        public virtual Reception Reception { get; set; }
    }
}
