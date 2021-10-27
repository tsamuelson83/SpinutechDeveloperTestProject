using SpinutechDeveloperTestProject.BusinessObjects;
using SpinutechDeveloperTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpinutechDeveloperTestProject.Controllers
{
    public class Exercise1Controller : Controller
    {
        // GET: Exercise1
        public ActionResult Index()
        {
            var model = new Excercise1ViewModel();
            model.showOutputValue = false;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Excercise1ViewModel vm)
        {
            var obj = new NumberStringifier(vm.InputStringVal);

            if (obj.Convert())
            {
                vm.showOutputValue = true;
                vm.StringifiedValue = obj.StringifiedValue;
            } else
            {
                vm.showErrorMessage = true;
                vm.errorMessage = obj.ErrorMessage;
            }
            return View(vm);
        }
    }
}