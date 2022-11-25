using CCESymp.UI.PageObjects;
using CCESymp.UI.PageObjects.CommonObjects;
using CCESymp.UI.PageObjects.ServicesMenu.WebAppDev;
using CCESymp.UI.TestData;
using CCESymp.UI.Utilities;
using NUnit.Framework;
using System;
using static CCESymp.UI.PageObjects.CommonObjects.CommonPage;

namespace CCESymp.UI.TestClasses
{

    [TestFixture]

    public partial class WebAppDevTest : BaseTest
    {

        [TestCase]
        [Category("WebAppDevPage")]
        [Description("Test Case 1251787: US1400002 - user navegates to Web App Development Pgge")]
        public void CheckIsWebAppDevPageDisplayed()
        {
            Logger.Info("EXECUTING: Test Case 1251787: US1400002 - user navigates to Web Application Development page is displayed");
            driver.Navigation.SetUrl("https://integrant.com/services/web-application-development");
            WebAppDevPage.Page.IsUserAtWebAppDevPage();
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.WebAppDevPageTitle).Contains("Web Application Development"));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }


        [TestCase]
        [Category("WebAppDevPage")]
        [Description("Test Case 1251787: US1400003 - click on Full Stack .Net tab that is displayed on Web Application Development page")]

        public void ClickOnFullStackDotNetTab()
        {
            Logger.Info("EXECUTING: Test Case 1251787: US1400003 - click on Full Stack .Net tab that is displayed on Web Application Development page");
            WebAppDevPage.Page.ClickOnFullStackDotNet();
            //Validate sub title
            Logger.Info("VALIDATION: Required page is loaded and sub title displayed");
            Assert.IsTrue(CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.WebAppDevPageTitle).Contains("Web Application Development"));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");

        }

    }
}
