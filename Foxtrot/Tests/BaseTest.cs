using Foxtrot.Tests.DriverFactory;
using NUnit.Framework;

namespace Foxtrot.Tests
{
    public class BaseTest
    {
        public readonly ApplicationManaget app = new ApplicationManaget();

        [OneTimeSetUp]
        public void Start()
        {
            app.InitDriver(BrowserTypes.Chrome);
            app.InitHelpers();
        }

        [OneTimeTearDown]
        public void Finish()
        {
            app.QuitDriver();
        }
    }
}
