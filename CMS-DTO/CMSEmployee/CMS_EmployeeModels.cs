﻿using CMS_DTO.CMSBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace CMS_DTO.CMSEmployee
{
    public class CMS_EmployeeModels : CMS_BaseModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [MaxLength(50, ErrorMessage = "Họ tên tối đa 50 kí tự")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [MaxLength(20, ErrorMessage = "Tên tối đa 20 kí tự")]
        public string LastName { get; set; }
        public string Employee_Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập sđt")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Vui lòng nhập số")]
        public string Employee_Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập e-mail")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail không hợp lệ")]
        public string Employee_Email { get; set; }
        public string Employee_IDCard { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string sStatus { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public bool IsSupperAdmin { get; set; }
        public int Level { get; set; }

        [MaxLength(100, ErrorMessage = "Tên tối đa 100 kí tự")]
        public string Position { get; set; }
        public string LinkPinterest { get; set; }
        public string LinkFB { get; set; }
        public string LinkTwiter { get; set; }
        public string LinkInstagram { get; set; }
        public CMS_EmployeeModels()
        {
            IsActive = true;
            BirthDate = new DateTime(1990, 01, 01);
        }
    }
}
