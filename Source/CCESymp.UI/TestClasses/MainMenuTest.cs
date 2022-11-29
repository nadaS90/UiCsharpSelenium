using CCESymp.UI.PageObjects;
using CCESymp.UI.PageObjects.CommonObjects;
using CCESymp.UI.TestData;
using CCESymp.UI.Utilities;
using NUnit.Framework;
using static CCESymp.UI.PageObjects.CommonObjects.CommonPage;
using CCESymp.UI.SharedSteps;
using System;

namespace CCESymp.UI.TestClasses
{

    [TestFixture]

    public partial class MainMenuTest : BaseTest
    {
        private MainMenuSharedSteps sharedSteps;

        public MainMenuTest()
        {
            sharedSteps = new MainMenuSharedSteps();
        }
       

        [TestCase]
        [Category("ServicesMainMenu")]
        [Description("Test Case 1251787: US1400001 - User Hover on Services main menu and select Web Application Development option")]

        public void UserSelectWebAppDevOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.ServicesMainMenu, Constants.ServicesSubMenu, Constants.WebAppDevelopment);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.WebAppDevPageTitle).Contains(Constants.WebAppDevPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("ServicesMainMenu")]
        [Description("Test Case 1251787: US1400002 - User Hover on Services main menu and select Mobile Application Development option")]

        public void UserSelectMobileAppDevOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.ServicesMainMenu, Constants.ServicesSubMenu, Constants.MobileAppDevelopmen);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.MobileAppDevelopmen).Contains(Constants.MobileAppDevelopmen));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("ServicesMainMenu")]
        [Description("Test Case 1251787: US1400003 - User Hover on Services main menu and select Automated Testing Services option")]

        public void UserSelectAutomatedTestingServicesOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.ServicesMainMenu, Constants.ServicesSubMenu, Constants.AutomatedTestingServices);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.AutomatedTestingServices).Contains(Constants.AutomatedTestingServices));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("ServicesMainMenu")]
        [Description("Test Case 1251787: US1400004 - User Hover on Services main menu and select Machine Learning Development option")]

        public void UserSelectMachineLearningDevelopmentOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.ServicesMainMenu, Constants.ServicesSubMenu, Constants.MachineLearningDevelopment);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.MachineLearningDevelopment).Contains(Constants.MachineLearningDevelopment));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("GetStartedMainMenu")]
        [Description("Test Case 1251787: US1400005 - User Hover on Get Started main menu and select Team Roles option")]

        public void UserSelectTeamRolesOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.GetStartedMainMenu, Constants.GetStartedSubMenu, Constants.TeamRoles);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.TeamRolesPageTitle).Contains(Constants.TeamRolesPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("GetStartedMainMenu")]
        [Description("Test Case 1251787: US1400006 - User Hover on Get Started main menu and select Agile Transformation option")]

        public void UserSelectAgileTransformationOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.GetStartedMainMenu, Constants.GetStartedSubMenu, Constants.AgileTransformation);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.AgilePageTitle).Contains(Constants.AgilePageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("GetStartedMainMenu")]
        [Description("Test Case 1251787: US1400007 - User Hover on Get Started main menu and select Hours And Travel option")]

        public void UserSelectHoursAndTravelOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.GetStartedMainMenu, Constants.GetStartedSubMenu, Constants.HoursAndTravel);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.HoursAndTravelPageTitle).Contains(Constants.HoursAndTravelPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("GetStartedMainMenu")]
        [Description("Test Case 1251787: US1400008 - User Hover on Get Started main menu and select 4Plus1 program option")]

        public void UserSelectPlusProgramOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.GetStartedMainMenu, Constants.GetStartedSubMenu, Constants.PlusProgram);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.FourPlusOnePageTitle).Contains(Constants.FourPlusOnePageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("GetStartedMainMenu")]
        [Description("Test Case 1251787: US1400009 - User Hover on Get Started main menu and select Notice Period option")]

        public void UserSelectNoticePeriodOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.GetStartedMainMenu, Constants.GetStartedSubMenu, Constants.NoticePeriod);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.NoticePeriodPageTitle).Contains(Constants.NoticePeriodPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("GetStartedMainMenu")]
        [Description("Test Case 1251787: US1400010 - User Hover on Get Started main menu and select Security option")]

        public void UserSelectSecurityOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.GetStartedMainMenu, Constants.GetStartedSubMenu, Constants.Security);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.SecurityPeriodPageTitle).Contains(Constants.SecurityPeriodPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("GetStartedMainMenu")]
        [Description("Test Case 1251787: US1400011 - User Hover on Get Started main menu and select Case Studies option")]

        public void UserSelectCaseStudiesOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.GetStartedMainMenu, Constants.GetStartedSubMenu, Constants.CaseStudies);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.TopCasesTudiesSubTitle).Contains(Constants.TopCasesTudiesSubTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("AboutMainMenu")]
        [Description("Test Case 1251787: US1400012 - User Hover on About main menu and select Vision option")]

        public void UserSelectVissionOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.AboutMainMenu, Constants.AboutSubMenu, Constants.Vision);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.VisionPageTitle).Contains(Constants.VisionPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("AboutMainMenu")]
        [Description("Test Case 1251787: US1400013 - User Hover on About main menu and select Location option")]

        public void UserSelectLocationOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.AboutMainMenu, Constants.AboutSubMenu, Constants.Location);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.LocationPageTitle).Contains(Constants.LocationPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("AboutMainMenu")]
        [Description("Test Case 1251787: US1400014 - User Hover on About main menu and select LeaderShip option")]

        public void UserSelectLeaderShipOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.AboutMainMenu, Constants.AboutSubMenu, Constants.LeaderShip);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.LeaderShipPageTitle).Contains(Constants.LeaderShipPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("AboutMainMenu")]
        [Description("Test Case 1251787: US1400015 - User Hover on About main menu and select Careers option")]

        public void UserSelectCareersOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.AboutMainMenu, Constants.AboutSubMenu, Constants.Careers);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.CareersPageTitle).Contains(Constants.CareersPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("AboutMainMenu")]
        [Description("Test Case 1251787: US1400016 - User Hover on About main menu and select Technologies option")]

        public void UserSelectTechnologiesOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.AboutMainMenu, Constants.AboutSubMenu, Constants.Technologies);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.TechnologiesPageTitle).Contains(Constants.TechnologiesPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("AboutMainMenu")]
        [Description("Test Case 1251787: US1400017 - User Hover on About main menu and select Blog option")]

        public void UserSelectBlogOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.AboutMainMenu, Constants.AboutSubMenu, Constants.Blog);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.BlogSubTitle).Contains(Constants.BlogSubTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("IndustriesMainMenu")]
        [Description("Test Case 1251787: US1400018 - User Hover on Industries main menu and select Life Sciences option")]

        public void UserSelectLifeSciencesOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.IndustriesMainMenu, Constants.IndustriesSubMenu, Constants.LifeSciences);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.LifeSciencesPageTitle).Contains(Constants.LifeSciencesPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("IndustriesMainMenu")]
        [Description("Test Case 1251787: US1400019 - User Hover on Industries main menu and select Manufactoring option")]

        public void UserSelectManufactoringOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.IndustriesMainMenu, Constants.IndustriesSubMenu, Constants.Manufactoring);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.ManufactoringPageTitle).Contains(Constants.ManufactoringPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("IndustriesMainMenu")]
        [Description("Test Case 1251787:20 - User Hover on Industries main menu and select Finance & Banking option")]

        public void UserSelectFinanceAndBankingOption()
        {
            Logger.Info("VALIDATION: Hover on main menu and select an option from the sub menu displayed");
            bool isSelectDone = sharedSteps.SelectOptionFromMainMenuItem(Constants.IndustriesMainMenu, Constants.IndustriesSubMenu, Constants.FinancewAndBanking);
            Logger.Info("VALIDATION SUCCESS: option from the sub menu displayed and selected");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isSelectDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.FinancewAndBankingPageTitle).Contains(Constants.FinancewAndBankingPageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
        }

        [TestCase]
        [Category("CodeVoyanceMainMenu")]
        [Description("Test Case 1251787:20 - User Hover on CodeVoyance main menu and select CodeVoyance option")]

        public void UserSelectCodeVoyanceOption()
        {
            Logger.Info("VALIDATION: click on main menu and navigated to the required page");
            bool isClickDone = sharedSteps.ClickOnMainMenuItem(Constants.CodeVoyanceMainMenu);
            Logger.Info("VALIDATION SUCCESS: navigated to the required page");
            Logger.Info("VALIDATION: Required page is loaded and page title displayed");
            Assert.IsTrue(isClickDone && CommonPage.CommonSelectors.PageTitleHeaderXpath(Constants.CodeVoyancePageTitle).Contains(Constants.CodeVoyancePageTitle));
            Logger.Info("VALIDATION SUCCESS: Page title displayed when user navegates to it");
            

        }
    }
}


