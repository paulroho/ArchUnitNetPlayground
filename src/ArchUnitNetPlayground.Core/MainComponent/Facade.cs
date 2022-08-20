namespace ArchUnitPlayground.Core;

public class Facade : IFacade {
    public string Message => "Hello from " + GetType();
}