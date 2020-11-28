using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;
using Sale.Autofac;

namespace Sale
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            //позволяет делать предобработку перед выполнением запросов
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //настройка маршрутизации (сопоставление url, по которым идут запросы с методами контроллеров)
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Файлы ресурсов, которые отправляются клиенту
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Удаляем формат xml из списка форматов в которые сериализуется ответ клиенту (чтобы работать с json-ом)
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            //Указываем что все свойства объектов классов сервера переводятся в нотацию camel при передаче на клиент
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //Настройка автофака
            AutofacConfig.ConfigureContainer();
            
        }
    }
}