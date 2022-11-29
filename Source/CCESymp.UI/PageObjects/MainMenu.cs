using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;
using CCESymp.UI.TestData;
using CCESymp.UI.Utilities;


namespace CCESymp.UI.PageObjects
{
    public partial class MainMenu : BasePage<MainMenu>
    {
        /// <summary>
        /// Hover on Services MAin Menu tab displayed on the Home page
        /// </summary>
        public void HoverOnMainMenu(string mainMenuItem) 
        {
            Logger.Info("Hover on Main Menu Tab");
            Utilities.MouseHoverToElement(SearchType.ByXpath, MainMenu.Selectors.MainMenuItemXpath(mainMenuItem));
        }

        /// <summary>
        /// Verify if Services Sub Menu Dropdown options are displayed 
        /// </summary>
        /// <returns></returns>
        public bool IsSubMenuItemOptionsDisplayed(string subMenuItem, IElement element)
        {
            Logger.Info("Check if subMenu is displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, MainMenu.Selectors.SubMenuDropdownXpath(subMenuItem), 30);
            return element.Displayed;
        }


        /// <summary>
        /// Clicks on Web App Dev option displayed on the submenu
        /// </summary>
        public void ClickOnSubMenuOption(string subMenuOption, IElement element)
        {
            Logger.Info("Click on option displayed in the dropdown sub menu");
            //Utilities.ClickElement(SearchType.ByXpath, Selectors.SubMenuOptionXpath, 20, "Web Application Development");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(subMenuOption));
            element.Click();
        }
/*
        /// <summary>
        /// Clicks on Mobile App Dev option displayed on the submenu
        /// </summary>
        public void ClickOnMobileAppDevOption(string subMenuOption)
        {
            Logger.Info("Click on Mobile App Devoption displayed in the dropdown sub menu");
            //Utilities.ClickElement(SearchType.ByXpath, Selectors.SubMenuOptionXpath, 20, "Web Application Development");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(subMenuOption));
            MobileAppOption.Click();
        }

        /// <summary>
        /// Clicks on Automated Testing option displayed on the submenu
        /// </summary>
        public void ClickOnAutomatedTestingOption(string subMenuOption)
        {
            Logger.Info("Click on Automated Testing option displayed in the dropdown sub menu");
            //Utilities.ClickElement(SearchType.ByXpath, Selectors.SubMenuOptionXpath, 20, "Web Application Development");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(subMenuOption));
            AutomatedTestingOption.Click();
        }

        /// <summary>
        /// Clicks on Machine Learning option displayed on the submenu
        /// </summary>
        public void ClickOnMachineLearningOption(string subMenuOption)
        {
            Logger.Info("Click on Machine Learning in the dropdown sub menu");
            //Utilities.ClickElement(SearchType.ByXpath, Selectors.SubMenuOptionXpath, 20, "Web Application Development");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, MainMenu.Selectors.SubMenuOptionXpath(subMenuOption));
            MachineLearningOption.Click();
        }*/

    }
}


