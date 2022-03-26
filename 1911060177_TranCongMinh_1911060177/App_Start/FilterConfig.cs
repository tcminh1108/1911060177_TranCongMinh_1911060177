using System.Web;
using System.Web.Mvc;

namespace _1911060177_TranCongMinh_1911060177
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
