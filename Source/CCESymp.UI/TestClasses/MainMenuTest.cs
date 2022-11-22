using CCESymp.UI.PageObjects;
using CCESymp.UI.Utilities;
using NUnit.Framework;

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
            Logger.Info("VALIDATION: user navigated to the required page that matches the selected sub menu option");
            // add validation from H1 tittle in each page

        }
    }
}
