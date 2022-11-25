using BD.Automation.Core.Drivers.Enums;
using CCESymp.UI.Utilities;
using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using CCESymp.UI.PageObjects.CommonObjects;
using CommonObjects =  CCESymp.UI.PageObjects.CommonObjects.CommonPage;
using CCESymp.UI.TestData;

namespace CCESymp.UI.PageObjects.ServicesMenu.WebAppDev
{
    public partial class WebAppDevPage : BasePage<WebAppDevPage>

    {
        /// <summary>
        /// Verify if page title is displayed 
        /// </summary>
        public bool IsUserAtWebAppDevPage()
        {
            Logger.Info("Check if page title is displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.WebAppDevPageTitle), 30);
            return driver.Element.GetElement(SearchType.ByXpath, CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.WebAppDevPageTitle)).Displayed;
            // return PageTitleHeader.Displayed;
        }

        /// <summary>
        /// click on Full Stack .Net tab that is displayed on Web Application Development page
        /// </summary>
        public void ClickOnFullStackDotNetTab()
        {
            Logger.Info("Click on Full Stack .Net");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleTabsXpath(Constants.FullStackDotNet), 30);
            FullStackDotNet.Click();
        }

        /// <summary>
        /// Verify if Full Stack .Net sub title is displayed 
        /// </summary>
        public bool IsFullStackDotNetSubTitleDisplayed()
        {
            Logger.Info("Check if Full Stack .Net sub title is displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleHeaderXpath(Constants.FullStackDotNet), 30);
            return driver.Element.GetElement(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleHeaderXpath(Constants.FullStackDotNet)).Displayed;
        }

        /// <summary>
        /// click on Full Stack Js tab that is displayed on Web Application Development page
        /// </summary>
        public void ClickOnFullStackJSTab()
        {
            Logger.Info("Click on Full Stack JS");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleTabsXpath(Constants.FullStackJS), 30);
            FullStackJS.Click();
        }

        /// <summary>
        /// Verify if Full Stack Js sub title is displayed 
        /// </summary>
        public bool IsFullStackJSSubTitleDisplayed()
        {
            Logger.Info("Check if Full Stack JS sub title is displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleTabsXpath(Constants.FullStackJS), 30);
            return driver.Element.GetElement(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleTabsXpath(Constants.FullStackJS)).Displayed;

        }

        /// <summary>
        /// click on Full Stack Java tab that is displayed on Web Application Development page
        /// </summary>
        public void ClickOnFullStackJavaTab()
        {
            Logger.Info("Click on Full Stack Java");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleTabsXpath(Constants.FullStackJava), 30);
            FullStackJava.Click();
        }

        /// <summary>
        /// Verify if Full Stack Java sub title is displayed 
        /// </summary>
        public bool IsFullStackJavaSubTitleDisplayed()
        {
            Logger.Info("Check if Full Stack Java sub title is displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleHeaderXpath(Constants.FullStackJava), 30);
            return driver.Element.GetElement(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleHeaderXpath(Constants.FullStackJava)).Displayed;

        }

        /// <summary>
        /// click on Technologies page link that is displayed on Web Application Development page
        /// </summary>
        public void ClickOnTechnologiesPage()
        {
            Logger.Info("Click on Technologies page link");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.TechnologiesPageLinkXpath);
            TechnologiesPageLink.Click();
        }

        /// <summary>
        /// click on Team effort link that is displayed on Web Application Development page
        /// </summary>
        public void ClickOnTeamEffectLinlk()
        {
            Logger.Info("Click on Technologies page link");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.TeamEffectLinkXpath);
            TeamEffectLink.Click();
        }

        /// <summary>
        /// click on Get started today link that is displayed on Web Application Development page
        /// </summary>
        public void ClickOnGetStartedTodayinlk()
        {
            Logger.Info("Click on Technologies page link");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.GetStartedTodayLinkXpath);
            GetStartedTodayLink.Click();
        }




    }
}
