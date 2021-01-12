using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace com.automationpractice
{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        [FindsBy(How = How.XPath, Using = "//a[@class='login']")]
        public IWebElement SignInBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='email_create']")]
        public IWebElement EmailAddressTextBox;

        [FindsBy(How = How.CssSelector, Using = "#SubmitCreate")]
        public IWebElement CreateAnAccountBtn;

        [FindsBy(How = How.Id, Using = "search_query_top")]
        public IWebElement Search;

        public void RegisterEmail(string email)
        {
            SignInBtn.Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement emailBox = wait.Until(e => e.FindElement(By.CssSelector("#email_create")));

            EmailAddressTextBox.SendKeys(email);

            CreateAnAccountBtn.Click();
        }
       
    
    }
}
