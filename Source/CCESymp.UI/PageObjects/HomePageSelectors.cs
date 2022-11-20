namespace CCESymp.UI.PageObjects
{
    public partial class HomePage
    {
        private class Selectors
        {
            public static string ServicesTabXpath => "//div[contains(@class,'flex items-center m-2')]//a[normalize-space()='Services']";
            public static string WebAppDevXpath => "//a[contains(@class,'shadow-none grou ml-navbar-items no-underline text-sm font-normal')][normalize-space()='Web Application Development']";        }
    }
