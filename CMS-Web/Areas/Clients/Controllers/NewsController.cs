﻿using CMS_DTO.CMSNews;
using CMS_Shared;
using CMS_Shared.CMSCategories;
using CMS_Shared.CMSCompanies;
using CMS_Shared.CMSNews;
using CMS_Shared.CMSProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Web.Areas.Clients.Controllers
{
    public class NewsController : Controller
    {
        private CMSNewsFactory _fac;
        private CMSCategoriesFactory _facCate;
        private CMSProductFactory _facPro;
        private CMSCompaniesFactory _facCom;
        public NewsController()
        {
            _fac = new CMSNewsFactory();
            _facCate = new CMSCategoriesFactory();
            _facPro = new CMSProductFactory();
            _facCom = new CMSCompaniesFactory();
        }
        // GET: Clients/News
        public ActionResult Index()
        {
            var model = new CMS_NewsViewModel();
            var data = _fac.GetList().OrderByDescending(x=>x.CreatedDate).ToList();
            if(data != null)
            {
                data.ForEach(x =>
                {
                    x.ImageURL = Commons.HostImage + "News/" + x.ImageURL;
                });

                model.ListNews = data;
                model.ListNewsNew = data.OrderByDescending(x => x.CreatedDate).Skip(0).Take(5).ToList();
            }
            return View(model);
        }
        
        public ActionResult NewsDetail(string id)
        {
            var model = new CMS_NewsViewModel();
            try
            {
                if(string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("Index", "NotFound", new { area = "Clients" });
                }
                else
                {
                    var data = _fac.GetDetail(id);
                    if (data != null)
                    {
                        if(!string.IsNullOrEmpty(data.ImageURL))
                        {
                            data.ImageURL = Commons.HostImage + "News/" + data.ImageURL;
                        }
                    }

                    model.CMS_News = data;
                    model.ListNewsNew = _fac.GetList().OrderByDescending(x => x.CreatedDate).Skip(0).Take(2).ToList();
                    if (model.ListNewsNew != null && model.ListNewsNew.Any())
                    {
                        model.ListNewsNew.ForEach(x =>
                        {
                            if (!string.IsNullOrEmpty(x.ImageURL))
                            {
                                x.ImageURL = Commons.HostImage + "News/" + x.ImageURL;
                            }
                            else
                            {
                                x.ImageURL = Commons.Image870_500;
                            }
                        });
                    }
                    //For categories
                    model.ListCate = _facCate.GetList().OrderByDescending(x => x.CreatedDate).Skip(0).Take(5).ToList();
                    if (model.ListCate != null)
                    {
                        model.ListCate.ForEach(x =>
                        {
                            if (!string.IsNullOrEmpty(x.ImageURL))
                            {
                                x.ImageURL = Commons.HostImage + "News/" + x.ImageURL;
                            }
                            else
                            {
                                x.ImageURL = Commons.Image870_500;
                            }
                        });
                    }
                    //For Product
                    model.ListProduct = _facPro.GetList().OrderByDescending(x => x.CreatedDate).Skip(0).Take(5).ToList();
                    if (model.ListProduct != null)
                    {
                        model.ListProduct.ForEach(x =>
                        {
                            if (!string.IsNullOrEmpty(x.ImageURL))
                            {
                                x.ImageURL = Commons.HostImage + "News/" + x.ImageURL;
                            }
                            else
                            {
                                x.ImageURL = Commons.Image870_500;
                            }
                        });
                    }
                    //For company infor
                    model.CompanyInfor = _facCom.GetInfor();
                    if (model.CompanyInfor == null)
                        model.CompanyInfor = new CMS_DTO.CMSCompany.CMS_CompanyModels();
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "NotFound", new { area = "Clients" });
            }
            return View(model);
        }
    }
}