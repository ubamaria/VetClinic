using System;
using System.Collections.Generic;
using System.Text;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.ViewModels;

namespace VetClinicBusinessLogic.Interfaces
{
    public interface IRecording
    {
        List<RecordingViewModel> Read(RecordingBindingModel model);
        void CreateOrUpdate(RecordingBindingModel model);
        void Delete(RecordingBindingModel model);
    }
}
