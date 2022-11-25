using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;
using CCESymp.UI.TestData;

namespace CCESymp.UI.PageObjects.ServicesMenu.WebAppDev
{
    public partial class WebAppDevPage
    {
        private IElement FullStackDotNet => driver.Element.GetElement(SearchType.ByXpath, WebAppDevPage.Selectors.FullStackTabsXpath(Constants.FullStackDotNet));
        private IElement FullStackJS => driver.Element.GetElement(SearchType.ByXpath, WebAppDevPage.Selectors.FullStackTabsXpath(Constants.FullStackJS));
        private IElement FullStackJava => driver.Element.GetElement(SearchType.ByXpath, WebAppDevPage.Selectors.FullStackTabsXpath(Constants.FullStackJava));
        private IElement TechnologiesPageLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.TechnologiesPageLinkXpath);
        private IElement TeamEffectLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.TeamEffectLinkXpath);
        private IElement GetStartedTodayLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.GetStartedTodayLinkXpath);

    }
}
