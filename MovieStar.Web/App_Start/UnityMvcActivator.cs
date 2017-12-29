using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using MovieStar.Data.DAL;
using MovieStar.Data.DAL.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MovieStar.Web.App_Start.UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(MovieStar.Web.App_Start.UnityWebActivator), "Shutdown")]

namespace MovieStar.Web.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));

            // Register types
            container.RegisterType<DbContext, DataContext>(new PerRequestLifetimeManager(), new InjectionConstructor("connectionStringName"));
            //container.RegisterType<IMovieService, MovieService>();
            container.RegisterType<IMovieService, MovieServiceStub>();
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}