using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicBusinessLogic.Enums;

namespace VetClinicWbClient.Models
{
    public class ReceptionModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PetId { get; set; }
        public string ClientFIO { get; set; }
        public string PetName { get; set; }
        public decimal TotalSum { get; set; }
        public ReceptionStatus ReceptionStatus { get; set; }
        public DateTime DateCreate { get; set; }
        public virtual List<ReceptionServiceModel> ReceptionServices { get; set; }
    }
}
