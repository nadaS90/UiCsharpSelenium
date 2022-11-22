using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using CCESymp.Data;
using CCESymp.UI.Utilities;
using Common;

namespace CCESymp.UI.PageObjects
{
    public partial class MainMenu : BasePage<MainMenu>
    {
        /// <summary>
        /// Hover on the MAin Menu tab displayed on the Home page
        /// </summary>
        public void HoverOnMainMenu() 
        {
            Logger.Info("Hover on Main Menu Tab");
            Utilities.MouseHoverToElement(SearchType.ByXpath, MainMenuItemXPath);
        }

        /// <summary>
        /// Verify if the Dropdown options are displayed 
        /// </summary>
        /// <returns></returns>
        public bool IsSubMenuOptionsDisplayed()
        {
            Logger.Info("Check if subMenu is displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, ShowSubMenuDropDownListXPath, 30);
            return ShowSubMenuDropDownList.Displayed;
        }


        /// <summary>
        /// Clicks on required option displayed on the submenu
        /// </summary>
        public void ClickOnSubMenuOption()
        {
            Logger.Info("Click on option displayed in the dropdown sub menu");
            //Utilities.ClickElement(SearchType.ByXpath, Selectors.SubMenuOptionXpath, 20, "Web Application Development");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, SubMenuDropDownOptionXPath);
            SubMenuDropDownOption.Click();
        }

    }
}


