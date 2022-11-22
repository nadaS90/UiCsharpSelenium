namespace CCESymp.UI.PageObjects
{
    public partial class MainMenu
    {
        private class Selectors
        {
            public static string MainMenuItemXpath => "//div[contains(@class,'flex items-center m-2')]//a[normalize-space()='{0}']";
            public static string ShowSubMenuDropdownXpath => ".//div[{0}]/div[1]/div[2]/ul[1]";  
            //public static string SubMenuDropdownXpath => "//a[contains(@class,'shadow-none grou ml-navbar-items no-underline text-sm font-normal')][normalize-space()='Web Application Development']";
            public static string SubMenuOptionXpath => ".//div[contains(@class, 'hidden group-hover:block')]//*[contains(@href,'{0}')]";
        }
    }
}