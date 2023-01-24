using Autofac;
using Autofac.Integration.WebApi;
using CarTracker.Model;
using CarTracker.Model.Common;
using CarTracker.Repository;
using CarTracker.Repository.Common;
using CarTracker.Service;
using CarTracker.Service.Common;
using CarTracker.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
//using System.Reflection;

namespace CarTracker.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();

            builder.RegisterType<CarController>().AsSelf();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<RepositoryModule>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}