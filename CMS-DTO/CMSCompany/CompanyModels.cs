using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMS_DTO.CMSCompany
{
    public class CompanyModels
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string LinkBlog { get; set; }
        public string LinkFB { get; set; }
        public string LinkTwiter { get; set; }
        public string LinkInstagram { get; set; }
        public string ImageURL { get; set; }
        public bool IsActive { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase PictureUpload { get; set; }
        public byte[] PictureByte { get; set; }
        //[Required(ErrorMessage = "Làm ơn nhập họ!")]
        //public string FirstName { get; set; }


        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public CompanyModels()
        {
            IsActive = true;
            UpdatedDate = DateTime.Now;
            CreatedDate = DateTime.Now;
        }
    }
}
