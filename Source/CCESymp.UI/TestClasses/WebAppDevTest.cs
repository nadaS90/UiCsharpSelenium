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
        [Description("Test Case 1251787: US1400001 - user navegates to Web App Development Page ")]
        public void CheckIfWebAppDevPageDisplayed()
        {
            Logger.Info("EXECUTING: Test Case 1251787: US1400001 - user navigates to Web Application Development page is displayed");
            driver.Navigation.SetUrl("https://integrant.com/services/web-application-development");
            WebAppDevPage.Page.IsUserAtWebAppDevPage();
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.WebAppDevPageTitle).Contains(Constants.WebAppDevPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");

        }

        [TestCase]
        [Category("WebAppDevPage")]
        [Description("Test Case 1251787: US1400002 - check if Full Stack .Net tab that is displayed on Web Application Development page")]
        public void CheckIfFullStackDotNetSubPageDisplayed()
        {         
            Logger.Info("EXECUTING: Test Case 1251787: US1400002 - Check that Full Stack .Net tab that is displayed by default on Web Application Development page");
            driver.Navigation.SetUrl("https://integrant.com/services/web-application-development");

            Logger.Info("VALIDATION: Required sub title tab is displayed");
            Assert.IsTrue(WebAppDevPage.Page.IsFullStackDotNetSubTitleDisplayed());
            Logger.Info("VALIDATION SUCCESS: Required sub title tab is displayed");

            Logger.Info("VALIDATION: Required sub page is loaded and sub title displayed");
            Assert.IsTrue(CommonPage.CommonSelectors.SubTitleHeaderXpath(Constants.FullStackDotNet).Contains(Constants.FullStackDotNet));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");

        }


        [TestCase]
        [Category("WebAppDevPage")]
        [Description("Test Case 1251787: US1400003 - click on Full Stack JS tab that is displayed on Web Application Development page")]

        public void CheckIfFullStackJSSubPageDisplayed()
        {
            Logger.Info("EXECUTING: Test Case 1251787: US1400003 - click on Full Stack JS tab that is displayed on Web Application Development page");
            driver.Navigation.SetUrl("https://integrant.com/services/web-application-development");

           // Logger.Info("VALIDATION: Required sub title tab is displayed");
           // Assert.IsTrue(WebAppDevPage.Page.IsFullStackJSSubTitleDisplayed());
           // Logger.Info("VALIDATION SUCCESS: Required sub title tab is displayed");
            WebAppDevPage.Page.ClickOnFullStackJSTab();
            Logger.Info("VALIDATION: Required sub page is loaded and sub title displayed");
            Assert.IsTrue(CommonPage.CommonSelectors.SubTitleHeaderXpath(Constants.FullStackJS).Contains(Constants.FullStackJS));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");

        }

        [TestCase]
        [Category("WebAppDevPage")]
        [Description("Test Case 1251787: US1400004 - click on Full Stack Java tab that is displayed on Web Application Development page")]

        public void CheckIfFullStackJavaSubPageDisplayed()
        {
            Logger.Info("EXECUTING: Test Case 1251787: US1400004 - click on Full Stack Java tab that is displayed on Web Application Development page");
            driver.Navigation.SetUrl("https://integrant.com/services/web-application-development");

            WebAppDevPage.Page.ClickOnFullStackJavaTab();
            Logger.Info("VALIDATION: Required sub page is loaded and sub title displayed");
            Assert.IsTrue(CommonPage.CommonSelectors.SubTitleHeaderXpath(Constants.FullStackJava).Contains(Constants.FullStackJava));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");

        }

    }
}
