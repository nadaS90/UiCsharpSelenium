using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using CCESymp.UI.TestData;
using CCESymp.UI.Utilities;


namespace CCESymp.UI.PageObjects.CommonObjects
{
    public partial class CommonPage : BasePage<CommonPage>
    {
        /// <summary>
        /// click on Get Started button displayed on current page
        /// </summary>
        public void ClickOnGetStartedBtn()
        {
            Logger.Info("Click on Get Started button");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonSelectors.GetStartedBtnXpath);
            GetStartedBtn.Click();
        }

        /// <summary>
        /// click on cards content displayed on current page
        /// </summary>
        public void ClickOnCardContentLink()
        {
            Logger.Info("Click on Card Content link");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonSelectors.CardContentLinkXpath);
            CardContentLink.Click();
        }

        /// <summary>
        /// click on Explore More button on current page
        /// </summary>
        public void ClickOnExploreMoreBtn()
        {
            Logger.Info("Click on Explore More btton");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CommonPage.CommonSelectors.ExploreMoreBtnXpath(Constants.ExploreCaseStudies));
            ExploreMoreBtn.Click();
        }


    }
}
