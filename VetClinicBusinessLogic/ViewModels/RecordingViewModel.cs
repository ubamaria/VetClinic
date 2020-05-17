using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VetClinicBusinessLogic.BindingModels;

namespace VetClinicBusinessLogic.ViewModels
{
    public class RecordingViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [DisplayName("ФИО Клиента")]
        public string ClientFIO { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Статус записи")]
        public string RecordingStatus { get; set; }

        [DisplayName("Дата создания записи на прием")]
        public string DateCreate { get; set; }

        [DisplayName("Дата завершения записи на прием")]
        public string DateImplement { get; set; }
        public virtual List<RecordingServiceBindingModel> RecordingServices { get; set; }
    }
}
