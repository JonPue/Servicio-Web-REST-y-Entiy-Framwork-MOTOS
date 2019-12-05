using System.Web;
using System.Web.Mvc;

namespace Servicio_Web_REST_y_Entiy_Framwork_MOTOS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
