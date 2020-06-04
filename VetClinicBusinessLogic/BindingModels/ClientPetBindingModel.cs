using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicBusinessLogic.BindingModels
{
    [DataContract]
    public class ClientPetBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PetId { get; set; }
        [DataMember]
        public int PetName { get; set; }
        [DataMember]
        public string ClientFIO { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
