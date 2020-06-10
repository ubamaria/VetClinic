using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicBusinessLogic.ViewModels
{
    [DataContract]
    public class PetViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DisplayName("Кличка питомца")]
        [DataMember]
        public string PetName { get; set; }
        [DataMember]
        [DisplayName("Вид")]
        public string Kind { get; set; } //вид
        [DataMember]
        [DisplayName("Порода")]
        public string Breed { get; set; } //порода
        [DisplayName("Возраст")]
        [DataMember]
        public int Age { get; set; }
        [DisplayName("Пол")]
        [DataMember]
        public string Gender { get; set; } //пол
        [DataMember]
        public List<ClientPetViewModel> ClientPets { get; set; }
    }
}
