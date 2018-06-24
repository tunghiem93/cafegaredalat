using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMS_DTO.CMSBase
{
    public class CMS_BaseModel
    {
        [DataType(DataType.Upload)]
        public HttpPostedFileBase PictureUpload { get; set; }

        public byte[] PictureByte { get; set; }
        public string ImageURL { get; set; }
    }

    public class CategoryByCategory
    {
        public string id { get; set; }
        public string text { get; set; }
        public List<CategoryChildren> children { get; set; }
        public CategoryByCategory()
        {
            children = new List<CategoryChildren>();
        }
    }
    public class CategoryChildren
    {
        public string id { get; set; }
        public string text { get; set; }
    }
}
