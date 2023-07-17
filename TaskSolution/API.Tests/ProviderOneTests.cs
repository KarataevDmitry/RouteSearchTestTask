using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaskSolution.Tests.API.ProviderOne
{
    [TestClass]
    public class ProviderOneTests
    {
        HttpClient? client;
        WebApplicationFactory<Program>? app;
        [TestInitialize]
        public void TestInit()
        {
            app = new WebApplicationFactory<Program>();
            client = app.CreateClient();

        }
        [TestCleanup]
        public void TestCleanup()
        {
            app?.Dispose();
            client?.Dispose();
        }
        [TestMethod]
        public async Task HelloWorldTest()
        {

            var response = await client?.GetStringAsync("/weatherforecast");
            Assert.IsNotNull(response);

        }
        [TestMethod]
        public void GetAllRoutesTest()
        {
            var r = new RouteService()
        }
    }
}