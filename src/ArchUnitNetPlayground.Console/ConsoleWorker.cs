namespace ArchUnitNetPlayground.Console;

public class ConsoleWorker {
    public async Task ExecuteAsync(CancellationToken ct = default) {
        System.Console.WriteLine("Hello World from " + GetType());
    }
}