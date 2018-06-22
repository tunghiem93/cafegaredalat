using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Entity.Initialization
{
    public class HierarchySection : ConfigurationSection
    {
        // Declare the Modules collection property.
        [ConfigurationProperty("Employees", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(EmployeeCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public EmployeeCollection Employees
        {
            get
            {
                EmployeeCollection employeeCollection =
                    (EmployeeCollection)base["Employees"];
                return employeeCollection;
            }
            set
            {
                EmployeeCollection employeeCollection = value;
            }
        }
    }
}
