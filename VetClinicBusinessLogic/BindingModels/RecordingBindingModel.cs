using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinicBusinessLogic.BindingModels
{
    public class RecordingBindingModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Sum { get; set; }
        public virtual List<RecordingServiceBindingModel> RecordingServices { get; set; }
    }
}
