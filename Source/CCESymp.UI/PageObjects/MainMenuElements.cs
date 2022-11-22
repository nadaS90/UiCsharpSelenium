using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;

namespace CCESymp.UI.PageObjects
{
    public partial class MainMenu
    {
        private string MainMenuItemXPath => string.Format(Selectors.MainMenuItemXpath, TestData.Constants.ServicesMAinMenu);
        private string ShowSubMenuDropDownListXPath => string.Format(Selectors.ShowSubMenuDropdownXpath, TestData.Constants.ServicesSubMenu);
        private string SubMenuDropDownOptionXPath => string.Format(Selectors.SubMenuOptionXpath, TestData.Constants.WebAppDevelopment);

        private IElement MainMenuItem => driver.Element.GetElement(SearchType.ByXpath, MainMenuItemXPath);
        private IElement ShowSubMenuDropDownList => driver.Element.GetElement(SearchType.ByXpath, ShowSubMenuDropDownListXPath);
        private IElement SubMenuDropDownOption => driver.Element.GetElement(SearchType.ByXpath, SubMenuDropDownOptionXPath);


    }
}
