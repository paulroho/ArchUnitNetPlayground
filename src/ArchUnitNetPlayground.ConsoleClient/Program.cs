using ArchUnitNetPlayground.ConsoleClient;
using ArchUnitNetPlayground.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<ConsoleWorker>();
        services.AddArchUnitNetPlaygroundCore();
    })
    .Build();

var worker = host.Services.GetRequiredService<ConsoleWorker>();

await worker.ExecuteAsync();