using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace KasperskyTask.Forms
{
    class KasperskyDownloadsForm : Form
    {
        private ITextBox EmailTextBox => ElementFactory.GetTextBox(By.XPath("//input[@data-at-selector='emailInput']"), "Email");
        private IButton SubmitSendToEmailBtn => ElementFactory.GetButton(By.XPath("//button[@data-at-selector='installerSendSelfBtn']"), "Submit send to email");
        public string Email => EmailTextBox.Value;

        public KasperskyDownloadsForm() : base(By.XPath("//div[@data-at-selector='downloadBlockPurchasedApps']"), "Available platforms container")
        {
        }

        public KasperskyDownloadsForm SelectOS(string osName)
        {
            IButton selectOSBtn = ElementFactory.GetButton(By.XPath($"//div[@data-at-selector='osName' and contains(text(), '{osName}')]"), "Select OS");
            selectOSBtn.Click();
            return this;
        }

        public void ClickSendToEmail(string productName)
        {
            string locator = $"//div[@data-at-selector='serviceName' and contains(text(), '{productName}')]//following::button[@data-at-selector='appInfoSendToEmail']";
            IButton sendToEmailBtn = ElementFactory.GetButton(By.XPath(locator), "Send to email");
            sendToEmailBtn.Click();
        }

        public void SubmitSendingToEmail() => SubmitSendToEmailBtn.WaitAndClick();
    }
}