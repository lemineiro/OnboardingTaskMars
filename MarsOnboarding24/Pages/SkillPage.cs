using MarsOnboarding24.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MarsOnboarding24.Pages
{
    public class SkillPage : CommonDriver
    {
        IWebElement deleteButton => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement skillTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
        IWebElement skillLevelMainDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
        IWebElement skillLevelDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]"));
        IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));

        public void NavigatetoSkillTab(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement skillsTabButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTabButton.Click();
        }

        public void CreatingSkillRecord(IWebDriver driver) 
        {
            if (driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody[1]")).Count != 0)
            {
                deleteButton.Click();
            }

            addNewButton.Click();
            skillTextbox.SendKeys("Writing");
            skillLevelMainDropdown.Click();
            Thread.Sleep(2000);
            skillLevelDropdown.Click();
            addButton.Click();
        }

        public void EditingSkillRecord(IWebDriver driver)
        {
            Thread.Sleep(3000);

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
            editButton.Click();
            Thread.Sleep(2000);
            IWebElement skillEditTextbox = driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]"));
            skillEditTextbox.Click();
            skillEditTextbox.Clear();
            skillEditTextbox.SendKeys("Photograph");
            Thread.Sleep(2000);
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
        }

        public void DeletingSkillRecord(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//form/div[3]/div/div[2]/div/table/tbody[1]", 5);
            deleteButton.Click();
        }

        public void CreatingSkillRecordSpecialCharacters(IWebDriver driver)
        {
            if (driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody[1]")).Count != 0)
            {
                deleteButton.Click();
            }

            addNewButton.Click();
            skillTextbox.SendKeys("!@#$%");
            skillLevelMainDropdown.Click();
            Thread.Sleep(2000);
            skillLevelDropdown.Click();
            addButton.Click();
        }

        public void CreatingSkillRecordNullData(IWebDriver driver)
        {
            if (driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody[1]")).Count != 0)
            {
                deleteButton.Click();
            }

            addNewButton.Click();
            skillLevelMainDropdown.Click();
            Thread.Sleep(2000);
            skillLevelDropdown.Click();
            addButton.Click();
        }

        public void CreatingSkillRecordExistingData(IWebDriver driver)
        {
            if (driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody[1]")).Count != 0)
            {
                deleteButton.Click();
            }

            CreateSkill(driver, "Writing");
            CreateSkill(driver, "Writing");
        }

        public void CreateSkill(IWebDriver driver, string skill)
        {
            Thread.Sleep(2000);
            addNewButton.Click();
            Thread.Sleep(2000);
            skillTextbox.SendKeys(skill);
            skillLevelMainDropdown.Click();
            Thread.Sleep(2000);
            skillLevelDropdown.Click();
            addButton.Click();
        }
    }
}
