using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace ClienteMVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração e serviços de API Web

            // Rotas de API Web

            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "GetClientePorNome",
            routeTemplate: "api/clientes/Search/{nome}",
            defaults: new { controller = "Clientes", action = "GetClientePorNome" }
              );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Clientes" }
            );

            

        }
    }
}
