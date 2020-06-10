﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicWbClient.Models
{
    public class PetModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        public string PetName { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите вид")]
        public string Kind { get; set; } //вид
        [Required(ErrorMessage = "Пожалуйста, введите породу")]
        public string Breed { get; set; } //порода
        [Required(ErrorMessage = "Пожалуйста, введите возраст")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите пол")]
        public string Gender { get; set; } //пол
        public Dictionary<int, int> ClientPets { get; set; }
    }
}
