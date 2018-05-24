using NUnit.Framework;

namespace AddressBookTest_White_New
{
    class TestBase
    {
        protected ApplicationManager app;

        [OneTimeSetUp]
        public void InitApplication()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void StopApplication()
        {
            app.Stop();
        }
    }
}
