using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VetClinicBusinessLogic.BindingModels
{
    [DataContract]
    public class PetBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string PetName { get; set; }
        [DataMember]
        public string Kind { get; set; } //вид
        [DataMember]
        public string Breed { get; set; } //порода
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Gender { get; set; } //пол
    }
}
