using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using ArchUnitNetPlayground.Core.MainComponent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchUnitNetPlayground.Core.Tests
{
    public class SampleTestFromDocu
    {
        private static readonly Architecture Architecture =
            new ArchLoader().LoadAssemblies(
                typeof(Facade).Assembly
            )
            .Build();

        private readonly IObjectProvider<IType> ExampleLayer =
            Types().That()
            .ResideInAssembly("ExampleAssembly")
            .As("Example Layer");

        private readonly IObjectProvider<Class> ExampleClasses =
            Classes().That()
            .ImplementInterface("IExampleInterface")
            .As("Example Classes");

        private readonly IObjectProvider<IType> ForbiddenLayer =
            Types().That()
            .ResideInNamespace("ForbiddenNamespace")
            .As("Forbidden Layer");

        private readonly IObjectProvider<Interface> ForbiddenInterfaces =
            Interfaces().That()
            .HaveFullNameContaining("forbidden")
            .As("Forbidden Interfaces");

        [Fact]
        public void SampleTest()
        {
            var exampleClassesShouldBeInExampleLayer =
                Classes().That()
                .Are(ExampleClasses)
                .Should().Be(ExampleLayer);

            var forbiddenInterfacesShouldBeInForbiddenLayer =
                Interfaces().That()
                .Are(ForbiddenInterfaces)
                .Should().Be(ForbiddenLayer);

            //check if your architecture fulfills your rules
            exampleClassesShouldBeInExampleLayer.Check(Architecture);
            forbiddenInterfacesShouldBeInForbiddenLayer.Check(Architecture);

            //you can also combine your rules
            var combinedArchRule =
                exampleClassesShouldBeInExampleLayer
                .And(forbiddenInterfacesShouldBeInForbiddenLayer);

            combinedArchRule.Check(Architecture);
        }
    }
}
