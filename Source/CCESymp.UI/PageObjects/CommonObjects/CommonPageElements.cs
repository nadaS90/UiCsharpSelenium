using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;
using BD.Automation.Core.Drivers.Selenium;
using CCESymp.UI.TestData;
using CCESymp.UI.Utilities;



namespace CCESymp.UI.PageObjects.CommonObjects
{
    public partial class CommonPage
    {
        //private string SubTitleDotNetXpath => string.Format(Selectors.SubTitleHeaderXpath, TestData.Constants.FullStackDotNet);
        //private string SubTitleJSXpath => string.Format(Selectors.SubTitleHeaderXpath, TestData.Constants.FullStackJS);
        //private string SubTitleJavaXpath => string.Format(Selectors.SubTitleHeaderXpath, TestData.Constants.FullStackJava);
        // private string CardContentXpath => string.Format(Selectors.SubTitleHeaderXpath, TestData.Constants.FullStackJava);
       // public string ExploreMoreBtnXpath => string.Format(CommonSelectors.SubTitleHeaderXpath, TestData.Constants.ExploreCaseStudies);


        public IElement PageTitleHeader => driver.Element.GetElement(SearchType.ByXpath, CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.WebAppDevPageTitle));
        public IElement SubTitleTabs => driver.Element.GetElement(SearchType.ByXpath, CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.FullStackJava));
        public IElement SubTitleHeader => driver.Element.GetElement(SearchType.ByXpath, CommonPage.CommonSelectors.SubTitleHeaderXpath(Constants.FullStackDotNet));
        public IElement GetStartedBtn => driver.Element.GetElement(SearchType.ByXpath, CommonSelectors.GetStartedBtnXpath);
        public IElement CardContentLink => driver.Element.GetElement(SearchType.ByXpath, CommonSelectors.CardContentLinkXpath);
        public IElement ExploreMoreBtn => driver.Element.GetElement(SearchType.ByXpath, CommonPage.CommonSelectors.ExploreMoreBtnXpath(Constants.ExploreCaseStudies));

        // private IElement FullStackDotNet => driver.Element.GetElement(SearchType.ByXpath, SubTitleDotNetXpath);
        // private IElement FullStackJS => driver.Element.GetElement(SearchType.ByXpath, SubTitleJSXpath);
        //private IElement FullStackJava => driver.Element.GetElement(SearchType.ByXpath, SubTitleJavaXpath);

        // common button " lets talk "
    }
}
