namespace WikiMusic.Services
{
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ////RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.Configure();
        }
    }
}
