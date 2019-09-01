using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace SFL_Test_Task.POM
{
    class CareersPage : BaseObjects
    {
        public CareersPage(IWebDriver driver) : base(driver)
        {
            Console.WriteLine("Careers Page opened");
        }

        #region Locators
        By _jobList = By.ClassName("smartrecruitersJobList");
        By _loader = By.Id("ajax-loading-screen");
        By _firstName = By.XPath("//div[contains(@id,'wpcf7-f3772-o1')]//div[contains(@class,'s-send-resume')]//input[contains(@name,'Firstname')]");
        By _lastName = By.XPath("//div[contains(@id,'wpcf7-f3772-o1')]//div[contains(@class,'s-send-resume')]//input[contains(@name,'Lastname')]");
        By _email = By.XPath("//div[contains(@id,'wpcf7-f3772-o1')]//div[contains(@class,'s-send-resume')]//input[contains(@name,'E-mailaddress')]");
        By _submitBtn = By.XPath("//div[contains(@id,'wpcf7-f3772-o1')]//div[contains(@class,'s-send-resume')]//input[contains(@type,'sub')]");
        By _warning = By.ClassName("wpcf7-not-valid-tip");
        #endregion Locators

        public void ClickOnCurrentJob(string jobTitle)
        {
            WaitElementToDisplay(_jobList, 2);
            IWebElement jobs = driver.FindElement(_jobList);
            IList<IWebElement> jobList = jobs.FindElements(By.XPath(".//li"));
            foreach (IWebElement jobItem in jobList)
            {
                if (jobItem.Text.Contains(jobTitle))
                {
                    WaitUntilLoaderDisappear(_loader, 2);
                    jobItem.Click();
                    break;
                }
            }
        }

        public int JobsListCount()
        {
            WaitElementToDisplay(_jobList, 2);
            IWebElement jobs = driver.FindElement(_jobList);
            IList<IWebElement> jobList = jobs.FindElements(By.XPath(".//li"));
            return jobList.Count;
        }

        public bool DoesTheJobExist(string jobTitle)
        {
            bool exist = true;
            WaitElementToDisplay(_jobList, 2);
            IWebElement jobs = driver.FindElement(_jobList);
            IList<IWebElement> jobList = jobs.FindElements(By.XPath(".//li"));
            foreach (IWebElement jobItem in jobList)
            {
                if (jobItem.Text.Contains(jobTitle))
                {
                    Console.WriteLine("There is our job!");
                    exist = true;
                    break;
                }
                exist = false;
            }
            return exist;
        }

        public void ScrollTillSubmit()
        {
            IWebElement submitBtn = driver.FindElement(_submitBtn);
            // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn);
            Actions actions = new Actions(driver);
            actions.MoveToElement(submitBtn);
            actions.Perform();

        }

        public void FillTheForm(string firstName, string lastName, string email, string fileName)
        {
            WaitElementToDisplay(_firstName, 2);
            SetElement(_firstName, firstName);
            WaitElementToDisplay(_lastName, 2);
            SetElement(_lastName, lastName);
            WaitElementToDisplay(_email, 2);
            SetElement(_email, email);
            UploadFile(fileName);
            Console.WriteLine("File uploaded");
            WaitElementIsClickable(_submitBtn, 1);
            ClickElement(_submitBtn);
            Console.WriteLine("Clicked on Submit");
        }

        public string GetWarningMsg()
        {
            WaitElementToDisplay(_warning, 1);
            IWebElement warningMsg = driver.FindElement(_warning);
            return warningMsg.Text;
        }
    }
}
