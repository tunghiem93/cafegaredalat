using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Shared
{
    public static class Commons
    {
        public const string Image100_50 = "http://placehold.it/100x50";
        public const string Image200_100 = "http://placehold.it/200x100";
        public const string Image272_259 = "http://placehold.it/272x259";
        public const string Image870_500 = "http://placehold.it/870x500";
        public const string Image400_340 = "http://placehold.it/400x340";
        public const string Image268_297 = "http://placehold.it/268x297";
        public const string Image370_238 = "http://placehold.it/370x238";

        public static int WidthProduct = Convert.ToInt16(ConfigurationManager.AppSettings["WidthProduct"]);
        public static int HeightProduct = Convert.ToInt16(ConfigurationManager.AppSettings["HeightProduct"]);
        public static int WidthCate = Convert.ToInt16(ConfigurationManager.AppSettings["WidthCate"]);
        public static int HeightCate = Convert.ToInt16(ConfigurationManager.AppSettings["HeightCate"]);

        public static int WidthEmp = Convert.ToInt16(ConfigurationManager.AppSettings["WidthEmp"]);
        public static int HeightEmp = Convert.ToInt16(ConfigurationManager.AppSettings["HeightEmp"]);

        public static int WidthImageNews = Convert.ToInt16(ConfigurationManager.AppSettings["WidthImageNews"]);
        public static int HeightImageNews = Convert.ToInt16(ConfigurationManager.AppSettings["HeightImageNews"]);
        public static int WidthImageSilder = Convert.ToInt16(ConfigurationManager.AppSettings["WidthImageSilder"]);
        public static int HeightImageSilder = Convert.ToInt16(ConfigurationManager.AppSettings["HeightImageSilder"]);
        public static string Phone1 = ConfigurationManager.AppSettings["Phone1"];
        public static string Phone2 = ConfigurationManager.AppSettings["Phone2"];
        public static string Email1 = ConfigurationManager.AppSettings["Email1"];
        public static string Email2 = ConfigurationManager.AppSettings["Email2"];
        public static string AddressCompany = ConfigurationManager.AppSettings["AddressCompnay"];
        public static string CompanyTitle = ConfigurationManager.AppSettings["CompanyTitle"];
        public static string HostImage = ConfigurationManager.AppSettings["HostImage"];
        public static string _PublicImages = string.IsNullOrEmpty(ConfigurationManager.AppSettings["PublicImages"]) ? "" : ConfigurationManager.AppSettings["PublicImages"];
    }
}
