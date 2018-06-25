using CMS_DTO.CMSProduct;
using CMS_DTO.CMSSession;
using CMS_Shared;
using CMS_Shared.CMSCategories;
using CMS_Shared.CMSCompanies;
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
    public class HomeController : HQController
    {
        private CMSProductFactory _fac;
        private CMSCompaniesFactory _facCom;
        private CMSCategoriesFactory _facCate;
        private CMSNewsFactory _facNews;
        public HomeController()
        {
            _fac = new CMSProductFactory();
            _facCom = new CMSCompaniesFactory();
            _facCate = new CMSCategoriesFactory();
            _facNews = new CMSNewsFactory();
        }
        // GET: Clients/Home
        public ActionResult Index()
        {
            try
            {
                ProductViewModels model = new ProductViewModels();

                //Company
                model.Company = _facCom.GetList().FirstOrDefault();

                //Category
                model.ListCate = _facCate.GetList().OrderByDescending(x => x.CreatedDate).Skip(0).Take(4).ToList();
                if(model.ListCate != null && model.ListCate.Any())
                {
                    model.ListCate.ForEach(x =>
                   {
                       if(!string.IsNullOrEmpty(x.ImageURL))
                            x.ImageURL = "~/Uploads/Categories/" + x.ImageURL;
                   });
                }

                //Product
                model.ListProduct = _fac.GetList().OrderByDescending(x => x.CreatedDate).Skip(0).Take(8).ToList();
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

                //News
                model.ListNews = _facNews.GetList().OrderByDescending(x => x.CreatedDate).Skip(0).Take(3).ToList();
                if(model.ListNews != null && model.ListNews.Any())
                {
                    model.ListNews.ForEach(x =>
                    {
                        if (!string.IsNullOrEmpty(x.ImageURL))
                            x.ImageURL = "~/Uploads/News/" + x.ImageURL;
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

        [HttpPost]
        public ActionResult SearchKey(string Key = "")
        {
            var model = new ProductViewModels();

            var data = _fac.GetList()
                                    .Where(x => CommonHelper.RemoveUnicode(x.ProductName.ToLower()).Contains(CommonHelper.RemoveUnicode(Key.ToLower())))
                                    .OrderByDescending(x => x.CreatedDate)
                                                   .ToList();

            if (data != null && data.Any())
            {
                var dataImage = _fac.GetListImage();
                data.ForEach(x =>
                {
                    var _Image = dataImage.FirstOrDefault(y => y.ProductId.Equals(x.Id));
                    if (_Image != null)
                    {
                        if (!string.IsNullOrEmpty(_Image.ImageURL))
                            x.ImageURL = Commons.HostImage + "Products/" + _Image.ImageURL;
                    }
                });
                model.Key = Key;
                model.ListProduct = data.OrderByDescending(x => x.CreatedDate).Skip(0).Take(12).ToList();
                model.TotalProduct = data.Count;
                var pageIndex = 0;
                if (data.Count % 12 == 0)
                    pageIndex = data.Count / 12;
                else
                    pageIndex = Convert.ToInt16(data.Count / 12) + 1;

                if (pageIndex > 1)
                    model.TotalPage = 2;
                else
                    model.IsAddMore = true;
            }
            return PartialView("_ListItem", model);
        }

        public ActionResult Search()
        {
            var Key = Request.QueryString["search"];
            if (string.IsNullOrEmpty(Key))
                Key = "";
            var model = new ProductViewModels();

            var data = _fac.GetList()
                                    .Where(x => CommonHelper.RemoveUnicode(x.ProductName.ToLower()).Contains(CommonHelper.RemoveUnicode(Key.ToLower())))
                                    .OrderByDescending(x => x.CreatedDate)
                                                   .ToList();

            if (data != null && data.Any())
            {
                var dataImage = _fac.GetListImage();
                data.ForEach(x =>
                {
                    var _Image = dataImage.FirstOrDefault(y => y.ProductId.Equals(x.Id));
                    if (_Image != null)
                    {
                        if (!string.IsNullOrEmpty(_Image.ImageURL))
                            x.ImageURL = Commons.HostImage + "Products/" + _Image.ImageURL;
                    }
                });
                model.Key = Key;
                model.ListProduct = data.OrderByDescending(x => x.CreatedDate).Skip(0).Take(12).ToList();
                model.TotalProduct = data.Count;
                var pageIndex = 0;
                if (data.Count % 12 == 0)
                    pageIndex = data.Count / 12;
                else
                    pageIndex = Convert.ToInt16(data.Count / 12) + 1;

                if (pageIndex > 1)
                    model.TotalPage = 2;
                else
                    model.IsAddMore = true;
            }
            return View(model);
        }

        public ActionResult Detail(string id)
        {
            try
            {
                ProductDetailViewModels model = new ProductDetailViewModels();
                if (!string.IsNullOrEmpty(id))
                {
                    var dataDetail = _fac.GetDetail(id);
                    if (dataDetail != null)
                    {
                        dataDetail.ListImages = _fac.GetListImageOfProduct(id);
                        if (dataDetail.ListImages != null)
                        {
                            dataDetail.ListImages.ForEach(x =>
                            {
                                x.ImageURL = Commons.HostImage + "Products/" + x.ImageURL;
                            });
                        }
                        dataDetail.ListImages = dataDetail.ListImages.OrderBy(x => x.ImageURL).Skip(0).Take(4).ToList();

                        var oldData = _fac.GetList().Where(x => !x.Id.Equals(id) && x.CategoryId.Equals(dataDetail.CategoryId)).OrderBy(x => x.CreatedDate).Skip(0).Take(5).ToList();
                        if(oldData != null && oldData.Any())
                        {
                            var dataImage = _fac.GetListImage();
                            oldData.ForEach(x =>
                            {
                                var _Image = dataImage.FirstOrDefault(y => y.ProductId.Equals(x.Id));
                                if (_Image != null)
                                {
                                    if (!string.IsNullOrEmpty(_Image.ImageURL))
                                        x.ImageURL = Commons.HostImage + "Products/" + _Image.ImageURL;
                                }
                            });
                        }
                        
                        model.ListProduct = oldData;
                        model.Product = dataDetail;
                        return View(model);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //NSLog.Logger.Error("GetDetail: ", ex);
                return new HttpStatusCodeResult(400, ex.Message);
            }
        }

        public PartialViewResult LoadPagging(int pageIndex, string Id = "", string Key = "", bool isOrther = false)
        {
            ProductViewModels model = new ProductViewModels();
            var data = new List<CMS_ProductsModels>();
            if (!isOrther)
            {
                data = _fac.GetList().Where(z => (string.IsNullOrEmpty(Id) ? 1 == 1 : z.CategoryId.Equals(Id)) && (string.IsNullOrEmpty(Key) ? 1 == 1 : CommonHelper.RemoveUnicode(z.ProductName.ToLower()).Contains(CommonHelper.RemoveUnicode(Key.ToLower())))).ToList();
            }
            else
            {
                var ListCate = Session["Catelogies"] as List<CateSession>;
                if (ListCate != null && ListCate.Count < 9)
                {
                    data = _fac.GetList().OrderBy(x => x.ProductName).ToList();
                }
                else
                {
                    data = _fac.GetList().Where(x => ListCate.Select(z => z.Id).Contains(x.CategoryId)).OrderBy(x => x.ProductName).ToList();
                }
            }

            if (data != null && data.Any())
            {
                model.CateID = Id;
                model.Key = Key;
                model.IsOrther = isOrther;
                var dataImage = _fac.GetListImage();
                data.ForEach(x =>
                {
                    var _Image = dataImage.FirstOrDefault(y => y.ProductId.Equals(x.Id));
                    if (_Image != null)
                    {
                        if (!string.IsNullOrEmpty(_Image.ImageURL))
                            x.ImageURL = Commons.HostImage + "Products/" + _Image.ImageURL;
                    }
                });
                // model.ListProduct = model.ListProduct.OrderByDescending(x => x.CreatedDate).ToList();

                model.TotalProduct = data.Count;
                model.ListProduct = data.OrderByDescending(x => x.CreatedDate).Skip(0).Take(12 * pageIndex).ToList();
                var page = 0;
                if (data.Count % 12 == 0)
                    page = data.Count / 12;
                else
                    page = Convert.ToInt16(data.Count / 12) + 1;

                if (page > pageIndex)
                    model.TotalPage = pageIndex + 1;
                else
                {
                    model.IsAddMore = true;
                }

            }
            return PartialView("_ListItem", model);
        }
    }
}