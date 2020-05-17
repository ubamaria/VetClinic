using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VetClinicBusinessLogic.ViewModels
{
    public class RecordingServiceViewModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int RecordingId { get; set; }
        [DisplayName("Название услуги")]
        public string ServiceName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
