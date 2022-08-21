using ArchUnitNetPlayground.Core.MainComponent;
using ArchUnitNetPlayground.Core.MainComponent.Ports;
using ArchUnitNetPlayground.Core.MessageHandling;
using ArchUnitNetPlayground.Core.MessageHandling.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace ArchUnitNetPlayground.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddArchUnitNetPlaygroundCore(this IServiceCollection services)
        {
            services.AddTransient<MessageProvider>();
            services.AddTransient<IMessageProvider, MessageProvider>();
            services.AddTransient<IFacade, Facade>();

            return services;
        }
    }
}
