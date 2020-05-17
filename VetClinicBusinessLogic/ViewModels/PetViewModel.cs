using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VetClinicBusinessLogic.ViewModels
{
    public class PetViewModel
    {
        public int Id { get; set; }
        [DisplayName("Кличка питомца")]
        public string PetName { get; set; }
        [DisplayName("Вид")]
        public string Kind { get; set; } //вид
        [DisplayName("Порода")]
        public string Breed { get; set; } //порода
        [DisplayName("Возраст")]
        public int Age { get; set; }
        [DisplayName("Пол")]
        public string Gender { get; set; } //пол
    }
}
