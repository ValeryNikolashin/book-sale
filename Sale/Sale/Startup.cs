using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Sale.Startup))]
namespace Sale
{
    /// <summary>
    /// Класс позволяющий задействовать функциональность библиотеки SignalR
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Даёт понять серверу что все создаваемые хабы должны быть доступны любому клиенту.
            app.MapSignalR();
        }
    }
}