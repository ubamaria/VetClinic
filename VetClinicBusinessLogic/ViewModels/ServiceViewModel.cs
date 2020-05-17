using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VetClinicBusinessLogic.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название услуги")]
        public string ServiceName { get; set; }
        [DisplayName("Цена услуги")]
        public int Price { get; set; }
    }
}
