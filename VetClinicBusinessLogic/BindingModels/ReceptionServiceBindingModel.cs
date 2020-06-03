using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicBusinessLogic.BindingModels
{
    [DataContract]
    public class ReceptionServiceBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ServiceId { get; set; }
        [DataMember]
        public int ReceptionId { get; set; }
        [DataMember]
        public int PetId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
