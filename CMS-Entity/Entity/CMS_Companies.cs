using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Entity.Entity
{
    public class CMS_Companies : CMS_EntityBase
    {
        public string Id { get; set; }
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
        public string BusinessHour { get; set; }
    }
}
