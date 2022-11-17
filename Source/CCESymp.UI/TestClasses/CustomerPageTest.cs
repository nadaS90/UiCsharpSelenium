using CCESymp.API.Services;
using CCESymp.Data.Mapping;
using CCESymp.Data;
using CCESymp.UI.PageObjects;
using CCESymp.UI.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCESymp.UI.TestClasses
{
    [TestFixture]
    public partial class CustomerPageTest : BaseTest
    {
        RSSCustomerService RSSService = new();
        CustomerModel Customer = new();
        RssCustomers RSSCustomer = new();
        RssFacility RSSFacility = new();
        private static readonly string NonExistingCustomer = "%$#%#3q45rwqef3f";

       
        [TestCase]
        [Category("CustomerPage")]
        [Description("Test Case 1251787: US1204609 - Dropdown to configure number of results displayed in On Board customer search")]
        public void CCESymphonyDropDownToConfigureResults()
        {
            Logger.Info("EXECUTING: Test Case 1251787: US1204609 - Dropdown to configure number of results displayed in On Board customer search");
            DataRepository.InsertCustomerData();
            List<string> expectedValuesFromDropdown = new() { "10", "25", "50", "100" };

            LoginPage.Page.Login(Common.Common.HSCEAutoAdminUser, Common.Common.HSCEAutomationPassword);
            MenuSection.Section.GoToCustomer();
            CustomerPage.Page.ClickOnBoardACustomerLink();
            CustomerPage.Page.WaitForOnBoardPageDisplayed();
            CustomerPage.Page.EnterCustomerName(RSSService.GetConcurrentCustomerWord(70));
            CustomerPage.Page.WaitForCustomerResultsToBeDisplayed();

            Logger.Info("VALIDATION: Show Rows dropdown should be displayed");
            Assert.IsTrue(CustomerPage.Page.IsShowRowsDropdownDisplayed(), "The Show rows dropdown is not displayed");
            Logger.Info("VALIDATION SUCCESS: Show Rows dropdown is displayed!");
            Logger.Info("VALIDATION: 25 should selected by default");
            Assert.IsTrue(CustomerPage.Page.IsDropDownDefaultValueSelected(), "Value selected by default is not 25");
            Logger.Info("VALIDATION SUCCESS: 25 is selected by default");
            Logger.Info("VALIDATION: Following values should be displayed in the Show Rows dropdown: 10, 25, 50 and 100");
            CollectionAssert.AreEquivalent(expectedValuesFromDropdown, CustomerPage.Page.GetOptionsFromDropdown(), "The expected values where not displayed in the dropdown");
            Logger.Info("VALIDATION SUCCESS: The following values are displayed in the Show Rows dropdown: 10, 25, 50 and 100");
            DataRepository.DeleteCustomerData();
        }

        [TestCase]
        [Category("CustomerPage")]
        [Description("Test Case 1251900: US1204609 - Select number of results displayed in the Show rows dropdown")]
        public void CCESymphonyDisplayAmountOfResultsSelectedFromDropdown()
        {
            Logger.Info("EXECUTING: Test Case 1251900: US1204609 - Select number of results displayed in the Show rows dropdown");
            DataRepository.InsertCustomerData();
            LoginPage.Page.Login(Common.Common.HSCEAutoAdminUser, Common.Common.HSCEAutomationPassword);
            MenuSection.Section.GoToCustomer();
            CustomerPage.Page.ClickOnBoardACustomerLink();
            CustomerPage.Page.WaitForOnBoardPageDisplayed();
            CustomerPage.Page.EnterCustomerName(RSSService.GetConcurrentCustomerWord(70));
            CustomerPage.Page.WaitForCustomerResultsToBeDisplayed();
            CustomerPage.Page.SelectShowRowsOption("10");
            Logger.Info("VALIDATION: Amount of results displayed should match the option selected in Show Rows dropdown");
            Assert.IsTrue(CustomerPage.Page.IsTheCorrectAmountOfResultsDisplayedPerPage(), "The results displayed per page are not equal to the one selected in the dropdown");
            Logger.Info("VALIDATION SUCCESS: Amount of results displayed match the option selected in Show Rows dropdown");
            DataRepository.DeleteCustomerData();
        }

        [TestCase]
        [Category("CustomerPage")]
        [Description("Test Case 1251920: US1204609 - Pagination should be displayed when total of results are greater than the configured amount of rows per page")]
        public void CCESymphonyPaginationIsAvailable()
        {
            Logger.Info("EXECUTING: Test Case 1251920: US1204609 - Pagination should be displayed when total of results are greater than the configured amount of rows per page");
            DataRepository.InsertCustomerData();
            LoginPage.Page.Login(Common.Common.HSCEAutoAdminUser, Common.Common.HSCEAutomationPassword);
            MenuSection.Section.GoToCustomer();
            CustomerPage.Page.ClickOnBoardACustomerLink();
            CustomerPage.Page.WaitForOnBoardPageDisplayed();
            CustomerPage.Page.EnterCustomerName(RSSService.GetConcurrentCustomerWord(70));
            CustomerPage.Page.WaitForCustomerResultsToBeDisplayed();
            CustomerPage.Page.SelectShowRowsOption("10");
            Logger.Info("VALIDATION: Pagination should be available and user should be able to see all the results by using the pagination");
            Assert.IsTrue(CustomerPage.Page.IsPaginationDisplayed(), "Pagination is not available");
            Assert.IsTrue(CustomerPage.Page.IsUserAbleToSeeAllResultsUsingThePagination(), "User is not able to see all the results using pagination");
            Logger.Info("VALIDATION SUCCESS: Pagination is available and user should is able to see all the results by using the pagination");

            DataRepository.DeleteCustomerData();
        }

        
    }
}
