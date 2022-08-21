using ArchUnitNetPlayground.Core.MessageHandling.Ports;

namespace ArchUnitNetPlayground.Core.MessageHandling;

public class MessageProvider : IMessageProvider
{
    public string GetMessage() => $"Message from {GetType().Name}";
}