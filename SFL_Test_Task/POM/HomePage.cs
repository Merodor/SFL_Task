using OpenQA.Selenium;
using System;

namespace SFL_Test_Task.POM
{
    class HomePage : BaseObjects
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            Console.WriteLine("Welcome to Home Page");
        }

        #region Locators
        By _jobCount = By.ClassName("job-count");
        By _careersTab = By.XPath("//ul[@id='sf-menu']//*[text()='Careers']");
        By _loader = By.Id("ajax-loading-screen");
        #endregion Locators

        public int GetCareersCount()
        {
            IWebElement JobCount = driver.FindElement(_jobCount);
            string value = JobCount.Text;
            int count = Convert.ToInt32(value);
            return count;
        }

        public void ClickOnJobs()
        {
            WaitUntilLoaderDisappear(_loader, 2);
            WaitElementIsClickable(_careersTab, 2);
            ClickElement(_careersTab);
            Console.WriteLine("We are on Careers Tab");
        }
    }
}
