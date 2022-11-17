using BD.Automation.Core.Drivers.Enums;
using System;
using CCESymp.Data;
using NUnit.Framework;
using System.IO;
using NUnit.Framework.Interfaces;
using CCESymp.IDMServices.Services;
using Data;
using CCESymp.Data.Mapping.IMSMapping;

namespace CCESymp.UI.Utilities
{
    public class BaseTest : BaseDriver
    {
        [OneTimeSetUp]
        public void BeforeClass() {
            IDMUserCreationService.IDMUserCreationScript();       
        }

        /// <summary>
        /// Create driver and navigate to the webpage when execution of a test case starts
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            CreateDriver();
            driver.Navigation.SetUrl(/*Common.Common.CCESymp_DashboardUI_Url*/"https://integrant.com/home");
        }

        /// <summary>
        /// Take screenshots, delete user session and quit driver after the execution of a test case has finished
        /// </summary>
        [TearDown]
        public void CleanUp()
        {

            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Passed))
            {
                Logger.Error("EXECUTION SUCCESS: Test execution passed!!!");
            }
            else {
                Logger.Error("EXECUTION FAILURE: Test execution failed!!!");
            }
            Logger.Info("Finishing test execution and cleaning up test active tasks!");

            TakeSeleniumScreenshot();
            DataRepository.DeleteUserSessions();
            QuitDriver();
        }

        
        /// <summary>
        /// Take screenshot of the current browser state only if the test case has failed
        /// </summary>
        public void TakeSeleniumScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                Logger.Info("Taking Selenium Screenshot");
                try
                {
                    var fileName = Guid.NewGuid().ToString();
                    string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
                    var file = driver.Browser.GetScreenShot(Directory.GetCurrentDirectory(), fileName + "_SeleniumSS",
                        ScreenshotFormat.Png);
                    TestContext.AddTestAttachment(file);
                }
                catch (Exception ex)
                {
                    Logger.Info(ex.Message);
                    Logger.Info("Could not take the screenshot");
                }
            }

        }

        public static void SetCurrentUTC()
        {
            MedMapping.CurrentUniversalTime = DateTime.UtcNow.ToUniversalTime().ToString("MM/dd/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
        }
     
    }
}
