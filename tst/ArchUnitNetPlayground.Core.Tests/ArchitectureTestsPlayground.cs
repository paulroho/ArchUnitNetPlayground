using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using ArchUnitNetPlayground.Core.MainComponent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchUnitNetPlayground.Core.Tests;

public class ArchitectureTestsPlayground
{
    private static readonly Architecture Architecture =
    new ArchLoader().LoadAssemblies(
        typeof(Facade).Assembly
    )
    .Build();

    [Fact]
    public void Only_ports_are_used_in_other_components()
    {
        var componentRootNamespace = typeof(ArchUnitNetPlayground.Core.MessageHandling.MessageProvider).Namespace ?? "";
        var componentRootNamespacePattern = $"^{componentRootNamespace.Replace(".", @"\.")}";
        var componentPortsNamespace = typeof(ArchUnitNetPlayground.Core.MessageHandling.Ports.IMessageProvider).Namespace ?? "";

        var messageHandlingNonPorts =
            Types().That()
            .ResideInNamespace(componentRootNamespacePattern, true)
            .And()
            .DoNotResideInNamespace(componentPortsNamespace);

        var classesOutsideMessageHandling =
            Classes().That()
            .DoNotResideInNamespace(componentRootNamespacePattern, true);

        var justPortsAreUsedFromOutsideOfComponentRule = classesOutsideMessageHandling
            .Should().NotDependOnAny(messageHandlingNonPorts);

        justPortsAreUsedFromOutsideOfComponentRule.Check(Architecture);

    }
}