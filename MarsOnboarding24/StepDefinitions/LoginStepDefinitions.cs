using MarsOnboarding24.Pages;
using MarsOnboarding24.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsOnboarding24.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();

        [BeforeScenario]

        public void LoginFunction()
        {
            driver = new ChromeDriver();
        }

        [Given(@"user logs into the portal")]
        public void GivenUserLogsIntoThePortal()
        {
            loginPageObj.LoginActions("leticia.ltm@gmail.com", "QAMars2024*");

            Wait.WaitToBeVisible(driver, "XPath", "//div[@class=\"ui compact menu\"]/span", 15);
            IWebElement homePageGreeting = driver.FindElement(By.XPath("//div[@class=\"ui compact menu\"]/span"));
            var greetingText = homePageGreeting.Text;
            Assert.That(greetingText, Is.EqualTo("Hi Leticia"), "User has not logged in");
        }

        [Given(@"user logs into the portal with invalid credentials")]
        public void GivenUserLogsIntoThePortalWithInvalidCredentials()
        {
            loginPageObj.LoginActions("leticia.ltm@gmail.com", "123123");

            Thread.Sleep(1500);
            IWebElement loginErrorMessage = driver.FindElement(By.XPath("//body/div/div[contains(text(), 'Confirm your email')]"));
            
            if (loginErrorMessage.Displayed)
            {
                Assert.Pass("User not allowed to login with invalid credentials");
            }

            else
            {
                Assert.Fail("Error message not displayed when login in with invalid credentials");
            }
        }
    }
}
