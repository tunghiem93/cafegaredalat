using CMS_DTO.CMSCompany;
using CMS_Shared.CMSCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Web.Areas.Clients.Controllers
{
    public class ContactController : Controller
    {
        private CMSCompaniesFactory _facComInfo;

        public ContactController()
        {
            _facComInfo = new CMSCompaniesFactory();
        }

        // GET: Clients/Contact
        public ActionResult Index()
        {
            CMS_CompanyModels model = new CMS_CompanyModels();
            model = _facComInfo.GetInfor();
            return View(model);
        }
    }
}