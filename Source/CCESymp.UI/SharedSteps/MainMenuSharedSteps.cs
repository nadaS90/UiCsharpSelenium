using BD.Automation.Core.Drivers.Models;
using CCESymp.UI.PageObjects;
using CCESymp.UI.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.UI.SharedSteps
{
    internal class MainMenuSharedSteps
    {
        public bool SelectOptionFromMainMenuItem(string mainMenuItem, string subMenuItem, string subMenuOption)
        {
            //string subMenuOption
            MainMenu.Page.HoverOnMainMenu(mainMenuItem);

            var subMenuElement = MainMenu.Page.SubMenuDropDownItemElement(subMenuItem);

            if (!MainMenu.Page.IsSubMenuItemOptionsDisplayed(subMenuItem, subMenuElement)) { return false; }
            // MainMenu.Page.ClickOnSDubMenuOption(Constants.arg1);
            
            var optionElement = MainMenu.Page.SubMenuOptionElement(subMenuOption);

            MainMenu.Page.ClickOnSubMenuOption(subMenuOption, optionElement);
            return true;
        }
    }
}
