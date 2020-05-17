using System;
using System.Collections.Generic;
using System.Text;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.ViewModels;

namespace VetClinicBusinessLogic.Interfaces
{
    public interface IPet
    {
        List<PetViewModel> GetList();
        PetViewModel GetElement(int id);
        void AddElement(PetBindingModel model);
        void UpdateElement(PetBindingModel model);
        void DeleteElement(int id);
    }
}
