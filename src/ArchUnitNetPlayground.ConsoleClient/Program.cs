using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ArchUnitNetPlayground.ConsoleClient;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {
        services.AddTransient<ConsoleWorker>();
    })
    .Build();

var worker = host.Services.GetRequiredService<ConsoleWorker>();

await worker.ExecuteAsync();