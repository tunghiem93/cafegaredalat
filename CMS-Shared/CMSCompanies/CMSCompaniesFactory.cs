using CMS_DTO.CMSCompany;
using CMS_Entity;
using CMS_Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Shared.CMSCompanies
{
    public class CMSCompaniesFactory
    {
        public bool CreateOrUpdate(CMS_CompanyModels model, ref string msg)
        {
            var result = true;
            using (var cxt = new CMS_Context())
            {
                using (var trans = cxt.Database.BeginTransaction())
                {
                    try
                    {
                        if (string.IsNullOrEmpty(model.ID))
                        {
                            var e = new CMS_Companies
                            {
                                Id = Guid.NewGuid().ToString(),
                                Name = model.Name,
                                Description = model.Description,
                                Email = model.Email,
                                Phone = model.Phone,
                                Address = model.Address,
                                LinkBlog = model.LinkBlog,
                                LinkTwiter = model.LinkTwiter,
                                LinkInstagram = model.LinkInstagram,
                                LinkFB = model.LinkFB,
                                ImageURL = model.ImageURL,
                                IsActive = true,
                                BusinessHour = model.Businesshour,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = DateTime.Now,
                                UpdatedBy = model.UpdatedBy,
                                UpdatedDate = DateTime.Now
                            };
                            cxt.CMS_Companies.Add(e);
                        }
                        else
                        {
                            var e = cxt.CMS_Companies.Find(model.ID);
                            if (e != null)
                            {
                                e.Name = model.Name;
                                e.Description = model.Description;
                                e.Email = model.Email;
                                e.Phone = model.Phone;
                                e.Address = model.Address;
                                e.LinkBlog = model.LinkBlog;
                                e.LinkTwiter = model.LinkTwiter;
                                e.LinkInstagram = model.LinkInstagram;
                                e.LinkFB = model.LinkFB;
                                //e.ImageURL = model.ImageURL;
                                e.IsActive = true;
                                e.BusinessHour = model.Businesshour;
                                e.UpdatedBy = model.UpdatedBy;
                                e.UpdatedDate = DateTime.Now;
                            }
                            if (!string.IsNullOrEmpty(model.ImageURL))
                                e.ImageURL = model.ImageURL;
                        }
                        cxt.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        trans.Rollback();
                        msg = "Lỗi đường truyền mạng";
                    }
                    finally
                    {
                        cxt.Dispose();
                    }
                }
            }
            return result;
        }

        public bool Delete(string Id, ref string msg)
        {
            var result = true;
            using (var cxt = new CMS_Context())
            {
                using (var trans = cxt.Database.BeginTransaction())
                {
                    try
                    {
                        var e = cxt.CMS_Companies.Find(Id);
                        cxt.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        msg = "Không thể xóa thể loại này";
                        trans.Rollback();
                    }
                    finally
                    {
                        cxt.Dispose();
                    }

                }
            }
            return result;
        }

        public CMS_CompanyModels GetDetail(string Id)
        {
            try
            {
                using (var cxt = new CMS_Context())
                {
                    var data = cxt.CMS_Companies.Where(x => x.Id.Equals(Id))
                                                .Select(x => new CMS_CompanyModels
                                                {
                                                    ID = x.Id,
                                                    Name = x.Name,
                                                    Description = x.Description,
                                                    Email = x.Email,
                                                    Phone = x.Phone,
                                                    Address = x.Address,
                                                    LinkBlog = x.LinkBlog,
                                                    LinkTwiter = x.LinkTwiter,
                                                    LinkInstagram = x.LinkInstagram,
                                                    LinkFB = x.LinkFB,
                                                    ImageURL = string.IsNullOrEmpty(x.ImageURL) ? "" : Commons.HostImage + x.ImageURL,
                                                    IsActive = true,
                                                    Businesshour = x.BusinessHour,
                                                    CreatedBy = x.CreatedBy,
                                                    CreatedDate = DateTime.Now,
                                                    UpdatedBy = x.UpdatedBy,
                                                    UpdatedDate = DateTime.Now
                                                }).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception ex) { }
            return null;
        }

        public List<CMS_CompanyModels> GetList()
        {
            try
            {
                using (var cxt = new CMS_Context())
                {
                    var data = cxt.CMS_Companies.Select(x => new CMS_CompanyModels
                    {
                        ID = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Email = x.Email,
                        Phone = x.Phone,
                        Address = x.Address,
                        LinkBlog = x.LinkBlog,
                        LinkTwiter = x.LinkTwiter,
                        LinkInstagram = x.LinkInstagram,
                        LinkFB = x.LinkFB,
                        ImageURL = string.IsNullOrEmpty(x.ImageURL) ? "" : Commons.HostImage + x.ImageURL,
                        IsActive = true,
                        Businesshour = x.BusinessHour,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = x.UpdatedBy,
                        UpdatedDate = DateTime.Now
                    }).ToList();
                    return data;
                }
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
