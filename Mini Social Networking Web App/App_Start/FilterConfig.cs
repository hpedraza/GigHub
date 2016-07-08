using System.Web;
using System.Web.Mvc;

namespace Mini_Social_Networking_Web_App
{
    public class FilterConfig
    {
        //comiit 
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
