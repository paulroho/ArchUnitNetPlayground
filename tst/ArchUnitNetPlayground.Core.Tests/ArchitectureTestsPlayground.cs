using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using ArchUnitNetPlayground.Core.MainComponent;
using Xunit.Abstractions;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchUnitNetPlayground.Core.Tests;

public class ArchitectureTestsPlayground
{
    private static readonly Architecture Architecture =
    new ArchLoader().LoadAssemblies(
        typeof(Facade).Assembly
    )
    .Build();
    private readonly ITestOutputHelper testOutputHelper;

    public ArchitectureTestsPlayground(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Only_ports_are_used_in_other_components()
    {
        var componentRootNamespace = typeof(ArchUnitNetPlayground.Core.MessageHandling.MessageProvider).Namespace ?? "";
        var componentRootNamespacePattern = $"^{componentRootNamespace.Replace(".", @"\.")}";
        var componentPortsNamespace = componentRootNamespace + ".Ports";

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

        var results = justPortsAreUsedFromOutsideOfComponentRule.Evaluate(Architecture);
        foreach (var result in results)
        {
            testOutputHelper.WriteLine((result.Passed ? "OK" : "!!"));
            testOutputHelper.WriteLine(result.Description);
            testOutputHelper.WriteLine(result.ArchRule.Description);
        }

        justPortsAreUsedFromOutsideOfComponentRule.Check(Architecture);
    }
}