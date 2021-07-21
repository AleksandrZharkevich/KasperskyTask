using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace KasperskyTask.Forms
{
    class KasperskyAuthForm : Form
    {
        public ITextBox InputTextBox(string locator, string elementName) 
            => ElementFactory.GetTextBox(By.XPath($"//input[@data-at-selector='{locator}']"), $"{elementName}");
        public IButton SignInBtn => ElementFactory.GetButton(By.XPath("//button[@data-at-selector='welcomeSignInBtn']"), "Sign in");

        public KasperskyAuthForm() : base(By.XPath("//form[@data-at-selector='signInContent']"), "Login form")
        {
        }
        
        public void Authorize(string email, string password)
        {
            InputTextBox("emailInput", "Email").ClearAndType(email);
            InputTextBox("passwordInput", "Password").ClearAndType(password);
            SignInBtn.Click();
        }
    }
}
