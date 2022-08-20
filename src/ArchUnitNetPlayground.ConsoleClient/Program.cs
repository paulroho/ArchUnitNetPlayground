using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ArchUnitNetPlayground.ConsoleClient;
using ArchUnitNetPlayground.Core;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {
        services.AddTransient<ConsoleWorker>();
        services.AddTransient<IFacade, Facade>();
    })
    .Build();

var worker = host.Services.GetRequiredService<ConsoleWorker>();

await worker.ExecuteAsync();