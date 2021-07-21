using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace KasperskyTask.Forms
{
    class KasperskyHomeForm : Form
    {
        private ILink DownloadsLink(string name) => ElementFactory.GetLink(By.XPath($"//a[@data-at-menu='{name}']"), "Downloads link");

        public KasperskyHomeForm() : base(By.XPath("//div[@data-at-selector='news']"), "News box")
        {
        }

        public void ClickOnDownloadsMenuLink() => DownloadsLink("Downloads").Click();
    }
}
