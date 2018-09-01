using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using LightInject;
using SnowCSharpTest.Services;

namespace SnowCSharpTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new ServiceContainer();
            container.RegisterApiControllers(typeof(SnowCSharpTest.WebApiApplication).Assembly);
            container.Register<IParser, ParserService>(new PerRequestLifeTime());

            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);



            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
