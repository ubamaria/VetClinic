using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinicBusinessLogic.ViewModels
{
    public class ClientPetViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PetId { get; set; }
        public string ClientFIO { get; set; }
        public int Count { get; set; }
    }
}
