using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using VetClinicBusinessLogic.BindingModels;

namespace VetClinicBusinessLogic.ViewModels
{
    [DataContract]
    public class ReceptionViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PetId { get; set; }
        [DataMember]
        [DisplayName("ФИО Клиента")]
        public string ClientFIO { get; set; }
        [DataMember]
        [DisplayName("Имя питомца")]
        public int PetName { get; set; }
        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DataMember]
        [DisplayName("Статус приема")]
        public string ReceptionStatus { get; set; }
        [DataMember]

        [DisplayName("Дата создания записи на прием")]
        public string DateCreate { get; set; }
        [DataMember]
        public virtual List<ReceptionServiceBindingModel> ReceptionServices { get; set; }
    }
}
