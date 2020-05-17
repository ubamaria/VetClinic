using System;
using System.Collections.Generic;
using System.Text;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.ViewModels;

namespace VetClinicBusinessLogic.Interfaces
{
    public interface IClient
    {
        List<ClientViewModel> GetList();
        ClientViewModel GetElement(int id);
        void AddElement(ClientBindingModel model);
        void UpdateElement(ClientBindingModel model);
        void DeleteElement(int id);
    }
}
