using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.UI.PageObjects
{
    public partial class MenuSection
    {
        private IElement NavigationBar => driver.Element.GetElement(SearchType.ByXpath, Selectors.NavigationBarXpath);
        private IElement CustomerTab => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerTabXpath);
        private IElement HomePageTab => driver.Element.GetElement(SearchType.ByXpath, Selectors.HomePageTabXpath);
    }
}
