using OpenQA.Selenium.Interactions;
namespace CCESymp.UI.Utilities
{
    public class BasePage<TypeOfPage> : BaseDriver where TypeOfPage : new()
    {
        private static TypeOfPage page;
        protected Wrappers Utilities = new Wrappers();
        protected TablesUtility tablesUtilities = new TablesUtility(driver);

        /// <summary>
        /// Holds the new created instance of the page
        /// </summary>
        public static TypeOfPage Page
        {
            get
            {
                if (page == null)
                {
                    page = new TypeOfPage();                   
                    
                }
                return page;
            }
        }       

        /// <summary>
        /// Refesh the current page
        /// </summary>
        public void RefreshPage()
        {
            driver.Navigation.Refresh();
        }

        /// <summary>
        /// Hover on tabs in current page
        /// </summary>
        public void HoverTab(IElement mainMenu, IElement subMenu)
        {
            Actions actions = new Actions(driver);
            actions.moveToElement(element).perform();
            actions.moveToElement(subMenu).click();
           // actions.click().build().perform();
        }

    }
}
