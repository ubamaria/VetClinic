using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicWbClient.Models
{
    public class ClientPetModel
    {
        public string ClientFIO { get; set; }
        public string PetName { get; set; }
        public string Kind { get; set; } //вид
        public string Breed { get; set; } //порода
        public int Age { get; set; }
        public string Gender { get; set; } //пол
        public int Count { get; set; }
        
    }
}
