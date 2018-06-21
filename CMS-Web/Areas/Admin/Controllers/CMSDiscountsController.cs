using CMS_Web.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Web.Areas.Admin.Controllers
{
    [NuAuth]
    public class CMSDiscountsController : Controller
    {
        // GET: Admin/CMSDiscounts
        public ActionResult Index()
        {
            return View();
        }
    }
}