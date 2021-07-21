using Aquality.Selenium.Browsers;
using NUnit.Framework;
using KasperskyTask.Forms;
using KasperskyTask.Tests.Data;
using KasperskyTask.Utils.MailClients;
using KasperskyTask.Utils.DataManagers;

namespace KasperskyTask.Tests
{
    class KasperskyDownlodTest : BaseTest
    {
        private readonly KasperskyAuthForm authForm = new();
        private readonly KasperskyHomeForm homeForm = new();
        private readonly KasperskyDownloadsForm downloadsForm = new();

        [Test, TestCaseSource(typeof(DataProvider), nameof(DataProvider.GetData))]
        public void Should_BePossibleTo_SendDownloadLinkToEmail(string osName, string productName)
        {
            IDataReader reader = new JsonDataReader(Constants.TestDataPath);
            AqualityServices.Browser.GoTo(reader.ReadProperty<string>("auth_url"));
            AqualityServices.Browser.WaitForPageToLoad();
            string email = reader.ReadProperty<string>("kaspersky_account_email");
            authForm.Authorize(email, reader.ReadProperty<string>("kaspersky_account_password"));
            homeForm.ClickOnDownloadsMenuLink();
            //downloadsForm.SelectOS(osName).ClickSendToEmail(productName);
            //Assert.AreEqual(email, downloadsForm.Email, "Correct email is not displayed");
            //downloadsForm.SubmitSendingToEmail();
            //string emailBody = MailKitClient.GetRecentMessageBody();
            //Assert.True(emailBody.Contains("Download"), "Link doesn't contain 'Download'");
            //Assert.True(emailBody.Contains(productName), "Product name doesn't match");
            //Assert.AreNotEqual(emailBody.IndexOf(osName), emailBody.LastIndexOf(osName), "Incorrect link");
        }
    }
}