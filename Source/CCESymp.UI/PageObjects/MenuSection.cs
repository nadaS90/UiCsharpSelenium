using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using CCESymp.UI.Utilities;

namespace CCESymp.UI.PageObjects
{
    public partial class MenuSection : GlobalPageSection<MenuSection>
    {
        /// <summary>
        /// Clicks on the home tab
        /// </summary>
        private void ClickHomeTab() => Utilities.ClickElement(SearchType.ByXpath, Selectors.HomePageTabXpath, 20, "Click Home Tab");

        /// <summary>
        /// Navigate to Home Page
        /// </summary>
        public void GoToHome()
        {
            Logger.Info("Navigate To Home Page");
            ClickHomeTab();
        }

        /// <summary>
        /// Navigate to Customer Page
        /// </summary>
        public void GoToCustomer()
        {
            Logger.Info("Navigate To Customer Page");
            ClickCustomerTab();
        }       

        /// <summary>
        /// Click on the Customer tab
        /// </summary>
        private void ClickCustomerTab()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerTabXpath);
            CustomerTab.Click();
        }

        /// <summary>
        /// Open Customer page in a new tab
        /// </summary>
        public void OpenCustomerPageInNewTab()
        {
            Logger.Info("Opening customer page in a new browser tab");
            driver.Wait.UntilElementToBeClickable(SearchType.ByXpath, Selectors.CustomerTabXpath);
            OpenInNewTab(CustomerTab);
        }

        /// <summary>
        /// Open Home page in a new tab
        /// </summary>
        public void OpenHomePageInNewTab()
        {
            Logger.Info("Opening home page in a new browser tab");
            OpenInNewTab(HomePageTab);
        }

        /// <summary>
        /// Open Home page in a new window
        /// </summary>
        public void OpenHomePageInNewWindow()
        {
            Logger.Info("Opening home page in a new browser window");
            OpenInNewWindow(HomePageTab);
        }

        //private void ClickAdministrationTab()
        //{
        //    _webDriver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.AdministrationTabXpath);
        //    AdministrationTab.Click();
        //}

        //public void GoToAdministration()
        //{
        //    Logger.Info("Navigating To Administration Page");
        //    ClickAdministrationTab();
        //}
    }
}
