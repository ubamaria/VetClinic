using System;
using System.Collections.Generic;
using System.Text;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.ViewModels;

namespace VetClinicBusinessLogic.Interfaces
{
    public interface IReception
    {
        List<ReceptionViewModel> Read(ReceptionBindingModel model);
        void CreateOrUpdate(ReceptionBindingModel model);
        void Delete(ReceptionBindingModel model);
    }
}
