using ArchUnitNetPlayground.Core.MainComponent.Ports;
using ArchUnitNetPlayground.Core.MessageHandling.Ports;

namespace ArchUnitNetPlayground.Core.MainComponent;

public class Facade : IFacade
{
	private readonly IMessageProvider messageProvider;

	public Facade(IMessageProvider messageProvider)
	{
		this.messageProvider = messageProvider;
	}

	public string Message => "Hello, the message is: " + this.messageProvider.GetMessage();
}