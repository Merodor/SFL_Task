using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.IO;

namespace SFL_Test_Task.Tests
{
    class BaseTest
    {
        public IWebDriver Driver;
        public static string ApplicationBaseURl;
        public static string DriverDirectory;
        private void LoadConfigValues()
        {
            var configReader = new AppSettingsReader();
            ApplicationBaseURl = (string)configReader.GetValue("ApplicationBaseURl", typeof(string));
            DriverDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + @"\Drivers";
        }

        [SetUp]
        public void SetUp()
        {
            LoadConfigValues();
            Driver = new ChromeDriver(DriverDirectory);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(ApplicationBaseURl);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
            if (Driver != null)
                Driver = null;
        }
    }
}
