using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Entity.Initialization
{

    public class EmployeeConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("Email", IsKey = true, IsRequired = true, DefaultValue = "Email")]
        public string Email
        {
            get { return (string)this["Email"]; }
            set { this["Email"] = value; }
        }
    }
}
