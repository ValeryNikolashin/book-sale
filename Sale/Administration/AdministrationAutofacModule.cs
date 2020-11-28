using Administration.IContracts;
using Administration.Processes;
using Autofac;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace Administration
{
    public class AdministrationAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Регистрация контроллеров
            builder.RegisterApiControllers(GetType().Assembly);
            //Регистрация интерфейсов
            builder.RegisterType<AdministrationBusiness>().As<IAdministrationContract>();
        }
    }
}