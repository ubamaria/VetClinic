using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinicBusinessLogic.BindingModels
{
    public class RecordingServiceBindingModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int RecordingId { get; set; }
        public int Count { get; set; }
    }
}
