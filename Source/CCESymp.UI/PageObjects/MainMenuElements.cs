using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;
using CCESymp.UI.TestData;

namespace CCESymp.UI.PageObjects
{
    public partial class MainMenu
    {
        //private string MainMenuItemXPath => string.Format(Selectors.MainMenuItemXpath, TestData.Constants.ServicesMAinMenu);
        //private string ShowSubMenuDropDownListXPath => string.Format(Selectors.ShowSubMenuDropdownXpath, TestData.Constants.ServicesSubMenu);
        //private string SubMenuDropDownOptionXPath => string.Format(Selectors.SubMenuOptionXpath, TestData.Constants.WebAppDevelopment);

        private IElement MainMenuItem => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.MainMenuItemXpath(Constants.ServicesMAinMenu));
        private IElement ShowSubMenuDropDownList => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.ShowSubMenuDropdownXpath(Constants.ServicesSubMenu));
        private IElement SubMenuDropDownOption => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(Constants.WebAppDevelopment));
    }
}
