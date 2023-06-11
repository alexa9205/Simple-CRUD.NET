using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebAPI
{
    //public class WebApiApplication : System.Web.HttpApplication
    //{
    //    protected void Application_Start()
    //    {
    //        GlobalConfiguration.Configure(WebApiConfig.Register);
    //    }
    //}
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Registro de la configuración de Web API
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }

}
