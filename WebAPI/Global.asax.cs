﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                    .PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
