using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpinutechDeveloperTestProject.Models
{
    public class Excercise1ViewModel
    {
        public string InputStringVal { get; set; }

        public string StringifiedValue { get; set; }

        public bool showOutputValue { get; set; }
        public bool showErrorMessage { get; set; }
        public string errorMessage { get; set; }
    }
}