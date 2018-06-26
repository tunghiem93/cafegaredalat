using CMS_DTO.CMSProduct;
using CMS_DTO.CMSSession;
using CMS_Shared;
using CMS_Shared.CMSCategories;
using CMS_Shared.CMSCompanies;
using CMS_Shared.CMSEmployees;
using CMS_Shared.CMSNews;
using CMS_Shared.CMSProducts;
using CMS_Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Web.Areas.Clients.Controllers
{
    public class ProductController : HQController
    {
        private CMSProductFactory _fac;
        public ProductController()
        {
            _fac = new CMSProductFactory();
        }
        // GET: Clients/Home
        public ActionResult Index(string id="")
        {
            try
            {
                ProductViewModels model = new ProductViewModels();
                
                //Product
                if(string.IsNullOrEmpty(id))
                {
                    model.ListProduct = _fac.GetList().OrderByDescending(x => x.CreatedDate).ToList();
                }
                else
                {
                    model.ListProduct = _fac.GetList().Where(x => x.CategoryId.Equals(id)).OrderByDescending(x => x.CreatedDate).ToList();
                }
                
                var dataImage = _fac.GetListImage();
                if(model.ListProduct != null && model.ListProduct.Any())
                {
                    model.ListProduct.ForEach(x =>
                    {
                        var _Image = dataImage.FirstOrDefault(z => z.ProductId.Equals(x.Id));
                        if(_Image != null)
                        {
                            x.ImageURL = _Image.ImageURL;
                            if (!string.IsNullOrEmpty(x.ImageURL))
                            {
                                x.ImageURL = "~/Uploads/Products/" + x.ImageURL;
                            }
                            else
                            {
                                x.ImageURL = "";
                            }
                        }
                    });
                }
                return View(model);
            }
            catch (Exception ex)
            {
               // NSLog.Logger.Error("Index: ", ex);
                return new HttpStatusCodeResult(400, ex.Message);
            }
        }
    }
}