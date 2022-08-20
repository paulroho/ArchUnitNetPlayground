using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using ArchUnitNetPlayground.Core;

namespace ArchUnitNetPlayground.Core.Tests;

public class ArchitectureTestsPlayground
{
    private static readonly Architecture Architecture =
        new ArchLoader().LoadAssemblies(
            typeof(Facade).Assembly
        )
        .Build();

    [Fact]
    public void Test1()
    {

    }
}