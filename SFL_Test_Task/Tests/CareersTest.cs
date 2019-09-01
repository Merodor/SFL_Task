using SFL_Test_Task.POM;
using NUnit.Framework;
using System;
using SFL_Test_Task.Constants;

namespace SFL_Test_Task.Tests
{
    class CareersTest : BaseTest
    {
        [Description("Test scenario task")]
        [Test]
        public void TestScenarioBySFL()
        {
            HomePage homePage = new HomePage(Driver);
            CareersPage careersPage = new CareersPage(Driver);
            int countOfJobs = homePage.GetCareersCount();
            homePage.ClickOnJobs();
            Assert.AreEqual(countOfJobs, careersPage.JobsListCount());
            Assert.False(careersPage.DoesTheJobExist(CareerConstants.Manual));
            if (!careersPage.DoesTheJobExist(CareerConstants.Automation))
                throw new Exception("There is no vacancy for Automation QA Engineer!");
            else
            careersPage.ClickOnCurrentJob(CareerConstants.Automation);
            careersPage.ScrollTillSubmit();
            careersPage.FillTheForm(CareerConstants.FirstName, CareerConstants.LastName, CareerConstants.Email, CareerConstants.FileName);
            Assert.AreEqual(CareerConstants.ReCaptchaErrMsg, careersPage.GetWarningMsg());
        }
        
    }
}
