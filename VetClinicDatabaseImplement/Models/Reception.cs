using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using VetClinicBusinessLogic.Enums;

namespace VetClinicDatabaseImplement.Models
{
    public class Reception
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int PetId { get; set; }

        [Required]
        public decimal TotalSum { get; set; }

        public ReceptionStatus ReceptionStatus { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public virtual Client Client { get; set; }

        [ForeignKey("ReceptionId")]
        public virtual List<ReceptionService> ReceptionServices { get; set; }
        [Required]
        [ForeignKey("ReceptionId")]
        public List<Payment> Payments { get; set; }
    }
}
