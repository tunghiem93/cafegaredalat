using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CMS_DTO.CMSCompany
{
    public class CMS_CompanyModels
    {
        public string ID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
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
        public string Businesshour { get; set; }


        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public CMS_CompanyModels()
        {
            IsActive = true;
            UpdatedDate = DateTime.Now;
            CreatedDate = DateTime.Now;
            LinkBlog = "";
            LinkFB = "";
            LinkTwiter = "";
            LinkInstagram = "";
        }
    }
}
