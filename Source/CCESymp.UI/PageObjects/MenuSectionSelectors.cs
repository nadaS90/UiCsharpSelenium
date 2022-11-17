using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.UI.PageObjects
{
    public partial class MenuSection
    {
        private class Selectors
        {
            public static string CustomerTabXpath = "//a[contains(text(), 'CUSTOMER')]";
            public static string HomePageTabXpath = "//a[contains(text(), 'HOME')]";
            public static string NavigationBarXpath = "//div[@id='subnavItems']";

        }
    }
}
