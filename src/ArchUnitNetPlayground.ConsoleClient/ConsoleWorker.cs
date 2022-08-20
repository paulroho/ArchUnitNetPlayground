using System;

namespace ArchUnitNetPlayground.ConsoleClient;

public class ConsoleWorker {
    public Task ExecuteAsync(CancellationToken ct = default) {
        Console.WriteLine("Hello World from " + GetType());
        return Task.CompletedTask;
    }
}