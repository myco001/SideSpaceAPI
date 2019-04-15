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
            String conn_string = "server=sidespacedbv1.cjvk3kpipmcv.ap-southeast-2.rds.amazonaws.com;port=3306;database=ssdbv1;username=ghost;password=monashie;";
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
