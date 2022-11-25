namespace CCESymp.UI.PageObjects.ServicesMenu.WebAppDev
{
    public partial class WebAppDevPage
    {
        private class Selectors
        {
            public static string FullStackTabsXpath (string fullStackTab) => $"//span[text()='{fullStackTab}']";
            public static string TechnologiesPageLinkXpath => "//a[text()='technologies page']";
            public static string TeamEffectLinkXpath => "//*[contains(text(),'Let us show you the effect')]";
            public static string GetStartedTodayLinkXpath => "//a[text()='Get started today.']";

        }
    }
}
