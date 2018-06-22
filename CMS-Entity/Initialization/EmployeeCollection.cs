using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Entity.Initialization
{
    public class EmployeeCollection : ConfigurationElementCollection
    {
        public EmployeeCollection() { }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EmployeeConfigElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((EmployeeConfigElement)element).Email;
        }

        public EmployeeConfigElement this[int index]
        {
            get
            {
                return (EmployeeConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public EmployeeConfigElement this[string Email]
        {
            get
            {
                return (EmployeeConfigElement)BaseGet(Email);
            }
        }

        public int IndexOf(EmployeeConfigElement module)
        {
            return BaseIndexOf(module);
        }

        public void Add(EmployeeConfigElement module)
        {
            BaseAdd(module);

            // Your custom code goes here.

        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);

            // Your custom code goes here.

        }

        public void Remove(EmployeeConfigElement module)
        {
            if (BaseIndexOf(module) >= 0)
            {
                BaseRemove(module.Email);
                // Your custom code goes here.
                Console.WriteLine("EmployeeCollection: {0}", "Removed collection element!");
            }
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);

            // Your custom code goes here.

        }

        public void Remove(string Email)
        {
            BaseRemove(Email);

            // Your custom code goes here.

        }

        public void Clear()
        {
            BaseClear();

            // Your custom code goes here.
            Console.WriteLine("EmployeeCollection: {0}", "Removed entire collection!");
        }

    }
}
