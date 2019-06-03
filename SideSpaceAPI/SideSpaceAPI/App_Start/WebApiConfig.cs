using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace SideSpaceAPI
{
    public static class WebApiConfig
    {
        public static MySqlConnection conn()
        {
            String conn_string = "server=YOUR_DATABASE_ENDPOINT;port=PORT_NUMBER;database=DATABASE_NAME;username=YOURUSERNAME;password=YOURPASSWORD;";
            MySqlConnection conn = new MySqlConnection(conn_string);

            return conn;
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetApi",
                routeTemplate: "api/{controller}/{username}"
            );

            // Web API configuration and services  
            // config.Filters.Add(new RequireHttpsAttribute());

            var appXmlType = config.Formatters.XmlFormatter
                .SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
