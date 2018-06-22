using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CMS_Entity.Initialization
{
    public class HierarchyData : ConfigurationSection, IConfigurationSectionHandler
    {
        private static HierarchySection _hierarchy;

        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            if (section == null) return null;
            Type sectionType = Type.GetType((string)(section.CreateNavigator()).Evaluate("string(@configType)"));
            XmlSerializer xs = new XmlSerializer(sectionType);
            return xs.Deserialize(new XmlNodeReader(section));
        }

        public static HierarchySection HierarchyConfigs
        {
            get
            {
                if (_hierarchy == null)
                {
                    try
                    {
                        var configPath = HttpContext.Current.Server.MapPath(string.Format("~/{0}", "InitializationDb.config"));
                        var configFileMap = new ExeConfigurationFileMap();
                        configFileMap.ExeConfigFilename = configPath;

                        var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                        if (config != null)
                        {
                            _hierarchy = (HierarchySection)config.GetSection("hierarchySection");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                return _hierarchy;
            }
        }
    }

}
