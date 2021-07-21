using Aquality.Selenium.Browsers;
using KasperskyTask.Forms;
using KasperskyTask.Utils.DataManagers;
using NUnit.Framework;

namespace KasperskyTask.Tests
{
    [TestFixture]
    class BaseTest
    {
        [SetUp]
        public void Before()
        {
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}
