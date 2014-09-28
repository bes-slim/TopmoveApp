using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;
using TopMove.Lettings.Accounts.Data;


namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IContainer Container
        {
            get { return (IContainer) HttpContext.Current.Items["_Container"]; }
            set
            {
                HttpContext.Current.Items["_Container"] = value;
            }
        }
        protected void Application_Start()
        {
            EFConfig.Initialize();

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DependencyResolver.SetResolver(new StructureMapDependencyResolver(()=> Container ?? ObjectFactory.Container));

            

            //ObjectFactory.Configure(cfg =>
            //{
                
            //    cfg.AddRegistry(new StandardRegistry());
            //    cfg.AddRegistry(new ControllerRegistry());
            //    cfg.AddRegistry(new ActionFilterRegistry(
            //        () => Container ?? ObjectFactory.Container));
            //    cfg.AddRegistry(new MvcRegistry());
            //});

        }

        public void Application_BeginRequest()
        {
           // Container = ObjectFactory.Container.GetNestedContainer();
        }
    }
}
