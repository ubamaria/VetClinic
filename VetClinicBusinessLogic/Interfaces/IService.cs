using System;
using System.Collections.Generic;
using System.Text;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.ViewModels;

namespace VetClinicBusinessLogic.Interfaces
{
    public interface IService
    {
        List<ServiceViewModel> GetList();

        List<ServiceViewModel> GetFilteredList();

        ServiceViewModel GetElement(int id);

        void AddElement(ServiceBindingModel model);

        void UpdateElement(ServiceBindingModel model);

        void DeleteElement(int id);
    }
}
