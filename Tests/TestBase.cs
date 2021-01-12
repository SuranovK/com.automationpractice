using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace com.automationpractice
{
    public class TestBase
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            SetUpBrowser("firefox");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        

        public static IWebDriver SetUpBrowser(string browserName)
        {

            switch (browserName)
            {
                case "chrome":
                    Console.WriteLine("Launching " + browserName + " browser");
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    Console.WriteLine("Launching " + browserName + " browser");
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    Console.WriteLine("Launching " + browserName + " browser");
                    driver = new InternetExplorerDriver();
                    break;
            }
            return driver;
        }
    }
}
