
using Api.Extensions;
using Business.Interfaces;
using Business.Notificacoes;
using Business.Services;
using Data.Context;
using Data.Repository;

namespace Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Extensions
            services.AddScoped<RabbitMQProducer>();

            // Data
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();


            // Business
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<INotificador, Notificador>();

            // User
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}
