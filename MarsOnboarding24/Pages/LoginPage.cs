using MarsOnboarding24.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboarding24.Pages
{
    public class LoginPage : CommonDriver
    {
        IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        IWebElement usernameTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        IWebElement passwordTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

        public void LoginActions(string username, string password)
        {
            driver.Manage().Window.Maximize();
            string baseURL = "http://localhost:5000/Home";
            driver.Navigate().GoToUrl(baseURL);
            signInButton.Click();
            usernameTextbox.SendKeys(username);
            passwordTextbox.SendKeys(password);
            loginButton.Click();
            Thread.Sleep(3000);
        }
    }
}
