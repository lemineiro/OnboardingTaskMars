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
    public class LanguageStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        LanguagePage languagePageObj = new LanguagePage();

        [AfterScenario]

        public void QuitTestRun()
        {
            languagePageObj.ResetTest(driver);
            driver.Quit();
        }

        [Given(@"user navigates to the Languages tab")]
        public void GivenUserNavigatesToTheLanguagesTab()
        {
            languagePageObj.NavigateToLanguageTab(driver);
        }

        [When(@"user creates a new Language record")]
        public void WhenUserCreatesANewLanguageRecord()
        {
            languagePageObj.CreateLanguageRecord(driver);
        }

        [Then(@"system should save the new Language record")]
        public void ThenSystemShouldSaveTheNewLanguageRecord()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]", 5);
            IWebElement newLanguageRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(newLanguageRecord.Text == "English", "New language record and expected code do not match");
        }

        [Given(@"user creates a new Language record")]
        public void GivenUserCreatesANewLanguageRecord()
        {
            languagePageObj.CreateLanguageRecord(driver);
        }

        [When(@"user edits the language record")]
        public void WhenUserEditsTheLanguageRecord()
        {
            languagePageObj.EditLanguageRecord(driver);
        }

        [Then(@"system should save the edited Language record")]
        public void ThenSystemShouldSaveTheEditedLanguageRecord()
        {
            Thread.Sleep(3000);
            IWebElement editedLanguageRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(editedLanguageRecord.Text == "Portuguese", "Edited language record and expected code do not match");
        }

        [When(@"user deletes the language record")]
        public void WhenUserDeletesTheLanguageRecord()
        {
            languagePageObj.DeleteLanguageRecord(driver);
        }

        [Then(@"system should delete the Language record")]
        public void ThenSystemShouldDeleteTheLanguageRecord()
        {
            Thread.Sleep(2000);
            IWebElement createdRecord = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table"));
            Assert.That(createdRecord.Text != "English", "Created record has not been deleted");
        }

        [When(@"user creates multiple records")]
        public void WhenUserCreatesMultipleRecords()
        {
            languagePageObj.AddMultipleLanguageRecords(driver);
        }

        [Then(@"user should not be able to add any more language records")]
        public void ThenUserShouldNotBeAbleToAddAnyMoreLanguageRecords()
        {
            Thread.Sleep(2000);

            try
            {
                IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab=\"first\"]//table//thead/tr/th[3]/div[contains(text(),\"Add New\")]"));
                addNewButton.Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                Assert.Pass("Add New Button no longer visible");
            }
        }

        [When(@"user creates a new Language record using special characters")]
        public void WhenUserCreatesANewLanguageRecordUsingSpecialCharacters()
        {
            languagePageObj.CreateLanguageRecordSpecialCharacters(driver);
        }

        [Then(@"system should not save the record")]
        public void ThenSystemShouldNotSaveTheRecord()
        {
            Thread.Sleep(2000);
            IWebElement specialCharactersRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(specialCharactersRecord.Text != "!@#$%", "User was able to create a record using special characters");
        }

        [When(@"user creates a new Language record using null data")]
        public void WhenUserCreatesANewLanguageRecordUsingNullData()
        {
            languagePageObj.CreateLanguageRecordNullData(driver);
        }

        [Then(@"system should not save the record with null data")]
        public void ThenSystemShouldNotSaveTheRecordWithNullData()
        {
            Thread.Sleep(3000);
            if (driver.FindElements(By.XPath("//div[@data-tab=\"first\"]//table//tbody/tr")).Count == 0)
            {
                Assert.Pass("User was not able to create record with null data");
            }
            else
            {
                Assert.Fail("User was able to create record with null data");
            }
        }

        [When(@"user tries to create a duplicate record")]
        public void WhenUserTriesToCreateADuplicateRecord()
        {
            languagePageObj.CreateLanguageRecordExistingData(driver);
        }

        [Then(@"system should not save the record using existing data")]
        public void ThenSystemShouldNotSaveTheRecordUsingExistingData()
        {
            Thread.Sleep(3000);

            if (driver.FindElements(By.XPath("//div[@data-tab=\"first\"]//table//tbody/tr")).Count > 1)
            {
                Assert.Fail("User is able to add duplicate record");
            }
            else
            {
                Assert.Pass("User is not able to add duplicate record");
            }
        }

    }
}
