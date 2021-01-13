using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Andpol.Dane.Entities;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Web.Http.OData.Formatter;
using System.Web.Http.Cors;

namespace Andpol.Dane
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling=Newtonsoft.Json.DateTimeZoneHandling.Local;
            // config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter());




            config.MapHttpAttributeRoutes();
            
            config.EnableCors(new EnableCorsAttribute(origins:"*", headers: "*", methods:"*"));



            // Web API routes

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );


            config.Routes.MapHttpRoute(
                name: "WithAction",
                //routeTemplate: "api/{controller}/{action}/{id}"
                routeTemplate: "api/{controller}/{action}"
            );


        }
    }
}
