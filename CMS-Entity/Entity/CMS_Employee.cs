using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Entity.Entity
{
    public partial class CMS_Employee  : CMS_EntityBase
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Level { get; set; }
        public string Employee_Address { get; set; }
        public string Employee_Phone { get; set; }
        public string Employee_Email { get; set; }
        public string Employee_IDCard { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string LinkBlog { get; set; }
        public string LinkFB { get; set; }
        public string LinkTwiter { get; set; }
        public string LinkInstagram { get; set; }
        public string ImageURL { get; set; }
        public bool IsSupperAdmin { get; set; }

    }
}
