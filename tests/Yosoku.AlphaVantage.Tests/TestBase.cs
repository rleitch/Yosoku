using AutoFixture;

namespace Yosoku.AlphaVantage.Tests
{
    [TestClass]
#pragma warning disable MSTEST0016 // Test class should have test method
    public abstract class TestBase
#pragma warning restore MSTEST0016 // Test class should have test method
    {
        protected readonly Fixture _fixture = new();

        protected TestBase() => _fixture.Register(() => new DateOnly(2023, 1, 1));
    }
}