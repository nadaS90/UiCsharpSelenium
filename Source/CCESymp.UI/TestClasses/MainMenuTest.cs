using CCESymp.UI.PageObjects;
using CCESymp.UI.PageObjects.CommonObjects;
using CCESymp.UI.TestData;
using CCESymp.UI.Utilities;
using NUnit.Framework;
using static CCESymp.UI.PageObjects.CommonObjects.CommonPage;

namespace CCESymp.UI.TestClasses
{
    [TestFixture]

    public partial class MainMenuTest : BaseTest
    {


        [TestCase]
        [Category("MainMenu")]
        [Description("Test Case 1251787: US1400001 - Hover on common main menu displayed on all pages")]

        public void HoverOnMainMenu()
        {
            Logger.Info("EXECUTING: Test Case 1251787: US1400001 - Hover on common main menu displayed on all pages");
            MainMenu.Page.HoverOnMainMenu();
            Logger.Info("VALIDATION: sub menu options dropdown should be displayed");
            Assert.IsTrue(MainMenu.Page.IsSubMenuOptionsDisplayed(), "sub menu options dropdown is not displayed");
            Logger.Info("VALIDATION SUCCESS: sub menu options dropdown is displayed!");

            Logger.Info("VALIDATION: sub menu options dropdown should be displayed");
            Assert.IsTrue(MainMenu.Page.IsSubMenuOptionsDisplayed(), "sub menu options dropdown is not displayed");
            Logger.Info("VALIDATION SUCCESS: sub menu options dropdown is displayed!");
            MainMenu.Page.ClickOnSubMenuOption();

            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.WebAppDevPageTitle).Contains(Constants.WebAppDevPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }
    }
}
