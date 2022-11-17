using BD.Automation.Core.Drivers.Enums;
using CCESymp.Data;
using CCESymp.Data.Mapping;
using CCESymp.UI.PageObjects;
using CCESymp.UI.Utilities;
using Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using BD.Automation.Core.Drivers.Interface;
using OpenQA.Selenium.Interactions;

namespace CCESymp.UI.TestClasses
{
    [TestFixture]
    public partial class MessageTracingPageTest : BaseTest
    {
        CustomerModel Customer = new();

        private bool Validator { get; set; }
        //CustomerModel Customer = new();

        [TestCase]
        [Category("Message Tracing")]
        [Description("Test Case 1293391: US 1197091 - Message Tracing Home page shall provide the ability to to open three search tabs.")]
        public void AbilityToOpenMultipleEmbeddedTabsinMessageTracing()
        {
            Logger.Info("EXECUTING: Test Case 1293391: US 1197091 - Message Tracing Home page shall provide the ability to open three search tabs.");
            LoginPage.Page.Login(Common.Common.HSCEAutoAdminUser, Common.Common.HSCEAutomationPassword);
            Customer = CustomerPage.Page.OnboardRssCustomerAPI();
            MenuSection.Section.GoToCustomer();
            CustomerPage.Page.EnterCustomerName(Customer.Name);
            CustomerPage.Page.WaitForCustomerResultsToBeDisplayed();
            CustomerPage.Page.ClickCustomerByIndex(0);
            CustomerPage.Page.ClickMessageTracingTab();
            CustomerPage.Page.ClickCloseButton();
            CustomerPage.Page.OpenEmbeddedTabs(3);
            DataRepository.DeleteCustomerByName(Customer.Name);
            Logger.Info("VALIDATION: User should be able to open multiple search tabs");
            Assert.AreEqual(CustomerPage.Page.GetCountOfActiveEmbeddedTabsMessageTracing(), 3, "User does not have the ability to open multiple search tabs");
            Logger.Info("VALIDATION SUCCESS: User is able to open multiple search tabs");

        }

        [TestCase]
        [Category("Message Tracing")]
        [Description("Test Case 1293436: US 1197091 - On Message Tracing Home page If user tries to open 4th search tab then shown an error message.")]
        public void LimitOfOpenedTabsMessageTracing()
        {
            Logger.Info("EXECUTING: Test Case 1293436: US 1197091 - On Message Tracing Home page If user tries to open 4th search tab then shown an error message.");
            LoginPage.Page.Login(Common.Common.HSCEAutoAdminUser, Common.Common.HSCEAutomationPassword);
            Customer = CustomerPage.Page.OnboardRssCustomerAPI();
            MenuSection.Section.GoToCustomer();
            CustomerPage.Page.EnterCustomerName(Customer.Name);
            CustomerPage.Page.WaitForCustomerResultsToBeDisplayed();
            CustomerPage.Page.ClickCustomerByIndex(0);
            CustomerPage.Page.ClickMessageTracingTab();
            CustomerPage.Page.ClickCloseButton();
            CustomerPage.Page.OpenEmbeddedTabs(4);
            DataRepository.DeleteCustomerByName(Customer.Name);
            Logger.Info("VALIDATION: Warning message should be displayed when user reach the maximum limit of opened search tabs");
            Assert.IsTrue(CustomerPage.Page.IsMaxMessageTrackingTabsLimitWarningDisplayed(), "warning for the maximum limit of search tabs is not displayed");
            Logger.Info("VALIDATION SUCCESS: Warning message is displayed when user reach the maximum limit of opened search tabs");
        }

    }

}
