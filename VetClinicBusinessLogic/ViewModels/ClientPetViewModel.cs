using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientPetViewModel
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PetId { get; set; }
        [DisplayName("Имя питомца")]
        [DataMember]
        public int PetName { get; set; }
        [DisplayName("ФИО клиента")]
        [DataMember]
        public string ClientFIO { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
