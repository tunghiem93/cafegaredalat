using CMS_Web.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Web.Areas.Admin.Controllers
{
    [NuAuth]
    public class CMSCustomersController : Controller
    {
        // GET: Admin/CMSCustomers
        public ActionResult Index()
        {
            return View();
        }
    }
}