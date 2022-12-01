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

    public partial class TestWebAppDevTest : BaseTest
    {


        [TestCase]
        [Category("MainMenu")]
        [Description("Test Case 1251787: US1400001 - Hover on common main menu displayed on all pages")]

        public void HoverOnMainMenuTry()
        {
            Logger.Info("EXECUTING: Test Case 1251787: US1400002 - user navigates to Web Application Development page is displayed");
            driver.Navigation.SetUrl("https://integrant.com/services/web-application-development");
            WebAppDevPage.Page.IsUserAtWebAppDevPage();
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.WebAppDevPageTitle).Contains("Web Application Development"));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");


            // String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            //String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
            // string url = HttpContext.Current.Request.Url.Host;
            //Console.WriteLine(url);
            // String expectedTitle = "Web Application Development";
            // String actualTitle = CommonSelectors.PageTitleHeaderXpath.ToString();
            //Assert.AreEqual(expectedTitle, actualTitle);
            // Actual title
            // add validation from H1 tittle in each page
            // Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            //Assert.IsTrue(CustomerPage.Page.IsMaxMessageTrackingTabsLimitWarningDisplayed(), "Title that describes the page");
            //Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");

        }
    }
}
