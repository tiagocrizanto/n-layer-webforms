using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using PatientManager.Infra.IoC;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace PatientManager.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var container = this.AddUnity();
            
            DomainServiceBootstrapper.Register(container);
            RepositoryBootstrapper.Register(container);

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}