
namespace Api.Domain.Configure
{ 
    using api.Domain.Repository.Interface.Usuario; 
    using api.Domain.Repository.Queryable.Usuario;
    using api.Domain.Repository.Interface.Message;
    using api.Domain.Repository.Queryable.Message;
    using Microsoft.Extensions.DependencyInjection;

    public class UserNativeInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterUserServices(services);
            RegisterRepositories(services);
            RegisterCommands(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        { 

            /* usuarios */
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IBotRepository, BotRepository>();
            services.AddScoped<IBotStatusRepository, BotStatusRepository>();
        }

        private static void RegisterUserServices(IServiceCollection services)
        {
        }

        private static void RegisterCommands(IServiceCollection services)
        {
        }
    }
}
