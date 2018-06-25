using CMS_DTO.CMSNews;
using CMS_Entity;
using CMS_Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Shared.CMSNews
{
    public class CMSNewsFactory
    {
        public bool CreateOrUpdate(CMS_NewsModels model, ref string msg)
        {
            var Result = true;
            using (var cxt = new CMS_Context())
            {
                using (var trans = cxt.Database.BeginTransaction())
                {
                    try
                    {
                        if (string.IsNullOrEmpty(model.Id))
                        {
                            var _Id = Guid.NewGuid().ToString();
                            var e = new CMS_News
                            {
                                Id = _Id,
                                Title = model.Title,
                                Short_Description = model.Short_Description,
                                ImageURL = model.ImageURL,
                                CreatedBy = model.CreatedBy,
                                CreatedDate = DateTime.Now,
                                Description = model.Description,
                                UpdatedBy = model.UpdatedBy,
                                UpdatedDate = DateTime.Now,
                                IsActive = model.IsActive
                            };
                            cxt.CMS_News.Add(e);
                        }
                        else
                        {
                            var e = cxt.CMS_News.Find(model.Id);
                            if (e != null)
                            {
                                e.Title = model.Title;
                                e.Short_Description = model.Short_Description;
                                e.ImageURL = model.ImageURL;
                                e.Description = model.Description;
                                e.UpdatedBy = model.UpdatedBy;
                                e.UpdatedDate = DateTime.Now;
                                e.IsActive = model.IsActive;
                            }
                        }
                        cxt.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        Result = false;
                        msg = "Vui lòng kiểm tra đường truyền";
                        trans.Rollback();
                    }
                    finally
                    {
                        cxt.Dispose();
                    }
                }
            }
            return Result;
        }

        public bool Delete(string Id, ref string msg)
        {
            var Result = true;
            using (var cxt = new CMS_Context())
            {
                using (var trans = cxt.Database.BeginTransaction())
                {
                    try
                    {
                        var e = cxt.CMS_News.Find(Id);
                        if (e != null)
                        {
                            cxt.CMS_News.Remove(e);
                            cxt.SaveChanges();
                            trans.Commit();
                        }
                        else
                        {
                            msg = "Vui lòng kiểm tra đường truyền";
                        }
                    }
                    catch (Exception)
                    {
                        Result = false;
                        msg = "Vui lòng kiểm tra đường truyền";
                        trans.Rollback();
                    }
                    finally
                    {
                        cxt.Dispose();
                    }
                }
            }
            return Result;
        }

        public CMS_NewsModels GetDetail(string Id)
        {
            try
            {
                using (var cxt = new CMS_Context())
                {
                    var item = cxt.CMS_News.Where(x => x.Id.Equals(Id)).FirstOrDefault();
                    if (item != null)
                    {
                        var o = new CMS_NewsModels
                        {
                            Id = item.Id,
                            CreatedBy = item.CreatedBy,
                            CreatedDate = item.CreatedDate,
                            Description = item.Description,
                            IsActive = item.IsActive,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedDate = item.UpdatedDate,
                            Title = item.Title,
                            Short_Description = item.Short_Description,
                            ImageURL = item.ImageURL
                        };

                        /* update empID */
                        var lstEmp = cxt.CMS_Employees.Where(e => e.Id == o.CreatedBy || e.Id == o.UpdatedBy).ToList();
                        o.CreatedBy = lstEmp.Where(e => e.Id == o.CreatedBy).Select(e => e.FirstName + " " + e.LastName).FirstOrDefault();
                        o.UpdatedBy = lstEmp.Where(e => e.Id == o.UpdatedBy).Select(e => e.FirstName + " " + e.LastName).FirstOrDefault();

                        return o;
                    }
                }
            }
            catch (Exception ex) { }
            return null;
        }

        public List<CMS_NewsModels> GetList()
        {
            try
            {
                using (var cxt = new CMS_Context())
                {
                    var data = cxt.CMS_News
                        .Join(cxt.CMS_Employees, n=> n.CreatedBy, e=> e.Id, (n,c)=> new { n, c })
                        .Join(cxt.CMS_Employees, n=> n.n.UpdatedBy, m=> m.Id, (n,m)=> new { n.n, n.c, m})
                        .Select(x => new CMS_NewsModels
                        {
                            Id = x.n.Id,
                            Title = x.n.Title,
                            Short_Description = x.n.Short_Description,
                            ImageURL = x.n.ImageURL,
                            CreatedBy = x.c.FirstName + " " + x.c.LastName,
                            CreatedDate = x.n.CreatedDate,
                            Description = x.n.Description,
                            IsActive = x.n.IsActive,

                            UpdatedBy = x.m.FirstName + " " + x.m.LastName,
                            UpdatedDate = x.n.UpdatedDate,
                        }).ToList();
                    return data;
                }
            }
            catch (Exception) { }
            return null;
        }
    }
}
