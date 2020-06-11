using System;
using System.Collections.Generic;
using System.Text;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.ViewModels;

namespace VetClinicBusinessLogic.Interfaces
{
    public interface IPet
    {
        List<PetViewModel> Read(PetBindingModel model);
        void CreateOrUpdate(PetBindingModel model);
        void Delete(PetBindingModel model);
    }
}
