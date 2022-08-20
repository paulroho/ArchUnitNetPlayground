namespace ArchUnitNetPlayground.Core;

public class Facade : IFacade {
    public string Message => "Hello from " + GetType();
}