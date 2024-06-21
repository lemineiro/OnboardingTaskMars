using MarsOnboarding24.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MarsOnboarding24.Pages
{
    public class LanguagePage : CommonDriver
    {
        IWebElement deleteButton => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        IWebElement addNewButton => driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table//thead/tr/th[3]/div[contains(text(),\"Add New\")]"));
        IWebElement languageTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        IWebElement languageLevelMainDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
        IWebElement languageLevelDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]"));
        IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));

        public void NavigateToLanguageTab(IWebDriver driver)
        {
            Thread.Sleep(3000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 2);
        }

        public void ResetTest(IWebDriver driver)
        {
            Thread.Sleep(5000);

            if (driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[1]")).Count != 0)
            {
                do
                {
                    deleteButton.Click();
                    driver.Navigate().Refresh();
                    Thread.Sleep(1000);
                }
                while (driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[1]")).Count != 0);
            }                
        }

        public void CreateLanguageRecord(IWebDriver driver) 
        {
            if (driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[1]")).Count != 0)
            {
                deleteButton.Click();
            }

            addNewButton.Click();
            languageTextbox.SendKeys("English");
            languageLevelMainDropdown.Click();
            Thread.Sleep(2000);
            languageLevelDropdown.Click();
            addButton.Click();
        }

        public void EditLanguageRecord(IWebDriver driver)
        {
            Thread.Sleep(3000);
            
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editButton.Click();
            Thread.Sleep(2000);
            IWebElement languageEditTextbox = driver.FindElement(By.XPath("//tbody/tr/td/div/div[1]/input[1]"));
            languageEditTextbox.Click();
            languageEditTextbox.Clear();
            languageEditTextbox.SendKeys("Portuguese");
            Thread.Sleep(2000);

            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
        }

        public void DeleteLanguageRecord(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]", 5);
            deleteButton.Click();
        }

        public void DeleteLanguageRecordAssertion(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement createdRecord = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table"));
            Assert.That(createdRecord.Text != "English", "Created record has not been deleted");
        }

        public void AddMultipleLanguageRecords(IWebDriver driver)
        {
            CreateLanguage(driver, "English");
            CreateLanguage(driver, "Portuguese");
            CreateLanguage(driver, "Spanish");
            CreateLanguage(driver, "French");
        }

        public void CreateLanguage(IWebDriver driver, string language)
        {
            Thread.Sleep(2000);
            addNewButton.Click();
            Thread.Sleep(2000);
            languageTextbox.SendKeys(language);
            languageLevelMainDropdown.Click();
            Thread.Sleep(2000);
            languageLevelDropdown.Click();
            addButton.Click();
        }

        public void CreateLanguageRecordSpecialCharacters(IWebDriver driver)
        {
            if (driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[1]")).Count != 0)
            {
                deleteButton.Click();
            }

            addNewButton.Click();
            languageTextbox.SendKeys("!@#$%");
            languageLevelMainDropdown.Click();
            Thread.Sleep(2000);
            languageLevelDropdown.Click();
            addButton.Click();
        }

        public void CreateLanguageRecordNullData(IWebDriver driver)
        {
            if (driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[1]")).Count != 0)
            {
                deleteButton.Click();
            }

            addNewButton.Click();
            languageLevelMainDropdown.Click();
            Thread.Sleep(2000);
            languageLevelDropdown.Click();
            addButton.Click();
        }

        public void CreateLanguageRecordExistingData(IWebDriver driver)
        {
            if (driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[1]")).Count != 0)
            {
                deleteButton.Click();
            }

            CreateLanguage(driver, "English");
            CreateLanguage(driver, "English");
        }
    }
}
