using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace SFL_Test_Task.POM
{
    class BaseObjects
    {
        protected IWebDriver driver;

        public BaseObjects(IWebDriver driver)
        {
            this.driver = driver;
        }
        protected void ClickElement(By locator)
        {
            driver.FindElement(locator).Click();
        }
        protected void SetElement(By locator, string textToSet)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(textToSet);
        }
        public bool WaitUntilLoaderDisappear(By locator, int avgWaitTime)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromMinutes(avgWaitTime))
                .Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Here is the exception {ex.Message}");
                return false;
            }
        }
        public bool WaitElementToDisplay(By locator, int avgWaitTime)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromMinutes(avgWaitTime))
                .Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Here is the exception {ex.Message}");
                return false;
            }
        }
        public bool WaitElementIsClickable(By locator, int avgWaitTime)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromMinutes(avgWaitTime))
                .Until(ExpectedConditions.ElementToBeClickable(locator));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Here is the exception {ex.Message}");
                return false;
            }
        }
        public void UploadFile(string filename)
        {
            string filePath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\TestDocs\\{filename}";
            IWebElement addAttachment = driver.FindElement(By.CssSelector("input[type='file']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.visibility = 'visible'; arguments[0].style.height = '1px'; arguments[0].style.width = '1px'; arguments[0].style.opacity = 1; arguments[0].style.display = 'inline'; arguments[0].style.overflow = 'visible'", addAttachment);
            addAttachment.SendKeys(filePath);
            Console.WriteLine("File uploaded");
        }
    }
}
