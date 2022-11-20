using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.UI.PageObjects
{
    public partial class HomePage : BasePage<HomePage>
    {
        /// <summary>
        /// Hover on the Service tab displayed on the Home page
        /// </summary>
        public void MainMenu() => Utilities.MouseHoverToElement(SearchType.ByXpath, Selectors.ServicesTabXpath);


        /// <summary>
        /// Clicks on Web Application Development option displayed on the Service dropdown menu
        /// </summary>
        public void SubMenu()=> Utilities.ClickElement(SearchType.ByXpath, Selectors.WebAppDevXpath, 20, "Web Application Development");

    }
}


