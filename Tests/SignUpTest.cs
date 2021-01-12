using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace com.automationpractice
{
    public class Execution : TestBase
    {
     
        [TestCase("johnadams22@mail.com","John", "Adams","pass123", "1234 Washington ave", "Saint Louis", "Missouri","63121", "1234567890", "1234 AnotherAdress str", "United States")]
        public void ValidateUserName(string email, string name, string lastName, string password, string address, string city, string state, string zip, string mobileNumber, string aliasAddress, string country)
        {
            HomePage homePage = new HomePage(driver);
            RegistrationPage signUpPage = new RegistrationPage(driver);

            Console.WriteLine("Execution lunched.");
            driver.Url = "http://automationpractice.com/index.php";
 
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            homePage.RegisterEmail(email);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            signUpPage.FillOutRegistrationForm(email, name, lastName, password, address, city, state, zip, mobileNumber, aliasAddress, country);

            Console.WriteLine("Validating new registered user information...");
            
            StringAssert.AreEqualIgnoringCase(signUpPage.CurrentUsername.Text, name + " " + lastName);
            Console.WriteLine("Actual user's fisrt name and last name: " + signUpPage.CurrentUsername.Text);
            Console.WriteLine("Expected user first name and last name: " + name + " " + lastName);
        }
    }
}