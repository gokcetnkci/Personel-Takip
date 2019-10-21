using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PersonelMVC
{
    public class RouteConfig
    {
        private static object namespaces;

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            routes.MapRoute("Departman", "", new { controller = "Departman", action = "Index"});
            routes.MapRoute("Guncelle", "guncelle/{id}", new { controller = "Departman", action = "Guncelle", id = UrlParameter.Optional }, namespaces);
            routes.MapRoute("Sil", "sil/{id}", new { controller = "Departman", action = "Sil", id = UrlParameter.Optional }, namespaces);
            routes.MapRoute("Yeni", "yeni/{id}", new { controller = "Departman", action = "Kaydet", id = UrlParameter.Optional }, namespaces);
            routes.MapRoute("Personel", "personel", new { controller = "Personel", action = "Index" }, namespaces);
            routes.MapRoute("YeniPersonel", "kayit/{id}", new { controller = "Personel", action = "Kaydet", id = UrlParameter.Optional }, namespaces);
            routes.MapRoute("PersonelGuncelle","update/{id}", new {controller = "Personel", action = "update", id = UrlParameter.Optional }, namespaces);
            routes.MapRoute("PersonelSil", "delete/{id}", new { controller = "Personel", action = "delete", id = UrlParameter.Optional }, namespaces);
        }
    }
}
