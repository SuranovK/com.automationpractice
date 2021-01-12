using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
namespace com.automationpractice
{
    public class RegistrationPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        [FindsBy(How = How.CssSelector, Using = "#customer_firstname")]
        public IWebElement FirstName;

        [FindsBy(How = How.CssSelector, Using = "#customer_lastname")]
        public IWebElement LastName;

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement Email;

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement Password;

        [FindsBy(How = How.CssSelector, Using = "#address1")]
        public IWebElement Address;

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement City;

        [FindsBy(How = How.Id, Using = "id_state")]
        public IWebElement State;

        [FindsBy(How = How.Id, Using = "postcode")]
        public IWebElement ZipCode;

        [FindsBy(How = How.Id, Using = "id_country")]
        public IWebElement Country;

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        public IWebElement MobilePhone;

        [FindsBy(How = How.Id, Using = "alias")]
        public IWebElement AliasAddress;

        [FindsBy(How = How.Id, Using = "submitAccount")]
        public IWebElement RegisterBtn;

        [FindsBy(How = How.XPath, Using = "//a[@class='account']")]
        public IWebElement CurrentUsername;





        public void FillOutRegistrationForm(string email, string name, string lastName, string password, string address, string city, string state, string zip, string mobileNumber, string aliasAddress, string country)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement emailBox = wait.Until(e => e.FindElement(By.CssSelector("#customer_firstname")));

            Console.WriteLine("Entering data...");
            FirstName.SendKeys(name);
            LastName.SendKeys(lastName);
            Password.SendKeys(password);
            Address.SendKeys(address);
            City.SendKeys(city);

            SelectElement select = new SelectElement(State);
            select.SelectByText(state);

            ZipCode.SendKeys(zip);
            MobilePhone.SendKeys(mobileNumber);
            AliasAddress.SendKeys(aliasAddress);

            Console.WriteLine("Checking input data...");

            select = new SelectElement(Country);
            Assert.AreEqual(select.SelectedOption.Text, country);

            RegisterBtn.Click();
        }

       
    }
}
