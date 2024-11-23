using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; 
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace YourProjectNamespace
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginSteps()
        {
            driver = new ChromeDriver(); 
            loginPage = new LoginPage(driver);
        }

        [Given(@"I am on the saucedemo website")]
        public void GivenIAmOnTheSaucedemoWebsite()
        {
            loginPage.OpenLoginPage("https://www.saucedemo.com/"); 
        }

        [Then(@"I enter username")]
        public void EnterUsername()
        {
            loginPage.EnterUsername("locked_out_user");
        }
        [Then(@"I enter password")]
        public void EnterPassword()
        {
            loginPage.EnterPassword("secret_sauce");
        }

        [When(@"I select ""Login"" option")]
        public void WhenISelectLogin()
        {
            loginPage.ClickLogin();
        }

        [Then(@"I should see an error message")]
        public void ThenShouldSeeError()
        {
            string msg = loginPage.ShowErrorMSg();
            Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", msg, "Error messages are different.");
        }

        [Then(@"I should close Chrome")]
        public void CloseChrome()
        {
            loginPage.CloseDriver();
        }
    }
}
