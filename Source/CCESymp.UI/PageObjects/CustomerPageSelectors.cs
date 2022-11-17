namespace CCESymp.UI.PageObjects
{
    public partial class CustomerPage
    {
        private class Selectors
        {
            //Generic locators - Buttons
            #region Generic locators - Buttons
            public static string SaveButtonXpath => "(//button[contains(text(),'Save')])[last()]";
            public static string CancelButtonXpath => "(//button[contains(text(),'Cancel')])[last()]";
            public static string EditButtonXpath => "(//button[contains(text(),'Edit')])[last()]";
            public static string DeleteButtonXpath => "(//button[contains(text(),'Delete')])[last()]";
            public static string CloseButtonXpath => "//span[contains(text(),'×')] | (//button[contains(text(),'Close')])[last()]";
            public static string MessageTracingCloseButtonXpath => "//button[@class = 'btn btn-primary float-right mt-1']";
            public static string YesButtonXpath => "(//button[text()='Yes'])[last()]";
            public static string NoButtonXpath => "(//button[text()='No'])[last()]";
            public static string OkButtonXpath => "(//button[contains(text(),'OK')])[last()]";
            public static string ModalPopupXpath => "//div[@class = 'modal-body']";
            public static string EditButtons => "//button[contains(text(), 'Edit')]";
            #endregion

            //Generic locators - paginators
            #region Generic locators - paginators
            public static string ShowRowsDropdownXpath => "//p-dropdown | //select";//dropdown used to select the amount of pages to be displayed
            public static string PaginationPreviousPageButtonXpath => "//a[@aria-label='Previous']/parent::li | //button[contains(@class, 'p-paginator-prev')]";
            public static string PaginationFirstPageButtonXpath => "//a[@aria-label='First']/parent::li | //button[contains(@class,'p-paginator-first')]";
            public static string PaginationNextPageButtonXpath => "//a[@aria-label='Next']/parent::li | //button[contains(@class, 'p-paginator-next')]";
            public static string PaginationLastPageButtonXpath => "//a[@aria-label='Last']/parent::li | //button[contains(@class, 'p-paginator-last')]";
            public static string PageXfromYtextXpath => "//div[contains( text(), 'Page ')] | //div[contains(@class, 'p-paginator-left')]"; //displays page x of y text (eg. page 1 of 10)
            #endregion

            //search pages
            #region search pages
            public static string AppCustomerTabsXpath => "//app-customer-tabs";
            public static string OnBoardCustomerPageXpath => "//app-customer-on-board";
            #endregion

            //search pages - Embedded tabs
            #region search pages - Embedded tabs
            public static string OpenEmbeddedTabButtonXpath => "(//button[contains(@class, 'tab')])[last()]";
            public static string ActiveEmbeddedTabsXpath => "//app-cce-tabs/descendant::li";
            public static string CloseEmbeddedTabsButtonXpath => "(//span[contains(@class, 'tab-close')])[last()]";
            public static string MaxLimitOfOpenedTabsWarningXpath => "//p[contains(text(), 'You have reached the maximum tab limit of 12.')]";
            public static string EmbeddedTabTextXpath => "//app-customer-tabs/app-cce-tabs/div//a";
            #endregion

            //customer search labels - Locators can be used under customer search and on-board customer pages
            #region customer search labels - Locators can be used under customer search and on-board customer pages
            public static string CustomerNameLabelXpath => "(//label[contains(text(), 'Customer Name')])[last()]";
            public static string CustomerIdLabelXpath => "(//label[contains(text(), 'Cust ID')])[last()]";
            public static string CustomerStateLabelXpath => "(//label[contains(text(), 'Cust State')])[last()]";
            public static string FacilityNameLabelXpath => "(//label[contains(text(), 'Facility Name')])[last()]";
            public static string FacilityStateLabelXpath => "(//label[contains(text(), 'Fac State')])[last()]";
            public static string FacilityIdLabelXpath => "(//label[contains(text(), 'Fac ID')])[last()]";
            public static string CustomerDataXpath(string value) => $"(//div[contains(@class,'ml-1 customer-row')])[2]/div[contains(@class,'{value}')]";
            #endregion

            //customer search input fields - Locators can be used under customer search and on-board customer pages
            #region customer search input fields - Locators can be used under customer search and on-board customer pages
            public static string CustomerNameFieldXpath => "(//input[@id='custName'])[last()]";
            public static string CustomerIdFieldXpath => "(//input[@id='custId'])[last()]";
            public static string CustomerStateFieldXpath => "(//input[@id='custState'])[last()]";
            public static string FacilityNameFieldXpath => "(//input[@id='facName'])[last()]";
            public static string FacilityIdFieldXpath => "(//input[@id='facId'])[last()]";
            public static string FacilityStateFieldXpath => "(//input[@id='facState'])[last()]";
            #endregion

            //Customer search - links on customer search
            #region Customer search - links on customer search
            public static string OnBoardCustomerLinkXpath => "//a[contains(text(), 'On-Board a Customer')]";
            public static string CustomerSearchLinkXpath => "//a[contains(text(), 'Customer Search')]";
            public static string ResetAllLinkXpath => "(//a[contains(text(), 'Reset All')])[last()]";
            public static string CustomerResultsCountXpath => "(//div[contains(@class, 'customer-count')])[last()]";
            #endregion

            //Customer search - search results
            #region Customer search - search results
            public static string CustomerRowItem(string rowItem) => $"descendant::div[contains(@class, '{rowItem}')]";
            public static string CustomerSearchPageTitleXpath => "//h3[contains(text(), 'Customer Search')]";//Title displayed on customer search page
            public static string CustomerRowsXpath => "//div[contains(@class, 'customer-main')]/parent::div";
            public static string CollapseButtonsInRowsXpath => "//div[@class='customer-main']/descendant::i[contains(@class, 'pi-chevron')]"; //used to collapse or expand individual results
            public static string CollapseAllButtonXpath => "(//a[contains(text(),'Collapse All')])[last()]";
            public static string ExpandAllButtonXpath => "(//a[contains(text(),'Expand All')])[last()]";
            public static string NoSearchResultsWarningMessageXpath => "//h4[contains(text(),'No search result found.')]";//messaged displayed when no search results are found
            public static string FacilityElementsXpath => "descendant::div[contains(@class, 'collapse show')]/div[contains(@class, 'facility-row')]";
            public static string ShowRowsOptionsXpath => "//ul[@role = 'listbox']";
            public static string NoSearchResultMessageXpath => "//h4[contains(text(), 'No search result found')] |//p[contains(text(), " +
                "' The customer you are searching for may not exist in HSCE database. ')]";
            #endregion

            //Customer search-paginator
            #region Customer search-paginator
            public static string ResultsPaginationXpath => "(//ul[@class='pagination'])[last()]";//pagination container            
            public static string ResultsSpinnerXpath => "(//app-customer-listing//span[contains(text(), 'Please wait, while we fetch the data from')])[last()]";
            public static string PageOptionInPaginationByNumber(int pageNumber) => $"//ngb-pagination/descendant::a[contains(text(), '{pageNumber}')]"; //might be refactored
            public static string LastPageOptionInPaginator => "(//li[contains(@class, 'page-item')])[last() - 2]";
            public static string DropdowOptionXpath(string option) => $"(//span[contains(text(), '{option}')]/ancestor::li)[last()]";
            #endregion

            //Customer search - Onboard new customer
            #region Customer search - Onboard new customer
            public static string ExistingCustomerMessageXpath => "//p[contains(text(), 'Customer already exists in HSCE Database')]";//message displayed after clicking on a customer when customer exists in cce db
            public static string OnBoardCustomerModalTitleXpath => "//b[contains(text(), 'On-Board Customer')]";//modal displayed after clicking on customer when customer does not exists in cce db
            public static string OnBoardedCustomerModalXpath => "//p[contains(text(), 'Customer has been successfully onboarded to HSCE database')]";//message displayed in modal after a customer is successfully onboarded
            public static string OnBoardCustomerButtonXpath => "//button[text() = 'On-Board Customer']";//button displayed when no customer results are displayed on customer page
            public static string GoToCustomerHomePageButtonXpath => "(//button[contains(text(),'Go to Customer Homepage')])[last()]";//Button displayed when user already exists on CCE DB
            #endregion

            //Customer Home Page
            #region Customer Home Page
            public static string CustomerNameXpath => "//h2";
            public static string CustomerIdUIXpath => "//h3";
            public static string CustomerAddressDetailsXpath => "//h4";
            public static string CustomerSolutionsListContainer => "//app-solution-list";
            #endregion

            //Customer Home page - Solutions tab
            #region Customer Home page - Solutions tab
            public static string SolutionsTabButtonXpath => "//button[contains(text(),'Solutions')]";
            public static string SolutionsBusinessUnitLabelXpath => "//th[contains(text(),'Business Unit')]";
            public static string SolutionsNameLabelXpath => "//p-table[@id='customer-solutions']//th[contains(text(), 'Name')]";
            public static string SolutionsCategoryLabelXpath => "//th[contains(text(),'Category')]";
            public static string SolutionsDescriptionLabelXpath => "//p-table[@id='customer-solutions']//th[contains(text(), 'Description')]";
            public static string AddNewSolutionLinkXpath => "//a[contains(text(),'Add New Solution')]";
            public static string AddNewSolutionPopUpXpath => "//h4[contains(text(),'Add New Solution')]";
            public static string SolutionTableRowsXpath => "//app-solution-list//tbody/tr";
            public static string SolutionDescriptionFieldXpath => "//textarea[@name='description']";

            public static string AddNewSolutionNameLabelXpath => "(//label[contains(text(), 'Name')])";
            public static string AddNewSolutionNameInputBoxXpath => "//input[@id='name']";
            public static string AddNewSolutionNameRequiredXpath => "(//small[(text()= 'Required.')])";
            public static string AddNewSolutionCategoryLabelXpath => "(//label[contains(text(), 'Category')])";

            public static string AddNewSolutionCategoryRequiredXpath => "(//small[(text() ='Required.')])";
            public static string AddNewSolutionTemplateTypeXpath => "(//label[contains(text(), 'Template Type')])";

            public static string AddNewSolutionTemplateTypeRequiredXpath => "(//small[(text() ='Required.')])";
            public static string AddNewSolutionDescriptionXpath => "(//label[contains(text(), 'Description')])";
            public static string AddNewSolutionDescriptionInputXpath => "(//textarea[@id='description'])";
            public static string AddNewSolutionSaveButtonXpath => "//button[contains(text(), 'Save')]";
            public static string AddNewSolutionCancelButtonXpath => "//button[contains(text(), 'Cancel')]";
            public static string AddNewSolutionCloseIconXpath => "//span[contains(text(),'×')]";
            public static string SolutionPageXpath => "//p-table[@id='customer-solutions']";
            public static string SolutionBreadcrumbXpath => "//a[contains(text(),'Solutions')]";
            public static string AddNewSolutionNameLengthWarningMessageXpath => "//small[(text() = 'Length must be 250 or less characters.')]";
            public static string AddNewSolutionNameExistWarningMessageXpath => "//small[" + (char)34 + "(text() = 'Name already exists.')" + (char)34 + " ]";
            public static string AddNewSolutionNameTextWarningMessageXpath => "//small[(text() = " + (char)34 + "Only following special chars are allowed in the name: - and _" + (char)34 + ")]";

            public static string NoSolutionTextXpath => "//p[contains(text(),'This customer does not have any solutions')]";
            public static string SolutionRowXpath => "//p-table[@id = 'customer-solutions']//tr[contains(@class, 'p-element')]";
            public static string NoBUPermissionSolutionRowXpath => "//tr[contains(@class, 'p-element no-business-unit-permission')]";
            public static string AddNewSolutionDescriptionWarningMessageXpath => "//small[text() = 'Length must be 1000 or less characters.']";

            public static string SolutionsNotepadIconXpath => "//img[@title= 'Click to open notes']";
            public static string SolutionsHandlingNotePopupXpath => "//h4[contains(text(),'Solution Handling Notes')]";
            public static string SolutionNotepadTextAreaXpath => "//textarea[@name='notes']";
            public static string SolutionNotepadYesWarningXpath => "//button[text() = 'Yes']";
            public static string SolutionNotepadNoWarningXpath => "//button[text() = 'No']";
            public static string SolutionHandlingNoteXpath => "(//tr[contains(@class,'p-element')][4]/td[6]/img)";

            public static string SolutionDetailPopUpHeadingXpath => "//h4[contains(text(),'No Permission')]";
            public static string SolutionDetailPopUpMessageTextXpath => "//div[contains(text(),\"You do not have access to this solution. If you need access, please contact an HSCE Admin.\")]";
            public static string SolutionNameColumnDataXpath => "//app-solution-list//tbody/tr[not(contains(@class, 'no-business-unit-permission'))]/td[1]";
            public static string SolutionRowDropDownXpath => "//p-dropdown[@styleclass='p-paginator-rpp-options']";

            public static string AddNewSolutionCategoryInputBoxXpath => "//p-dropdown[@id='category']";

            public static string AddNewSolutiondropdownValuesXpath(string value) => $"//div[contains(text(), '{value}')]";

            public static string AddNewSolutionTemplateTypeInputBoxXpath => "(//p-dropdown[@id='templateType'])";

            public static string SolutionDashUnderscoreWarningXpath => "//small[text() = " + (char)34 + "The solution name cannot end with a dash '-' or underscore '_'." + (char)34 + "]";
            public static string StaticFieldsXpath(string data) => $"//label[text() = '{data}:']/following-sibling::span";
            public static string ActiveSolutionsTab = "//button[text() = ' Solutions '][contains(@class, 'active')]";
            public static string TemplateTypeXpath(string value) => $"//span[contains(text(),'{value}')][last()]";
            public static string TemplateTypeSolutionsPageXpath => "(//tr[contains(@class, 'p-selectable-row ng-star-inserted')]/td)[3]";
            public static string SolutionNameLinkXpath(string value) => $"(//td[contains(text(),'{value}')])";
            public static string SolutionTabActiveXpath => "//button[contains(@class,'active')and text()=' Solutions ']";
            #endregion

            //Customer home page - message tracing tab
            #region Customer home page - message tracing tab
            public static string MessageTracingTabXpath => "//button[contains(text(), 'Message Tracing')]";
            public static string OpenedEmbeddedTabsMessageTracingXapth => "//app-message-tracing/descendant::li";
            public static string MaxLimitMessageTracingTabsWarningXpath => "//p[text() = 'You have reached the maximum tab limit of 3.']";
            public static string StartDateCheckboxXpath => "//label[contains(@for , 'startDateCheck')]";
            public static string StartDateFieldXpath => "//input[@id='startDate']";
            public static string EndDateCheckboxXpath => "//label[contains(@for , 'endDateCheck')]";
            public static string EndDateFieldXpath => "//input[@id = 'endDate']";
            public static string SearchTermFieldXpath => "//input[@formcontrolname = 'searchTerm']";
            public static string SolutionLabelMandatoryXpath => "//app-message-tracing-search//span[contains(text(),'*')]";
            public static string SolutionMandatoryMessageXpath => "//app-message-tracing-search//small[contains(text(),'Solution is required')]";
            public static string SearchButtonXpath => "//app-message-tracing-search//button[text() = ' Search ']";
            public static string SelectStartDateCalenderXpath(string value) => $"//td[contains(@class, 'p-datepicker-today')]/span[contains(text(), '{value}')]";
            public static string SelectEndDateCalenderXpath(string value) => $"//td[contains(@class, 'p-datepicker-today')]/span[contains(text(),'{value}')]";
            public static string SelectStartDateNextDayCalenderXpath(string value) => $"//span[ @class='p-ripple p-element ng-tns-c57-1 ng-star-inserted' and text()={value}]";
            public static string SelectEndDateNextDayCalenderXpath(string value) => $"//span[ @class='p-ripple p-element ng-tns-c57-2 ng-star-inserted' and text()={value}]";

            public static string NumberofDisplayedSearchResultsXpath => "//a[starts-with(text(),'Search') and contains(text(), 'of')]";
            public static string MessageTracingEmbeddedTabTextXpath => "//app-message-tracing//li[contains(@class, 'active ng-star-inserted')]/a";
            public static string MessageTracingSearchResultTableXpath => "//table[@class = 'p-datatable-table']";
            //public static string SolutionDropdownButtonXpath => "//div[contains(@class , 'p-dropdown-trigger ng-tns-c52-3')]";
            public static string SolutionDropdownButtonXpath => "//app-message-tracing-search//p-dropdown[@id='solutions']";
            //public static string SolutionNameInDropdownXpath(string value) => $"//div[contains(text(), '{value}')]";
            public static string SolutionNameInDropdownXpath(string value) => $"//ul[@role = 'listbox']/p-dropdownitem//div[contains(text(), '{value}')]";

            public static string SolutionDropdownFieldXpath => "//ul/p-dropdownitem//li";
            public static string SolutionRequiredWarningXpath => "//small[text() = 'Solution is required.']";
            public static string MessageTracingResultsDateTimeHeaderXpath => "//th[contains(text(), 'Date/Time')]";
            public static string MessageTracingResultsRowXpath => "//p-table[@class='p-element']//tbody/tr";

            public static string StartDateCalenderIconXpath => "//p-calendar[@formcontrolname = 'startDate']//button/span[contains(@class, 'p-button-icon')]";
            public static string EndDateCalenderIconXpath => "//p-calendar[@formcontrolname = 'endDate']//button/span[contains(@class, 'p-button-icon')]";
            public static string CalendarDaysXpath => "//table[contains(@class, 'p-datepicker-calendar')]//td/span[not(contains(@class,'p-disabled'))]";
            public static string CalenderNextHoursXpath => "//div[contains(@class ,'p-hour-picker')]/button/span[contains(@class , 'pi-chevron-up')]";
            public static string CalenderNextMinuteXpath => "//div[contains(@class ,'p-minute-picker')]/button/span[contains(@class , 'pi-chevron-up')]";
            public static string CalenderNextSecondXpath => "//div[contains(@class ,'p-second-picker')]/button/span[contains(@class , 'pi-chevron-up')]";
            public static string CalenderNextAM_PM_Xpath => "//div[contains(@class ,'p-ampm-picker')]/button/span[contains(@class , 'pi-chevron-up')]";
            public static string SelectNextCalenderMonthXpath = "//span[contains(@class, 'p-datepicker-next-icon')]";

            public static string DisplayedHoursCalendarXpath => $"//div[contains(@class, 'p-timepicker')]/div[contains(@class ,'p-hour-picker')]";
            public static string DisplayedMinuteCalendarXpath => $"//div[contains(@class, 'p-timepicker')]/div[contains(@class ,'p-minute-picker')]";
            public static string DisplayedSecondCalendarXpath => $"//div[contains(@class, 'p-timepicker')]/div[contains(@class ,'p-second-picker')]";
            public static string DisplayedAM_PMCalendarXpath => $"//div[contains(@class, 'p-timepicker')]/div[contains(@class ,'p-ampm-picker')]";
            public static string CalenderMonthXpath => $"//button[contains(@class,'p-datepicker-month')]";
            //public static string CalenderMonthXpath => $"//span[contains(@class,'p-datepicker-month')]";
            public static string CalenderYearXpath => $"//button[contains(@class,'p-datepicker-year')]";
            //public static string CalenderYearXpath => $"//span[contains(@class,'p-datepicker-year')]";
            public static string SelectPreviousCalenderMonthXpath => "//span[contains(@class , 'p-datepicker-prev-icon')]";

            public static string ShowsDropdownArrowXpath => "//div[label[text() = 'Shows']]//span[contains(@class , 'p-dropdown-trigger-icon')]";
            public static string ShowsDropdownCurrentValueXpath => "//span[@id = 'pr_id_5_label']";
            public static string ShowsDropdownValueXpath(string value) => $"//li[@role='option' ] [@aria-label ='{value}']";
            public static string HideFiltersXpath => "//a[text()=' Hide Filters ']";
            public static string ShowFiltersXpath => "//a[text()=' Show Filters ']";
            public static string MessageTracingRecordByIndexXpath(string value) => $" //tr[{value}][contains(@class , 'tracing-row')]";
            public static string MessageTracingRecordFieldXpath(string value) => $"//app-message-tracing-detail//label[text()='{value}']";


            public static string CalendarPopupXpath => "//table[contains(@class, 'p-datepicker-calendar')]";
            public static string StartDatePlaceHolderXpath(string value) => $"//input[@id='startDate'] [@placeholder= '{value}']";

            public static string EndDatePlaceHolderXpath(string value) => $"//input[@id='endDate'] [@placeholder= '{value}']";

            public static string ResizerXpath(string value) => $"//*[@id='pr_id_10-table']/thead/tr/th['{value}']/span";
            public static string Resizer => "//span[contains(@class, 'column-resizer')]";

            public static string InvalidDateTimeErrorXpath => "//small[text()='Date/time entered is invalid']";
            public static string WarningPopUpXpath => "//b[text()='WARNING NOTICE TO ALL USERS']";
            public static string EndDateErrorXpath = "//small[text()='End date/time cannot be earlier than the Start date/time']";
            public static string NextSearchResultsXpath => "//button[@ptooltip = 'Show more results']";
            public static string MessageTracingTabColumnsXpath(string value) => $" //tr/th[text()='{value}']";
            public static string TimeModalXpath => "//div[contains(@class, 'p-timepicker')]";

            public static string HL7TabXpath => "//span[text() = 'HL7']";
            public static string TextTabXpath => "//span[text() = 'Text']";
            public static string SelectTracingMessageXpath => "//table[@class='p-datatable-table']//tr[2]";

            public static string ClickMessageTracingiconXpath => "//button[@id='btnTracing']";

            public static string TooltipMessageTracingiconXpath => "//button[@ptooltip='Related message(s)']";
            public static string TracedMessageRecordFieldXpath(string value) => $"//label[text()='{value}']";

            public static string HL7Level1Xpath => "//div[contains(@class, 'p-treetable-wrapper')]//tr";

            public static string HL7MessageTextXpath = "//p-tabpanel[@header = 'Text']/div[@role = 'tabpanel']";

            public static string CollapsableHL7TreeXpath = "//div[contains(@class, 'p-treetable-wrapper')]//tr//i";
            public static string ExpandAllHL7TreeXpath = "//div/a[text()=' Expand/Collapse All ']";

            public static string HL7Level2Xpath => "//div[contains(@class, 'p-treetable-wrapper')]//tr";

            public static string TableRowOne = "(//th[contains(text(), 'Date/Time')])[last()]";
            public static string ExpectedItemInRow(string Text) => $"//tr//*[contains(text(), '{Text}')]";

            #endregion

            //Customer home page - contact info - Contact info pop up
            #region Customer home page - contact info - Contact info pop up
            public static string ContactInfoLinkXpath = "//a[contains(text(), 'Contact Info')]";//link to access contact info pop up
            public static string ContactInfoPopUpTitleXpath = "//h3[@class = 'modal-title']";//Title displayed on the contact info pop up
            public static string NoFacilityFoundPopUpMessageXpath = "//p[text()='No facilities found for this customer.']";
            #endregion

            //Customer home page - Contact info - Facility Details
            #region Customer home page - Contact info - Facility Details
            public static string CustomerFacilityContactInfoXpath = "//div[contains(@class,'col-md-12')]";//div which contains all the facility contact info
            public static string FacilityContactInfo(string value) => $".//div[contains(text(), '{value}:')]/following-sibling::div";
            #endregion

            //Customer home page - Notepad
            #region Customer home page - Notepad
            public static string NotepadIconXpath = "//img[contains(@src, 'icon-note')]";
            public static string EmptyNotepadIconXpath = "//img[contains(@src, 'icon-note-empty.png')]";
            public static string FilledNotepadIconXpath = "//img[contains(@src, 'icon-note-filled.png')]";
            public static string NotepadPopUpXpath = "//h4[contains(text(), 'Customer Handling Notes')]";
            public static string NotepadTextAreaXpath = "//textarea[@name='notes']";
            public static string NotepadWarningXpath = "//p[text() = 'Do you want to close without saving ?']";
            public static string CustomerHandlingNoteEditFieldXpath = "//textarea[@name='notes']";
            public static string NotesUpdateSuccessAlertXpath = "//app-alert//p[text() = 'Customer notes updated successfully.']";
            public static string LoadingSpinnerXpath = "//app-cce-spinner";
            #endregion

            //Solution Configuration Page
            #region Solution Configuration Page
            public static string GeneralAccordion = "//span[contains(text(), 'General')]";
            public static string SolutionConfigurationPageXpath = "//app-solution-configuration";
            public static string SolutionConfigurationNavigationLabelXpath(string solutionName) => $"//span[contains(text(), '{solutionName}')]";
            public static string SolutionGeneralDataXpath(string data) => $"//label[contains(text(), '{data}:')]/following-sibling::span";
            public static string SolutionConfigurationDataXpath(string data) => $"//label[contains(text(), '{data}:')]/following-sibling::div";

            public static string FacilityCodeInputXpath = "//input[@name='facilityCode']";
            public static string FacilityCodeSpecialCharWarningXpath = "//small[text() ='Only alphanumeric characters allowed. ']";
            public static string FacilityCodeLengthWarningXpath = "//small[text() ='Length must be 250 or less characters.']";
            public static string FacilityCodeTextXpath = "//span[contains(@class , 'value')]";

            public static string DynamicConfigurationFieldsXpath(string data) => $"//label[text()='{data}:']";

            public static string DynamicFieldsInputTypeXpath(string data, string type) => $"//input[@id='{data}'] [@type = '{type}']";

            public static string DynamicFieldsInputXpath(string data) => $"//input[@id='{data}']";

            public static string DynamicFieldsRequiredIconXpath(string data) => $"//label[text()='{data}:']/span[contains(@class,'text-danger')]";

            public static string DynamicFieldsWarningRequiredIconXpath(string data) => $"//div[contains(@class,'invalid-feedback')]/small[text()= '{data} is required.']";

            public static string DynamicFieldsUpdatedXpath(string data) => $"//label[@for = '{data}']/following-sibling::div";
            public static string UploadFileXpath = "//input[@type = 'file']";
            public static string UploadedFacilityCodeTempValueXpath = "//span[contains(@class , 'font-weight-normal col-form-label ng-star-inserted')]";
            public static string UploadedFileIncompleteWarningXpath = "//small[contains(text(), 'The selected file is incomplete')]";
            public static string UploadedFileInvalidWarningXpath = "//small[contains(text(), 'The selected file is invalid')]";
            public static string RemoveUploadedFileButtonXpath = "//button[@title = 'Clear']";
            public static string UploadedFacilityCodeValueXpath = "//label[contains(text(), 'Facility Code')]/following-sibling::div/div/span";
            public static string SolutionButtonXpath = "//a[contains(text(), 'Solutions')]";
            public static string UploadedFileDuplicateWarningXpath = "//small[contains(text(), 'Facility code must be unique')]";
            public static string SolutionConfigurationLabelXpath(string configurationLabel) => $"//label[contains(text(), '{configurationLabel}')]";

            public static string PublishButtonXpath = "(//button[contains(text(),'Publish')])[last()]";

            public static string PublishRequiredFieldsMissingXpath = "//p[contains(text(), 'Required fields are missing')]";

            public static string Publish_EditButtonXpath = "//div[contains(@class, 'modal-content')]//button[contains(text(),'Edit')]";

            public static string Publish_CloseButtonXpath = "//div[contains(@class, 'modal-content')]//button[contains(text(),'Close')]";

            public static string ConfirmPublishButtonXpath => "//div[contains(@class, 'modal-content')]//button[contains(text(),'Publish')]";

            public static string FacilityCodeMissingXpath = "//small[contains(text(), 'Facility code is required')]";

            public static string UpdateButtonXpath = "//button[contains(text() , 'Update')]";
            public static string MappingTemplateViewButtonXpath = "//label[@for='mapping_template']/following-sibling::div//button[contains(text() , 'View')]";

            public static string MappingTemplateEditButtonXpath = "//div[contains(@class,'modal-content')]//button[text()= ' Edit ']";

            public static string MappingTemplateCancelButtonXpath = "//div[contains(@class,'modal-content')]//button[text()= ' Cancel ']";

            public static string MappingTemplateSaveButtonXpath = "//div[contains(@class,'modal-content')]//button[text()= ' Save ']";

            public static string MappingTemplateInputXpath => "//div[contains(@class,'modal-content')]//textarea";


            public static string SolutionConfigurationSectionXpath = "//a[@role = 'tab']/span[text() = ' Configuration ']";

            public static string SolutionConfigurationGeneralSectionXpath = "//a[@role = 'tab']/span[text() = ' General ']";

            // public static string ExpandGeneralSectionXpath = "//span[contains(@class, 'p-accordion-toggle-icon ng-tns-c44-10')]";

            public static string GlobalEditButtonXpath = "//p-accordiontab[@header = 'General']//button[text() = ' Edit ']";
            public static string ConfigurationEditButtonXpath = "//p-accordiontab[@header = 'Configuration']//button[text() = ' Edit '] ";
            public static string SiteCodeXpath => "//input[@id='site_sitecode']";
            public static string FacilityConfigurationsEditButtonXpath => "//label[@for='medbank_facilities']/following-sibling::div/button[contains(text() , 'Edit')]";
            public static string FacilityConfigurationsViewButtonXpath => "//label[@for='medbank_facilities']/following-sibling::div/button[contains(text() , 'View')]";
            public static string FacilityConfigurationsPopOutTitleXpath => "//h4[text() = 'Facility Configurations']";
            public static string AddRowLinkXpath => "//a[text() = ' Add Row ']";
            public static string DoneButtonXpath => "//button[text() = ' Done ']";
            public static string FacilityConfigurationInputFieldXpath(string fieldName) => $"//div[label[text() = '{fieldName}']]/following-sibling::input";
            public static string FacilityConfigurationRecordsXpath = "//div[contains(@class, 'd-flex')]/div[contains(@class, 'form-group')]";
            public static string AddRecordsErrorMessageXpath = $"//div[@class = 'modal-content']//p[contains(text(),'Cannot have')]";
            public static string AddRecordsErrorMessageCloseButtonXpath = "//div[@class= 'modal-content']//button[text() = 'Close']";
            public static string FacilityConfigurationClosePopOutXpath = "//app-solution-list-config-dialog//span";
            public static string FacilityConfigurationRequiredFieldXpath(string fieldName) => $"//div[contains(@class,'form-group')]/div[label[text() = '{fieldName}']]/following-sibling::div[contains(@class,'invalid-feedback')]";
            public static string FacilityConfigurationRequiredFieldIconXpath(string fieldName) => $"//div[contains(@class,'form-group')]/div/label[text() = '{fieldName}']/following-sibling::span[contains(@class,'text-danger')]";
            public static string SiteViewXpath => "//*[@id='p-accordiontab-1-content']//div[1]/app-question//button";
            public static string SiteViewCloseXpath => "//button[@aria-label=\"Close\"]";
            public static string HL7FileTypeViewXpath => "//*[@id='p-accordiontab-1-content']//div[2]/app-question//button";
            public static string SiteIdentityXpath => "//app-solution-list-config-dialog//label[text() = 'User Name']";
            public static string SiteNameXpath => "//app-solution-list-config-dialog//label[text() = 'Database Name']";
            public static string SitePasswordXpath => "//app-solution-list-config-dialog//label[text() = 'Password']";
            public static string SiteCodePopUpXpath => "//app-solution-list-config-dialog//label[text() = 'Facility Code']";
            public static string closeSitePopUp => "//button/span[contains(text(),'×')]";
            public static string HL7FileType_FileName => "//label[contains(text(), 'File Name')]";
            public static string HL7FileType_MessageType => "//label[contains(text(), 'Message Type')]";
            public static string FacilityConfigurationRemoveIconXpath => $"//i[@class = 'pi pi-trash']";

            #endregion

            //Customer  page - Monitoring tab
            #region Customer page - Monitoring
            public static string MonitoringTabXpath = "//*[text()=' Monitoring ']";
            public static string MonitoringTabNotAccessXpath = "//p[text()='You do not have access to this feature. If you need access, please contact an HSCE Admin.']";
            public static string SolutionDropdownMonitoringTabXpath => "//span[@id='pr_id_3_label']";
            public static string SolutionNameInSolutionDropdown_MonitoringTabXpath(string value) => $"//div[text()=' {value} ']";
            public static string LastFailedMessageDeliveryXpath => "//td[contains(text(),'Last failed message')]/parent::tr/td[2]";
            public static string LastSuccessfulMessageDeliveredXpath => "//td[contains(text(),'Last successful message delivered at')]/parent::tr/td[2]";
            public static string ReasonForLastFailedMessageDeliveryXpath => "//td[contains(text(),'Reason for last failed message delivery')]/parent::tr";
            public static string SolutionDropdownList_MonitoringXpath => "//li[contains(@class,'dropdown-item')]";
            public static string SearchButtonMonitoringTabXpath => "//button[not(contains(@class,'disabled'))and text()=' Search ']";
            public static string RefreshButtonXpath => "//button[text() = ' Refresh ']";
            public static string DateTime_MonitoringTabXpath => "//span[not(contains(text, 'Last Refreshed: '))and @class='mt-4']";
            public static string LastRefreshedXpath => "//span[@class='mt-4']";
            public static string UnProcessableMessagesInLast24HrsXpath => "//td[contains(text(),'Un-processable messages in last 24 hrs')]/parent::tr/td[2]";
            public static string UnProcessableMessagesInLast5minsXpath => "//td[contains(text(),'Un-processable messages in last 5 mins')]/parent::tr/td[2]";
            public static string LastUnProcessableMessageReceivedAtXpath => "//td[contains(text(),'Last un-processable message received at')]/parent::tr/td[2]";
            public static string ReasonForLastUnProcessableMessageXpath => "//td[contains(text(),'Reason for last un-processable message')]/parent::tr/td[2]";
            public static string LastSuccessfulPollAttemptAtXpath => "//td[contains(text(),'Last successful poll attempt at')]/parent::tr/td[2]";
            public static string LastFailedPollAttemptAtXpath => "//td[contains(text(),'Last failed poll attempt at')]/parent::tr/td[2]";
            public static string ReasonForLastFailedPollAttemptXpath => "//td[contains(text(),'Reason for last failed poll attempt')]/parent::tr/td[2]";
            //public static string MonitoringTabDropDownListXpath = "//span[text()='Select'][first()]";
            #endregion

            //Comm Status tab in customer page 
            #region
            public static string CommStatusTabButtonXpath = "//button[contains(text(),'Comm Status')]";
            #endregion
            //Customer home page - Global connections tab - Global connections list
            //#region Customer home page - Global connections tab - Global connections list
            //public static string NoGlobalConnectionTextXpath = "//p[contains(text(),'This customer does not have any global connections built')]";
            public static string GlobalConnectionsTabButtonXpath = "//button[contains(text(), 'Global Connection')]";//global connections button tab
            //public static string AddNewGlobalConnectionButtonXpath = "//a[contains(text(),'Add New Global Connection')]";//add new global connection link
            //public static string AddNewGlobalConnectionHeadingXpath = "//h4[contains(text(),'Add New Global Connection')]";//header displayed on the add new global connection pop up
            //public static string GlobalConnectionNameLabelXpath = "//th[contains(text(),'Global Connection Name')]";//Global connection name header displayed on the global connections list, not on pop up
            //public static string GlobalConnectionTypeLabelXpath = "//th[contains(text(),'Type')]";//Global connection type header displayed on the global connections list, not on pop up
            //public static string GlobalConnectionDescriptionLabelXpath = "//th[contains(text(),'Description')]";//Global connection description header displayed on the global connections list, not on pop up
            //public static string GlobalConnectionRowXpath = "//p-table[@id = 'pGlobalConnectionTemplates']//tr[contains(@class, 'p-element')]";//Global connection rows displayed on global connections list
            //public static string ExpandRowsXpath = "//i[contains(@class, 'pi-chevron')]"; //This is used to expand items
            //public static string GlobalConnectionPageXpath = "//app-global-connection";
            //#endregion

            //Customer home page - Global connections tab - Add new global connection
            //#region Customer home page - Global connections tab - Add new global connection
            //public static string GlobalConnectionNameFieldXpath = "//input[@id='name']";
            //public static string GlobalConnectionTypeDropdownXpath = "//select[@formcontrolname='type']";//dropdown used to select the desired global connection type, displayed on add new global connection pop up
            //public static string GlobalConnectionDescriptionFieldXpath = "//textarea[@id='description']";
            //public static string GlobalConnectionIpFieldXpath = "//input[@id='cust_global.hl7_in.host']";
            //public static string GlobalConnectionPortFieldXpath = "//input[@id='cust_global.hl7_in.port']";
            //public static string GlobalConnectionNameRequiredTextXpath = "//small[contains(text(), 'Name is required')]";//text displayed when clicking save without entering global connection name
            //public static string GlobalConnectionTypeRequiredTextXpath = "//small[contains(text(), 'Type is required')]";//text displayed when clicking save without selecting global connection type
            //public static string GlobalConnectionDescriptionRequiredTextXpath = "//small[contains(text(), 'Description is required')]";//text displayed when clicking save without entering global connection description
            //#endregion

            //Customer home page - Global connections tab - Fields displayed on each row of the global connections list displayed on a table
            //#region Customer home page - Global connections tab - Fields displayed on each row of the global connections list displayed on a table
            //public static string GlobalConnectionDescriptionInRow = "//label[@for='description']/following-sibling::div";
            //public static string GlobaConnectionNameInRow = "//label[@for='cust_global.name']/following-sibling::div";//non used for now
            //public static string GlobalConnectionIpInRow = "//label[@for='cust_global.hl7_in.host']/following-sibling::div";
            //public static string GlobalConnectionPortInRow = "//label[@for='cust_global.hl7_in.port']/following-sibling::div";
            //#endregion

            //Customer home page - Global connections tab - Delete global connection
            //#region Customer home page - Global connections tab - Delete global connection
            //public static string DeleteConfirmationPopupXpath = "//div[@class = 'modal-content']";
            //#endregion


            //Customer home page - comm status tab
            //#region Customer home page - comm status tab
            //public static string CommStatusTabButtonXpath = "//button[contains(text(),'Comm Status')]";
            //public static string CommStatusPageXpath = "//app-comm-status[text() = 'comm status\n']";
            //#endregion
        }
    }
}