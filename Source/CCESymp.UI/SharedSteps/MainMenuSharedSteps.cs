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
            MainMenu.Page.HoverOnMainMenu(mainMenuItem);

            var subMenuElement = MainMenu.Page.SubMenuDropDownItemElement(subMenuItem);
            if (!MainMenu.Page.IsSubMenuItemOptionsDisplayed(subMenuItem, subMenuElement)) 
            { return false; }

            var optionElement = MainMenu.Page.SubMenuOptionElement(subMenuOption);
            MainMenu.Page.ClickOnSubMenuOption(subMenuOption, optionElement);
            return true;
        }

        public bool ClickOnMainMenuItem(string mainMenuTab)
        {
            var mainMenuElement = MainMenu.Page.MainMenuItemElement(mainMenuTab);
            MainMenu.Page.ClickOnMainMenu(mainMenuTab, mainMenuElement);
            return true;
        }

    }
}
