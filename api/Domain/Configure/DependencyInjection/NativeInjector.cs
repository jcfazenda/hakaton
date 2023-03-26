namespace api.Domain.Configure
{
    using api;
    using api.Domain.Mapping;
    using api.Domain.Repository.Interface.Usuario;
    using api.Domain.Repository.Queryable.Usuario;
    using api.Domain.Repository.Interface.Message;
    using api.Domain.Repository.Queryable.Message;
    using Api.Domain.Configure;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;

    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {          
            services.AddSingleton<IRequestManager, InMemoryRequestManager>();
            Mapper.Initialize(x => x.ConfigureApplicationProfiles());
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            
            UserNativeInjection.RegisterServices(services);

            services.AddScoped<GRCContext>();


            /* usuarios */
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IBotRepository, BotRepository>();
            services.AddScoped<IBotStatusRepository, BotStatusRepository>();


            RegisterGenericsEventsDomain(services);
        }
        private static void RegisterGenericsEventsDomain(IServiceCollection services)
        {
            services.AddScoped<IHttpClientHelper, HttpClientHelper>();
        }
    }
}

