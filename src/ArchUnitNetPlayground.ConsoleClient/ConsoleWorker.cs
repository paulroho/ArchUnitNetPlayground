using System;

namespace ArchUnitNetPlayground.ConsoleClient;

public class ConsoleWorker {
    private readonly IFacade _facade;

    public ConsoleWorker(IFacade facade) {
        _facade = facade;
    }

    public Task ExecuteAsync(CancellationToken ct = default) {
        Console.WriteLine(_facade.Message);
        return Task.CompletedTask;
    }
}