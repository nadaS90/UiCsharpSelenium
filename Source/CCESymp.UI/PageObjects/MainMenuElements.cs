using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;
using CCESymp.UI.PageObjects.CommonObjects;
using CCESymp.UI.TestData;

namespace CCESymp.UI.PageObjects
{
    public partial class MainMenu
    {
        //public string MainMenuItemXPath => string.Format(Selectors.MainMenuItemXpath, TestData.Constants.ServicesMAinMenu);
        //public string ShowSubMenuDropDownListXPath => string.Format(Selectors.ShowSubMenuDropdownXpath, TestData.Constants.ServicesSubMenu);
        //public string SubMenuDropDownOptionXPath => string.Format(Selectors.SubMenuOptionXpath, TestData.Constants.WebAppDevelopment);

        public IElement MainMenuItemElement(string mainMenuItem) => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.MainMenuItemXpath(mainMenuItem));
        //public IElement MainMenuGetStarted => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.MainMenuItemXpath(Constants.GetStartedMainMenu));
        //public IElement MainMenuAbout => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.MainMenuItemXpath(Constants.AboutMainMenu));
        //public IElement MainMenuServices => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.MainMenuItemXpath(Constants.ServicesMainMenu));
        //public IElement MainMenuIndustries => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.MainMenuItemXpath(Constants.IndustriesMainMenu));
        //public IElement MainMenuCodeVoyance => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.MainMenuItemXpath(Constants.CodeVoyanceMainMenu));

        public IElement SubMenuDropDownItemElement(string subMenuItem) => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuDropdownXpath(subMenuItem));
        //public IElement SubMenuGetStartedDropDown => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuDropdownXpath(Constants.GetStartedSubMenu));
        //public IElement SubMenuAboutDropDown => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuDropdownXpath(Constants.AboutSubMenu));
        //public IElement SubMenuServicesDropDown => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuDropdownXpath(Constants.ServicesSubMenu));
        //public IElement SubMenuIndustriesDropDown => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuDropdownXpath(Constants.IndustriesSubMenu));

        public IElement SubMenuOptionElement(string subMenuOption) => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(subMenuOption));
        //public IElement WebAppOption => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(Constants.WebAppDevelopment));
        //public IElement MobileAppOption => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(Constants.MobileAppDevelopmen));
        //public IElement AutomatedTestingOption => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(Constants.AutomatedTestingServices));
        //public IElement MachineLearningOption => driver.Element.GetElement(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(Constants.MachineLearningDevelopment));

    }
}
