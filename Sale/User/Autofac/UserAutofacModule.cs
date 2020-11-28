using Autofac;
using Autofac.Integration.WebApi;
using User.IContracts;
using User.Processes;
using User.Services;
using Module = Autofac.Module;

namespace User.Autofac
{
    public class UserAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var ы = GetType().Assembly;
            //Регистрация контроллеров
            builder.RegisterApiControllers(GetType().Assembly);
            //Регистрация интерфейсов
            builder.RegisterType<UserBusiness>().As<IUserContract>();
            builder.RegisterType<IntegrationBusiness>().As<IIntegrationContract>();
            //регистрация классов
            builder.RegisterType<HubService>().AsSelf();
        }
    }
}