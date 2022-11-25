using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.UI.PageObjects.CommonObjects
{
    public partial class CommonPage
    {
        public static class CommonSelectors
        {

            //public static string PageTitleHeaderXpath => "//div[@class='title']";
            public static string PageTitleHeaderXpath(string pageTitle) => $"//div[text()='{pageTitle}']";
            public static string GetStartedBtnXpath => "//*[contains(@class,'button-group')]//child::a[text()='Get Started']";
            //public static string SubTitleHeaderXpath => "//p[text()='{0}']";
            public static string SubTitleHeaderXpath => "//div[@class='sub-title-header text-black-500']";
            //public static string CardContentXpath => "//div[@class='lg:mt-16 mt-6']//descendant::div[contains(text(),'{0}')]";
            public static string CardContentLinkXpath => "//div[@class='grid grid-cols-1 lg:grid-cols-12 stories-container gap-3']";
            public static string ExploreMoreBtnXpath(string ExploreMoreButton) => $"//*[contains(@href,'{ExploreMoreButton}')]//parent::div";

        }
    }
}
