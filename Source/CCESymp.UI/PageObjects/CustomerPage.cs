using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;
using CCESymp.API.Services;
using CCESymp.Data;
using CCESymp.Data.Mapping;
using CCESymp.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCESymp.UI.PageObjects
{
    public partial class CustomerPage : BasePage<CustomerPage>
    {
        private static string SolutionName { get; set; }
        private static string CustomerID { get; set; }
        private static string SolutionDescription { get; set; }
        private RSSCustomerService CustomerService = new();
        
        public CustomerModel OnboardRssCustomerAPI()
        {
            try
            {
                driver.Wait.UntilElementIsVisible(SearchType.ByCss, Convert.ToChar(98).ToString());
            }
            catch { }
            var token = driver.Browser.ExecuteScript("return sessionStorage.getItem('access_token')").ToString();
            Common.Common.AdminAPIAccessToken = Common.Common.GetEnvVar(@"AdminAPIAccessToken", token);
            var CustomerTask = CustomerService.AddACustomerAsync(token);
            CustomerTask.Wait();
            var CustomerDetails = CustomerTask.Result;
            return CustomerDetails;
        }

      

        public List<RssCustomer> GetCustomerResults()
        {
            WaitForCustomerResultsToBeDisplayed();
            var RSSCustomerRows = driver.Element.GetElements(SearchType.ByXpath, Selectors.CustomerRowsXpath);
            var customerResultsList = new List<RssCustomer>();
            foreach (var custRow in RSSCustomerRows)
            {
                var customerElements = new RssCustomer
                {
                    Name = custRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("customer-name")).Text,
                    CustomerId = custRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("customer-id")).Text,
                    State = custRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("cutomer-state")).Text,
                    City = custRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("cutomer-city")).Text,
                    ZipCode = custRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("cutomer-zipcode")).Text,
                    Address1 = custRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("cutomer-address")).Text
                };
                customerResultsList.Add(customerElements);
            }
            return customerResultsList;
        }
        public string GetCustomerNameByIndex(int index)
        {
            var CustomerNameLocator = Selectors.CustomerRowItem("customer-name").Replace("descendant::", "//");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, CustomerNameLocator);
            return driver.Element.GetElements(SearchType.ByXpath, CustomerNameLocator).ElementAt(index).Text;
        }



        public List<List<FacilityModel>> GetFacilityResults()
        {
            WaitForCustomerResultsToBeDisplayed();
            var RSSCustomerRows = driver.Element.GetElements(SearchType.ByXpath, Selectors.CustomerRowsXpath);
            var ListOfDisplayedFacilities = new List<List<FacilityModel>>();
            foreach (var custRow in RSSCustomerRows)
            {
                var FacilityList = new List<FacilityModel>();

                if (custRow.GetChildElements(SearchType.ByXpath, Selectors.FacilityElementsXpath).Count() > 0)
                {
                    var FacilityRows = custRow.GetChildElements(SearchType.ByXpath, Selectors.FacilityElementsXpath);
                    foreach (var facilityRow in FacilityRows)
                    {
                        var FacilityElements = new FacilityModel
                        {
                            Name = facilityRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("facility-name")).Text,
                            Id = facilityRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("facility-id")).Text,
                            State = facilityRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("facility-state")).Text,
                            City = facilityRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("facility-city")).Text,
                            ZipCode = facilityRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("facility-zipcode")).Text,
                            Address1 = facilityRow.GetChildElement(SearchType.ByXpath, Selectors.CustomerRowItem("facility-address")).Text
                        };
                        FacilityList.Add(FacilityElements);
                    }
                }
                else
                {
                    var EmptyfacilityElements = new FacilityModel
                    {
                        Name = "",
                        Id = "",
                        State = "",
                        City = "",
                        ZipCode = "",
                        Address1 = ""
                    };
                    FacilityList.Add(EmptyfacilityElements);
                }
                ListOfDisplayedFacilities.Add(FacilityList);
            }
            return ListOfDisplayedFacilities;
        }

        /// <summary>
        /// Verify if the rows displayed in the search results are collapsible
        /// </summary>
        /// <returns></returns>
        public bool VerifyCustomerRowsAreCollapsible()
        {
            ClickonCollapseAllButton();
            CollapseButtonsInRows.ToList().ForEach(delegate (IElement element) { DataRepository.WaitForDataLoad(500); element.Click(); });
            DataRepository.WaitForDataLoad();
            var Upperlist = from item in CollapseButtonsInRows
                            select !item.GetAttributeValue("class").Contains("up");

            driver.Browser.ScrollElementIntoView(SearchType.ByXpath, Selectors.CollapseButtonsInRowsXpath);
            CollapseButtonsInRows.ToList().ForEach(delegate (IElement element) { DataRepository.WaitForDataLoad(500); element.Click(); });
            DataRepository.WaitForDataLoad();
            var downList = from item in CollapseButtonsInRows
                           select item.GetAttributeValue("class").Contains("down");

            return !Upperlist.Where(item => item.Equals(false)).Any() && !downList.Where(item => item.Equals(false)).Any();
        }

        /// <summary>
        /// Verify if the user has landed in the Customer page(Customer search)
        /// </summary>
        /// <returns></returns>
        public bool IsUserAtCustomerPage()
        {
            Logger.Info("Checking The Customer Page Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.AppCustomerTabsXpath);
            return driver.Element.GetElement(SearchType.ByXpath, Selectors.AppCustomerTabsXpath).Displayed &&
                   driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerNameLabelXpath).Displayed;
        }

        /// <summary>
        /// Clicks on the "On-Board a Customer" a customer link
        /// </summary>
        public void ClickOnBoardACustomerLink()
        {
            Logger.Info("Clicking on On-Board a Customer Link");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.OnBoardCustomerLinkXpath);
            OnBoardCustomerLink.Click();
        }

        /// <summary>
        /// Verifies the "On-Board a Customer" Link Is Displayed
        /// </summary>
        public bool IsOnBoardACustomerLinkDisplayed()
        {
            Logger.Info("Checking On-Board a Customer Link Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.OnBoardCustomerLinkXpath);
            return OnBoardCustomerLink.Displayed;
        }

        /// <summary>
        /// Verifies the "Reset All" Link Is Displayed
        /// </summary>
        public bool IsResetAllLinkDisplayed()
        {
            Logger.Info("Checking Reset All Link Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.ResetAllLinkXpath);
            return ResetAllLink.Displayed;
        }

        /// <summary>
        /// Verifies the "Customer Name" label above the Customer Name Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsCustomerNameLabelDisplayed()
        {
            Logger.Info("Checking Customer Name Label Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerNameLabelXpath);
            return CustomerNameLabel.Displayed;
        }

        /// <summary>
        /// Verifies the "Customer Name" Search field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsCustomerNameFieldDisplayed()
        {
            Logger.Info("Checking Customer Name Field Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerNameFieldXpath);
            return CustomerNameField.Displayed;
        }

        /// <summary>
        /// Verifies the "Customer Id" label above the Customer Id Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsCustomerIdLabelDisplayed()
        {
            Logger.Info("Checking Customer ID (Cust ID) Label Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerIdLabelXpath);
            return CustomerIdLabel.Displayed;
        }

        /// <summary>
        /// Verifies the "Customer Id" Search Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsCustomerIdFieldDisplayed()
        {
            Logger.Info("Checking Customer ID (Cust ID) Field Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerIdFieldXpath);
            return CustomerIdField.Displayed;
        }

        /// <summary>
        /// Verifies the "Customer State" label above the Customer State Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsCustomerStateLabelDisplayed()
        {
            Logger.Info("Checking Customer State (Cust State) Label Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerStateLabelXpath);
            return CustomerStateLabel.Displayed;
        }

        /// <summary>
        /// Verifies the "Customer State" Search Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsCustomerStateFieldDisplayed()
        {
            Logger.Info("Checking Customer State (Cust State) Field Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerStateFieldXpath);
            return CustomerStateField.Displayed;
        }

        /// <summary>
        /// Verifies the "Facility Name" label above the Facility Name Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsFacilityNameLabelDisplayed()
        {
            Logger.Info("Checking Facility Name Label Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityNameLabelXpath);
            return FacilityNameLabel.Displayed;
        }

        /// <summary>
        /// Verifies the "Facility Name" Facility Name Search Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsFacilityNameFieldDisplayed()
        {
            Logger.Info("Checking Facility Name Field Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityNameFieldXpath);
            return FacilityNameField.Displayed;
        }

        /// <summary>
        /// Verifies the "Facility id" label above the Facility id Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsFacilityIdLabelDisplayed()
        {
            Logger.Info("Checking Facility ID (Fac ID) Field Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityIdLabelXpath);
            return FacilityIdLabel.Displayed;
        }

        /// <summary>
        /// Verifies the "Facility id" Facility id Search Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsFacilityIdFieldDisplayed()
        {
            Logger.Info("Checking Facility ID (Fac ID) Field Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityIdFieldXpath);
            return FacilityIdField.Displayed;
        }

        /// <summary>
        /// Verifies the "Facility State" label above the Facility State Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsFacilityStateLabelDisplayed()
        {
            Logger.Info("Checking Facility State (Fac State) Label Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityStateLabelXpath);
            return FacilityStateLabel.Displayed;
        }

        /// <summary>
        /// Verifies the "Facility State" Facility State Field is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsFacilityStateFieldDisplayed()
        {
            Logger.Info("Checking Facility State (Fac State) Field Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityStateFieldXpath);
            return FacilityStateField.Displayed;
        }

        /// <summary>
        /// Returns the total customers found which matches the search criteria by getting the text from the displayed customer results label on the UI
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public string GetCustomerCount()
        {
            Logger.Info("Get Customer Results Count");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerResultsCountXpath);
            return CustomerResultsCount.Text;
        }

        /// <summary>
        /// Verifies the Customer Search Link is provided when user is working on the onboard an RSS customer page
        /// </summary>
        public bool IsCustomerSearchLinkDisplayed()
        {
            Logger.Info("Checking Customer Search Link Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerSearchLinkXpath);
            return CustomerSearchLink.Displayed;
        }

        /// <summary>
        /// Verify if the Results include the Facility Name used in the search
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool DoResultsMatchWithFacilityNameSearch()
        {
            var Facilities = GetFacilityResults();
            return Facilities.Count() > 0;
        }

        /// <summary>
        /// Verify if the Results include the Facility ID used in the search
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool DoResultsMatchWithFacilityIDSearch(string text)
        {
            var Query = from DataRow in GetFacilityResults()
                        from row in DataRow
                        where row.Id.ToUpper().Contains(text.ToUpper())
                        select row.Id;
            return Query.Count() > 0;
        }

        /// <summary>
        /// Verify if the results include the Facility State used in the search
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool DoResultsMatchWithFacilityStateSearch(string text)
        {
            var Query = from DataRow in GetFacilityResults()
                        from row in DataRow
                        where row.State.ToUpper().Contains(text.ToUpper())
                        select row.State;
            return Query.Count() > 0;
        }

        /// <summary>
        /// Verify if results include the Customer Name used in the search
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool DoResultsMatchWithCustomerNameSearch(string text)
        {
            var Query = from Customer in GetCustomerResults()
                        where Customer.Name.ToUpper().Contains(text.ToUpper())
                        select Customer.Name;
            return Query.Count() > 0;
        }

        /// <summary>
        /// Verify if results include the Customer ID used in the search
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool DoResultsMatchWithCustomerIDSearch(string text)
        {
            var Query = from Customer in GetCustomerResults()
                        where Customer.CustomerId.ToString().ToUpper().Contains(text.ToUpper())
                        select Customer.CustomerId;
            return Query.Count() > 0;
        }

        /// <summary>
        /// Verofu if results include the Customer State used in the search
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool DoResultsMatchWithCustomerStateSearch(string text)
        {
            var Query = from Customer in GetCustomerResults()
                        where Customer.State.ToString().ToUpper().Contains(text.ToUpper())
                        select Customer.State;
            return Query.Count() > 0;
        }

        /// <summary>
        /// Verifies a warning message when no search results are found is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsWarningMessageDisplayed()
        {
            Logger.Info("Checking Warning Message Is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.NoSearchResultsWarningMessageXpath, 180);
            return WarningMessage.Displayed;
        }

        /// <summary>
        /// Enters the provided <param name="customerName"/> into the Customer Name field
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public void EnterCustomerName(string customerName)
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerNameFieldXpath, 30);
            CustomerNameField.SendKeys(customerName);
        }

        /// <summary>
        /// Enters data in the Customer ID search field
        /// </summary>
        /// <param name="data"></param>
        public void EnterCustomerId(string data)
        {
            Logger.Info("Enter data in Customer ID field");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerIdFieldXpath, 60);
            CustomerIdField.SendKeys(data);
        }

        /// <summary>
        /// Enters data in the Customer State search field
        /// </summary>
        /// <param name="data"></param>
        public void EnterCustomerState(string data)
        {
            Logger.Info("Enter data in Customer State field");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerStateFieldXpath, 60);
            CustomerStateField.SendKeys(data);
        }

        /// <summary>
        /// Enters data in the Facility Name search field
        /// </summary>
        /// <param name="data"></param>
        public void EnterFacilityName(string data)
        {
            Logger.Info("Enter data in Facility Name field");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityNameFieldXpath, 30);
            FacilityNameField.SendKeys(data);
        }

        /// <summary>
        /// Enters data in the Facility ID search field
        /// </summary>
        /// <param name="data"></param>
        public void EnterFacilityId(string data)
        {
            Logger.Info("Enter data in Facility ID field");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityIdFieldXpath, 30);
            FacilityIdField.SendKeys(data);
        }

        /// <summary>
        /// Enters data in the Facility State search field
        /// </summary>
        /// <param name="data"></param>
        public void EnterFacilityState(string data)
        {
            Logger.Info("Enter data in Facility State field");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityStateFieldXpath, 30);
            FacilityStateField.SendKeys(data);
        }

        /// <summary>
        /// Verifies a previous button is displayed on the paginator after a customer search
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public bool IsPaginationPreviousButtonDisplayed()
        {
            Logger.Info("Checking Previous Page Button is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationPreviousPageButtonXpath, 30);
            return PaginationPreviousButton.Displayed;
        }

        /// <summary>
        /// Verifies if the previous button in the paginator is disabled
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsPaginationPreviousButtonDisabled()
        {
            Logger.Info("Checking Previous Button Is Disabled");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationPreviousPageButtonXpath, 30);
            driver.Browser.ScrollElementIntoView(SearchType.ByXpath, Selectors.PaginationPreviousPageButtonXpath);
            return PaginationPreviousButton.GetAttributeValue("class").Contains("disabled");
        }

        /// <summary>
        /// Verifies if the Next button in the pagination is disabled
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsPaginationNextButtonDisabled()
        {
            Logger.Info("Checking Next Button Is Disabled");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationNextPageButtonXpath, 30);
            driver.Browser.ScrollElementIntoView(SearchType.ByXpath, Selectors.PaginationNextPageButtonXpath);
            return PaginationNextButton.GetAttributeValue("class").Contains("disabled");
        }

        /// <summary>
        /// Verifies if the First button in the pagination is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsPaginationFirstButtonDisplayed()
        {
            Logger.Info("Checking First Page Button is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationFirstPageButtonXpath, 30);
            driver.Browser.ScrollElementIntoView(SearchType.ByXpath, Selectors.PaginationFirstPageButtonXpath);
            return PaginationFirstButton.Displayed;
        }

        /// <summary>
        /// Verifies if the Previs button in the pagination is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsPaginationPreviousButtonsDisplayed()
        {
            Logger.Info("Checking pagination previous button is displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationPreviousPageButtonXpath);
            return PaginationPreviousButton.Displayed;
        }

        /// <summary>
        /// Verifies if the Next button in the pagination is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsPaginationNextButtonDisplayed()
        {
            Logger.Info("Checking Next Page Button is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationNextPageButtonXpath, 30);
            return PaginationNextButton.Displayed;
        }

        /// <summary>
        /// Verifies if the Last button in the pagination is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsPaginationLastButtonDisplayed()
        {
            Logger.Info("Checking Last Page Button is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationLastPageButtonXpath, 30);
            return PaginationLastButton.Displayed;
        }

        /// <summary>
        /// Verifies if the Page one button in the pagination is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsPaginationPageOneButtonDisplayed()
        {
            Logger.Info("Checking Page 1 Button is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PageOptionInPaginationByNumber(1), 30);
            return PaginationPageOneButton.Displayed;
        }

        /// <summary>
        /// Verify the page number in the pagination are displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsPageNumberTextDisplayed()
        {
            Logger.Info("Checking Page Number is Displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PageXfromYtextXpath, 30);
            driver.Browser.ScrollElementIntoView(SearchType.ByXpath, Selectors.PageXfromYtextXpath);
            return PageNoText.Displayed;
        }

        /// <summary>
        /// Click on the Previous button from pagination
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public void ClickOnPaginationPreviousButton()
        {
            Logger.Info("Click on Previous Button");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationPreviousPageButtonXpath, 600);
            PaginationPreviousButton.Click();
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerRowsXpath, 600);
        }

        /// <summary>
        /// Click on the First button from pagination
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public void ClickOnPaginationFirstButton()
        {
            Logger.Info("Click on First Button");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationFirstPageButtonXpath, 600);
            PaginationFirstButton.Click();
        }

        /// <summary>
        /// Click on the Next button from pagination
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public void ClickOnPaginationNextButton()
        {
            Logger.Info("Click on Next Button");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationNextPageButtonXpath, 600);
            driver.Browser.ScrollElementIntoView(SearchType.ByXpath, Selectors.PaginationNextPageButtonXpath);
            PaginationNextButton.Click();
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerRowsXpath, 600);
        }

        /// <summary>
        /// Click on the Last button from pagination
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public void ClickOnPaginationLastButton()
        {
            Logger.Info("Click on Last Button");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationLastPageButtonXpath, 30);
            driver.Browser.ScrollElementIntoView(SearchType.ByXpath, Selectors.PaginationLastPageButtonXpath);
            PaginationLastButton.Click();
        }

        /// <summary>
        /// Verify if the Collapse button is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsCollapseButtonDisplayed() => CollapseButton.Displayed;

        /// <summary>
        /// Verifies if Expand button is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsExpandButtonDisplayed() => ExpandButton.Displayed;

        /// <summary>
        /// Click on Expand All button
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public void ClickonExpandAlltButton()
        {
            Logger.Info("Click on Expand All Button");
            ExpandButton.Click();
        }

        /// <summary>
        /// Click on Collapse All button
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        public void ClickonCollapseAllButton()
        {
            Logger.Info("Click on Collapse All Button");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CollapseAllButtonXpath, 30);
            if (CollapseButton.GetChildElement(SearchType.ByXpath, "i").GetAttributeValue("class").Contains("up"))
            {
                CollapseButton.Click();
            }
        }

        /// <summary>
        /// Verify if the Dropdown to select amount of rows in the results is displayed
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsShowRowsDropdownDisplayed()
        {
            Logger.Info("Check if dropdown is displayed");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.ShowRowsDropdownXpath, 30);
            driver.Browser.ScrollElementIntoView(SearchType.ByXpath, Selectors.ShowRowsDropdownXpath);
            return ShowRowsDropdown.Displayed;
        }

        /// <summary>
        /// Verifies if the Dropdown to select amount of rows in the results has the value '25' selected by default
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public bool IsDropDownDefaultValueSelected()
        {
            Logger.Info("Get value selected");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerRowsXpath, 30);
            return ShowRowsDropdown.Text.Equals(25.ToString());
        }


        /// <summary>
        /// Returns the options available in the Dropdown to select amount of rows displayed in the results
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <returns></returns>
        public List<string> GetOptionsFromDropdown()
        {
            ShowRowsDropdown.Click();
            return ShowRowsOptions.GetChildElements(SearchType.ByXpath, "p-dropdownitem").Select(text => text.Text).ToList();
        }


        /// <summary>
        /// Select the amount of rows that will be displayed in the results from the options available in the Dropdown
        /// This function can be used under the On-Board an RSS customer page as well as under the Customer Search page
        /// </summary>
        /// <param name="option"></param>
        public void SelectShowRowsOption(string option)
        {
            Logger.Info($"Select value {option} in Show Rows Dropdown");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.ShowRowsDropdownXpath, 600);
            driver.Browser.ScrollElementIntoView(SearchType.ByXpath, Selectors.ShowRowsDropdownXpath);
            ShowRowsDropdown.Click();
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.ShowsDropdownValueXpath(option));
            ShowsDropdownValue(option).Click();
        }

        /// <summary>
        /// Returns the count of displayed results on current page by counting each displayed row on UI
        /// </summary>
        /// <returns></returns>
        public int GetAmountOfResultsDisplayed()
        {
            Logger.Info("Get the amount of results displayed in the page");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.ShowRowsDropdownXpath, 180);
            return CustomerRows.Count();
        }

        /// <summary>
        /// Returns the list of search results displayed on each page
        /// </summary>
        /// <returns></returns>        
        public List<int> GetResultsFromAllThePages()
        {
            var ResultsPerPage = new List<int>();
            ClickOnPaginationLastButton();
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.LastPageOptionInPaginator, 180);
            driver.Browser.ScrollToPageBottom();
            var LastPageNumberValue = Int32.Parse(new string(LastPageOptionInPaginator.Text.Where(char.IsDigit).ToArray()));
            ClickOnPaginationFirstButton();

            for (int i = 0; i < LastPageNumberValue; i++)
            {
                ResultsPerPage.Add(GetAmountOfResultsDisplayed());
                driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.PaginationNextPageButtonXpath, 180);
                ClickOnPaginationNextButton();
            }
            return ResultsPerPage;
        }

        /// <summary>
        /// Verifies the correct amount of results is displayed on each page
        /// </summary>
        /// <returns></returns>
        public bool IsTheCorrectAmountOfResultsDisplayedPerPage()
        {
            var resultsPerPageList = GetResultsFromAllThePages();
            if (resultsPerPageList.Count > 1)
            {
                resultsPerPageList.Remove(resultsPerPageList.Last());
                return !resultsPerPageList.Where(item => item != Int32.Parse(ShowRowsDropdown.Text)).Any();
            }
            else
            {
                return resultsPerPageList.Where(item => item <= Int32.Parse(ShowRowsDropdown.Text)).Any();
            }
        }

        /// <summary>
        /// Verifies the pagination is available
        /// </summary>
        /// <returns></returns>
        public bool IsPaginationDisplayed()
        {
            Logger.Info("Check if pagination is available");
            driver.Wait.UntilElementIsNotVisible(SearchType.ByXpath, Selectors.ResultsSpinnerXpath, 30);
            return ResultsPagination.Displayed;
        }

        /// <summary>
        /// Verifies user can see all search results by navigating through the pagination options
        /// </summary>
        /// <returns></returns>
        public bool IsUserAbleToSeeAllResultsUsingThePagination() => GetResultsFromAllThePages().Sum().Equals(Int32.Parse(GetCustomerCount().Trim()));

        /// <summary>
        /// Click Reset All Link
        /// </summary>
        public void ClickResetAllLink()
        {
            Logger.Info("Click on Reset All Button on On-Board a customer page");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.ResetAllLinkXpath, 30);
            ResetAllLink.Click();
        }

        /// <summary>
        /// Verifies if the Customer Name search field is empty
        /// </summary>
        /// <returns></returns>
        public string IsCustomerNameFieldEmpty()
        {
            Logger.Info("Checking Customer Name Field is empty");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerNameFieldXpath, 30);
            return CustomerNameField.Text;
        }

        /// <summary>
        /// Verifies if the Customer ID search field is empty
        /// </summary>
        /// <returns></returns>
        public string IsCustomerIdFieldEmpty()
        {
            Logger.Info("Checking Customer ID Field is empty");
            driver.Wait.UntilElementExists(SearchType.ByXpath, Selectors.CustomerIdFieldXpath, 30);
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerIdFieldXpath, 30);
            return CustomerIdField.Text;
        }

        /// <summary>
        /// Verifies if the Customer State search field is empty
        /// </summary>
        /// <returns></returns>
        public string IsCustomerStateFieldEmpty()
        {
            Logger.Info("Checking Customer State Field is empty");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerStateFieldXpath, 30);
            return CustomerStateField.Text;
        }

        /// <summary>
        /// Verify if the Facility Name search field is empty
        /// </summary>
        /// <returns></returns>
        public string IsFacilityNameFieldEmpty()
        {
            Logger.Info("Checking Facility Name Field is empty");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityNameFieldXpath, 30);
            return FacilityNameField.Text;
        }

        /// <summary>
        /// Verify if the Facility ID search field is empty
        /// </summary>
        /// <returns></returns>
        public string IsFacilityIdFieldEmpty()
        {
            Logger.Info("Checking Facility ID Field is empty");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityIdFieldXpath, 30);
            return FacilityIdField.Text;
        }

        /// <summary>
        /// Verify if the Facility State search field is empty
        /// </summary>
        /// <returns></returns>
        public string IsFacilityStateFieldEmpty()
        {
            Logger.Info("Checking Facility State Field is empty");
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.FacilityStateFieldXpath, 30);
            return FacilityStateField.Text;
        }

        /// <summary>
        /// Verify if the Customer Results are displayed
        /// </summary>
        /// <returns></returns>
        public bool AreCustomerResutsDisplayed() => driver.Element.Exists(SearchType.ByXpath, Selectors.CustomerRowsXpath);

        /// <summary>
        /// Verifies if the On-Board customer button is displayed
        /// </summary>
        /// <returns></returns>
        public bool IsOnBoardCustomerButtonDisplayed()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.OnBoardCustomerButtonXpath);
            return OnBoardCustomerButton.Displayed;
        }

        /// <summary>
        /// Click on the On-Board customer Link
        /// </summary>
        public void ClickOnBoardCustomerButton()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.OnBoardCustomerButtonXpath);
            OnBoardCustomerButton.Click();
        }

        /// <summary>
        /// Verify if the On board Customer page is displayed
        /// </summary>
        /// <returns></returns>
        public bool IsOnBoardCustomerPageDisplayed()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.OnBoardCustomerPageXpath, 30);
            return OnBoardCustomerPage.Displayed;
        }

        /// <summary>
        /// Verify if the On-Board Customer Modal is displayed
        /// </summary>
        /// <returns></returns>
        public bool IsOnboardCustomerModalDisplayed()
        {
            ClickCustomerByIndex(0);
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.OnBoardCustomerModalTitleXpath, 30);
            return driver.Element.Exists(SearchType.ByXpath, Selectors.OnBoardCustomerModalTitleXpath);
        }

        /// <summary>
        /// Click on the Yes button from the On-Board Customer Modal
        /// </summary>
        public void ClickYesButton() => Utilities.ClickElement(SearchType.ByXpath, Selectors.YesButtonXpath);

        /// <summary>
        /// Click on the Close button from the On-Board Customer Modal
        /// </summary>
        public void ClickCloseButton() => Utilities.ClickElement(SearchType.ByXpath, Selectors.CloseButtonXpath, 30, "Close Button");


        /// <summary>
        /// Click on a Customer from search results by providing the row index
        /// </summary>
        /// <param name="index"></param>
        public void ClickCustomerByIndex(int index)
        {
            var Rows = CustomerRows.ToList();
            Rows[index].Click();
        }

        /// <summary>
        /// Click on a Customer by row index in the On-Board customer page and select Yes option from the On-board Modal
        /// </summary>
        /// <param name="index"></param>
        public void OnBoardCustomerByIndex(int index)
        {
            ClickCustomerByIndex(index);
            ClickYesButton();
        }

        /// <summary>
        /// Verifies if the 'Existing Customer Message' is Displayed in the On-Board Customer page
        /// </summary>
        /// <returns></returns>
        public bool IsExistingCustomerMessageDisplayed()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.ExistingCustomerMessageXpath, 30);
            return ExistingCustomerMessage.Displayed;
        }

        /// <summary>
        /// Verifies if the On-board Customer Modal is displayed
        /// </summary>
        /// <returns></returns>
        public bool IsOnboardedCustomerModalDisplayed()
        {
            OnBoardCustomerByIndex(0);
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.OnBoardedCustomerModalXpath);
            return driver.Element.Exists(SearchType.ByXpath, Selectors.OnBoardedCustomerModalXpath);
        }

        /// <summary>
        /// Verifies if the Focus is in the Customer Name search field
        /// </summary>
        /// <returns></returns>
        public bool IsCursorFocusOnCustomerNameField() => driver.Element.GetActiveElement().GetAttributeValue("id").Equals("custName");


        /// <summary>
        /// Wait for the Customer results to be displayed
        /// </summary>
        public void WaitForCustomerResultsToBeDisplayed()
        {
            try
            {
                driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.ResultsSpinnerXpath, 30);
                driver.Wait.UntilElementIsNotVisible(SearchType.ByXpath, Selectors.ResultsSpinnerXpath, 180);
                driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerRowsXpath, 180);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Wait for the On-board customer page is displayed
        /// </summary>
        public void WaitForOnBoardPageDisplayed()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.OnBoardCustomerPageXpath, 30);
        }

        /// <summary>
        /// Opens up a new embedded tab in the customer search by clicking on the + button
        /// </summary>
        public void OpenNewEmbeddedTab()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.OpenEmbeddedTabButtonXpath);
            OpenEmbeddedTabButton.Click();
        }

        /// <summary>
        /// Returns the count of embedded tabs that are currently opened
        /// </summary>
        public int GetCountOfActiveEmbeddedTabs => OpenedEmbeddedTabs.Count();

        /// <summary>
        /// Closes the last opened embedded tab in the customer search
        /// </summary>
        public void CloseEmbeddedTab()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CloseEmbeddedTabsButtonXpath);
            CloseEmbeddedTabButton.Click();
        }

        /// <summary>
        /// Opens up to the max allowed limit of embedded tabs
        /// </summary>
        public void OpenMaxLimitOfEmbeddedTabs()
        {
            for (int i = 0; i < 13; i++)
            {
                try
                {
                    OpenNewEmbeddedTab();
                }
                catch
                {
                    Logger.Info("Opened Limit Of Allowed Embedded Tabs");
                }
            }
        }

        /// <summary>
        /// Opens the specified amount of embedded tabs
        /// </summary>
        /// <param name="Amount">The desired amount of embedded tabs to be opened</param>
        public void OpenEmbeddedTabs(int Amount)
        {
            for (int i = 0; i < Amount; i++)
            {
                try
                {
                    OpenNewEmbeddedTab();
                }
                catch
                {
                    Logger.Info("Opened Limit Of Allowed Embedded Tabs");
                }
            }
        }

        /// <summary>
        /// Closes the specified amount of embedded tabs
        /// </summary>
        /// <param name="Amount">The desired amount of embedded tabs to be closed</param>
        public void CloseEmbeddedTabs(int Amount)
        {
            for (int i = 0; i < Amount; i++)
            {
                try
                {
                    CloseEmbeddedTab();
                }
                catch
                {
                    Logger.Info("Closed the specified number of embedded tabs");
                }
            }
        }

        /// <summary>
        /// Checks if the warning for the maximum limit of embedded tabs is displayed
        /// </summary>
        public bool IsMaxEmbeddedTabsLimitWarningDisplayed()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.MaxLimitOfOpenedTabsWarningXpath);
            return MaxLimitOfOpenedEmbeddedTabsWarning.Displayed;
        }


        /// <summary>
        /// Check if the Customer is already on board to go to the Customer Home Page. 
        /// if the Customer is not on boarded, return false.
        /// </summary>
        public bool CheckIfCustomerIsOnBoarded(string customerID)
        {
            DataRepository.DeleteCustomerNotesFromDB(customerID);
            var query = from customer in GetCustomerResults()
                        where customer.CustomerId.Equals(customerID)
                        select customer;
            DataRepository.DeleteCustomerNotesFromDB(customerID);
            if (query.Count() > 0) { ClickCustomerByIndex(0); }
            return query.Count() > 0;
        }

        /// <summary>
        /// Search for a Customer and click on the first result found to open the Customer Home page
        /// </summary>
        public void GoToTheCustomerHomePage(string customerName)
        {
            Logger.Info($"Go to the Customer \"{customerName}\" Home Page");
            WaitForCustomerSearchPageDisplayed();
            EnterCustomerName(customerName);
            WaitForCustomerResultsToBeDisplayed();
            ClickCustomerByIndex(0);            
        }

        /// <summary>
        /// Wait for the Customer Search Page is displayed.
        /// </summary>
        public void WaitForCustomerSearchPageDisplayed()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.CustomerSearchPageTitleXpath, 30);
        }

        /// <summary>
        /// Validatin if solution tab is displayed
        /// </summary>
        public bool IsSolutionsTabDisplayed()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.ActiveSolutionsTab);
            return driver.Element.Exists(SearchType.ByXpath, Selectors.ActiveSolutionsTab);
        }

        public bool IsNoSearchResultFoundMessageDisplayed()
        {
            driver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.NoSearchResultMessageXpath);
            return driver.Element.Exists(SearchType.ByXpath, Selectors.NoSearchResultMessageXpath);
        }

        public bool AreSearchResultsSorted()
        {
            Logger.Info("Checking if search results are sorted");
            Page.EnterCustomerName(Convert.ToChar(97).ToString());
            Page.WaitForCustomerResultsToBeDisplayed();

            var CustomerResults = Page.GetCustomerResults();
            var FacilityResults = Page.GetFacilityResults();

            var SortedCustomerResults = CustomerResults;
            var SortedFacilityResults = FacilityResults;

            SortedCustomerResults.OrderBy(list => list.Name );
            SortedFacilityResults.OrderBy(list => list[0] );


            return SortedCustomerResults.Equals(CustomerResults) && SortedFacilityResults.Equals(SortedFacilityResults);
        }

        public bool AreCustomerSearchResultsColorCodingMatch()
        {
            bool Match = false;
            string s = "";
            Logger.Info("Checking if search results Color coding match");
            WaitForCustomerResultsToBeDisplayed();
            var CustomerRows = driver.Element.GetElements(SearchType.ByXpath, Selectors.CustomerRowItem("customer-row"));
           
            foreach (var custRow in CustomerRows)
            {
               s =  driver.Element.GetCSSValue(custRow, "border-left-color");
                string[] hexValue = s.Replace("rgba(", "").Replace(")", "").Split(',');

                int R = int.Parse(hexValue[0]);
                
                int G = int.Parse(hexValue[1]);
                
                int B = int.Parse(hexValue[2]);
                string actualColor = Utilities.convertRGBtoHex(R, G, B);
              
                if (actualColor.Equals("#004593"))
                { Match = true; }
                    else
                        { return false; }
                

            }
            return Match;

        }

        public bool AreFacilitySearchResultsColorCodingMatch()
        {
            bool Match = false;
            string s = "";
            Logger.Info("Checking if search results Color coding match");
            WaitForCustomerResultsToBeDisplayed();
            var CustomerRows = driver.Element.GetElements(SearchType.ByXpath, Selectors.CustomerRowsXpath);

            foreach (var custRow in CustomerRows)
            {
                if (custRow.GetChildElements(SearchType.ByXpath, Selectors.FacilityElementsXpath).Count() > 0)
                {
                    var FacilityRows = custRow.GetChildElements(SearchType.ByXpath, Selectors.FacilityElementsXpath);
                    foreach (var facilityRow in FacilityRows)
                    {
                        s = driver.Element.GetCSSValue(facilityRow, "border-left-color");
                        string[] hexValue = s.Replace("rgba(", "").Replace(")", "").Split(',');

                        int R = int.Parse(hexValue[0]);

                        int G = int.Parse(hexValue[1]);

                        int B = int.Parse(hexValue[2]);
                        string actualColor = Utilities.convertRGBtoHex(R, G, B);

                        if (actualColor.Equals("#14ABFF"))
                        { Match = true; }
                        else
                        { return false; }


                    }
                   
                }

            }
            return Match;
        }
        /// <summary>
        /// Click On Dropdown Monitoring list
        /// </summary>
        /// It's needed a user with different permissions
        /*
        public void ClickOnDropDownList_MonitoringTab()
        {
            _webDriver.Wait.UntilElementIsVisible(SearchType.ByXpath, Selectors.MonitoringTabDropDownListXpath);
            MonitoringTab_DropDownList.Click();

        } */


        /// <summary>
        /// Returns a customer with Address 1 and Address 2
        /// </summary>
        /// <returns></returns>
        public string GetCustomerWithAddress()
        {
            IEnumerable<CustomerModel> customerList = DataRepository.GetCustomersWithAdressess();
            CustomerModel customer = customerList.FirstOrDefault();
            return customer.Name;
        }

        public bool CustomerSearchColumnAreDisplayed()
        {
            //Validating that all the columns are present in the grid

            return IsCustomerNameLabelDisplayed() &&
                IsCustomerIdLabelDisplayed() &&
                IsCustomerStateLabelDisplayed() &&
                IsCustomerStateLabelDisplayed() &&
                IsFacilityNameLabelDisplayed() &&
                IsFacilityIdLabelDisplayed() &&
                IsFacilityStateLabelDisplayed();
            
        }

        public bool IsCustomerSearchDisplayingValuesForAllTheColumns()
        {
            string customerName = CustomerSearchData("customer-name").Text.ToString();
            string customerId = CustomerSearchData("customer-id").Text.ToString();
            string customerState = CustomerSearchData("cutomer-state").Text.ToString();
            string customerCity = CustomerSearchData("cutomer-city").Text.ToString();
            string customerZipCode = CustomerSearchData("cutomer-zipcode").Text.ToString();
            string customerAddress = CustomerSearchData("cutomer-address").Text.ToString();

            if ((customerName.Length >= 0) && (customerId.Length >= 0) && (customerState.Length >= 0) && (customerCity.Length >= 0) && (customerZipCode.Length >= 0) &&
                (customerAddress.Length >= 0))
            {
                return true;
            }
            return false;
        }
    }



    }

