namespace CCESymp.UI.PageObjects
{
    public partial class MainMenu
    {
        private class Selectors
        {
            public static string MainMenuItemXpath(string mainMenu) => $"//div[contains(@class,'flex items-center m-2')]//a[normalize-space()='{mainMenu}']";
            public static string ShowSubMenuDropdownXpath(string subMenu) => $".//div[{subMenu}]/div[1]/div[2]/ul[1]";  
            public static string SubMenuOptionXpath(string subMenuOption) => $".//div[contains(@class, 'hidden group-hover:block')]//*[contains(@href,'{subMenuOption}')]";
        }
    }
}