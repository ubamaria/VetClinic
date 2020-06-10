using System;
using System.Collections.Generic;
using System.Text;
using VetClinicBusinessLogic.ViewModels;

namespace VetClinicBusinessLogic.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ServiceViewModel> Services { get; set; }
    }
}
