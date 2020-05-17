using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinicBusinessLogic.BindingModels
{
    public class ServiceBindingModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public int Price { get; set; }
    }
}
