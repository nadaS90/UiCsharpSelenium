using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;
using CCESymp.UI.PageObjects.CommonObjects;
using CCESymp.UI.TestData;

namespace CCESymp.UI.PageObjects
{
    public partial class MainMenu
    {
        public IElement MainMenuItemElement(string mainMenuItem) => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.MainMenuItemXpath(mainMenuItem));
        public IElement SubMenuDropDownItemElement(string subMenuItem) => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuDropdownXpath(subMenuItem));
        public IElement SubMenuOptionElement(string subMenuOption) => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(subMenuOption));

    }
}
