using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinicBusinessLogic.BindingModels
{
    public class PetBindingModel
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string Kind { get; set; } //вид
        public string Breed { get; set; } //порода
        public int Age { get; set; }
        public string Gender { get; set; } //пол
    }
}
