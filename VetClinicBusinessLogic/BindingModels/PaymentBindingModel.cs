using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicBusinessLogic.BindingModels
{
    [DataContract]
    public class PaymentBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int ReceptionId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PetId { get; set; }
        [DataMember]
        public DateTime DatePayment { get; set; }
        [DataMember]
        public int Sum { get; set; }
    }
}
