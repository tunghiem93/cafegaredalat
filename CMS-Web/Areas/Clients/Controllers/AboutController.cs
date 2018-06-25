using CMS_DTO.CMSProduct;
using CMS_Shared;
using CMS_Shared.CMSEmployees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Web.Areas.Clients.Controllers
{
    public class AboutController : Controller
    {
        private CMSEmployeeFactory _facEmp;
        public AboutController()
        {
            _facEmp = new CMSEmployeeFactory();
        }

        // GET: Clients/About
        public ActionResult Index()
        {
            ProductViewModels model = new ProductViewModels();
            // employee
            model.ListEmployee = _facEmp.GetList().OrderBy(x => x.Level).Skip(0).Take(4).ToList();
            if (model.ListEmployee != null && model.ListEmployee.Any())
            {
                model.ListEmployee.ForEach(x =>
                {
                    if (!string.IsNullOrEmpty(x.ImageURL))
                        x.ImageURL = "~/Uploads/Employees/" + x.ImageURL;
                    else
                        x.ImageURL = Commons.Image268_297;
                });
            }
            return View(model);
        }
    }
}