using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VetClinicBusinessLogic.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО клиента")]
        public string ClientFIO { get; set; }
        [DisplayName("Логин")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
