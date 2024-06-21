using MarsOnboarding24.Pages;
using MarsOnboarding24.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsOnboarding24.StepDefinitions
{
    [Binding]
    public class SkillStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        SkillPage skillPageObj = new SkillPage();

        [AfterScenario]

        public void QuitTestRun()
        {
            driver.Quit();
        }

        [Given(@"user navigates to the Skill tab")]
        public void GivenUserNavigatesToTheSkillTab()
        {
            skillPageObj.NavigatetoSkillTab(driver);
        }

        [When(@"user creates a new Skill record")]
        public void WhenUserCreatesANewSkillRecord()
        {
            skillPageObj.CreatingSkillRecord(driver);
        }

        [Then(@"system should save the new skill record")]
        public void ThenSystemShouldSaveTheNewSkillRecord()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]", 5);
            IWebElement newSkillRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(newSkillRecord.Text == "Writing", "New skill record and expected code do not match");
        }

        [Given(@"user creates a new Skill record")]
        public void GivenUserCreatesANewSkillRecord()
        {
            skillPageObj.CreatingSkillRecord(driver);
        }

        [When(@"user edits the skill record")]
        public void WhenUserEditsTheSkillRecord()
        {
            skillPageObj.EditingSkillRecord(driver);
        }

        [Then(@"system should save the edited skill record")]
        public void ThenSystemShouldSaveTheEditedSkillRecord()
        {
            Thread.Sleep(3000);
            IWebElement editedSkillRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(editedSkillRecord.Text == "Photograph", "Edited skill record and expected code do not match");
        }

        [When(@"user deletes the skill record")]
        public void WhenUserDeletesTheSkillRecord()
        {
            skillPageObj.DeletingSkillRecord(driver);
        }

        [Then(@"system should delete the skill record")]
        public void ThenSystemShouldDeleteTheSkillRecord()
        {
            Thread.Sleep(2000);
            IWebElement createdRecord = driver.FindElement(By.XPath("//form/div[3]/div/div[2]/div/table"));
            Assert.That(createdRecord.Text != "Writing", "Created record has not been deleted");
        }

        [When(@"user creates a new Skill record using special characters")]
        public void WhenUserCreatesANewSkillRecordUsingSpecialCharacters()
        {
            skillPageObj.CreatingSkillRecordSpecialCharacters(driver);
        }

        [Then(@"system should not save the skill record with special characters")]
        public void ThenSystemShouldNotSaveTheSkillRecordWithSpecialCharacters()
        {
            Thread.Sleep(2000);
            IWebElement specialCharactersRecord = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            Assert.That(specialCharactersRecord.Text != "!@#$%", "User was able to create a record using special characters");
        }

        [When(@"user creates a new Skill record using null data")]
        public void WhenUserCreatesANewSkillRecordUsingNullData()
        {
            skillPageObj.CreatingSkillRecordNullData(driver);
        }

        [Then(@"system should not save the null skill record")]
        public void ThenSystemShouldNotSaveTheNullSkillRecord()
        {
            Thread.Sleep(3000);
            if (driver.FindElements(By.XPath("//div[@data-tab=\"second\"]//table//tbody/tr")).Count == 0)
            {
                Assert.Pass("User was not able to create record with null data");
            }
            else
            {
                Assert.Fail("User was able to create record with null data");
            }
        }

        [When(@"user creates a new Skill record using existing data")]
        public void WhenUserCreatesANewSkillRecordUsingExistingData()
        {
            skillPageObj.CreatingSkillRecordExistingData(driver);
        }      

        [Then(@"system should not save the skill record with existing data")]
        public void ThenSystemShouldNotSaveTheSkillRecordWithExistingData()
        {
            Thread.Sleep(3000);

            if (driver.FindElements(By.XPath("//div[@data-tab=\"second\"]//table//tbody/tr")).Count > 1)
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
