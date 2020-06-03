using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicBusinessLogic.BindingModels
{
    [DataContract]
    public class ReceptionBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PetId { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public DateTime? DateTo { get; set; }
        [DataMember]
        public virtual List<ReceptionServiceBindingModel> ReceptionServices { get; set; }
    }
}
