using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;
using System.Collections.Generic;

namespace CCESymp.UI.PageObjects
{
    public partial class CustomerPage
    {
        #region Common WebElements
        private IElement LastPageOptionInPaginator => driver.Element.GetElement(SearchType.ByXpath, Selectors.LastPageOptionInPaginator);
        private IElement ShowRowsDropdown => driver.Element.GetElement(SearchType.ByXpath, Selectors.ShowRowsDropdownXpath);
        private IElement OkButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.OkButtonXpath);
        private IElement ShowsDropdownValue(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.ShowsDropdownValueXpath(value));
        private IElement SaveButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.SaveButtonXpath);
        private IElement CancelButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.CancelButtonXpath);
        private IElement GlobalEditButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalEditButtonXpath);
        #endregion

        #region Customer Search and On-Board search Elements
        private IElement CustomerNameLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerNameLabelXpath);
        private IElement CustomerNameField => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerNameFieldXpath);
        private IElement CustomerIdLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerIdLabelXpath);
        private IElement CustomerIdField => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerIdFieldXpath);
        private IElement CustomerStateLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerStateLabelXpath);
        private IElement CustomerStateField => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerStateFieldXpath);
        private IElement FacilityNameLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityNameLabelXpath);
        private IElement FacilityNameField => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityNameFieldXpath);
        private IElement FacilityIdLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityIdLabelXpath);
        private IElement FacilityIdField => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityIdFieldXpath);
        private IElement FacilityStateLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityStateLabelXpath);
        private IElement FacilityStateField => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityStateFieldXpath);
        private IElement OnBoardCustomerLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.OnBoardCustomerLinkXpath);
        private IElement TracingMessageIcon => driver.Element.GetElement(SearchType.ByXpath, Selectors.ClickMessageTracingiconXpath);
        private IElement ResetAllLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.ResetAllLinkXpath);
        private IElement CustomerResultsCount => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerResultsCountXpath);
        private IElement CustomerSearchLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerSearchLinkXpath);
        private IElement OnBoardCustomerPage => driver.Element.GetElement(SearchType.ByXpath, Selectors.OnBoardCustomerPageXpath);
        private IElement ResultsPagination => driver.Element.GetElement(SearchType.ByXpath, Selectors.ResultsPaginationXpath);
        private IElement WarningMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.NoSearchResultsWarningMessageXpath);
        private IElement PaginationPreviousButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.PaginationPreviousPageButtonXpath);
        private IElement PaginationFirstButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.PaginationFirstPageButtonXpath);
        private IElement PaginationNextButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.PaginationNextPageButtonXpath);
        private IElement PaginationLastButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.PaginationLastPageButtonXpath);
        private IElement PaginationPageOneButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.PageOptionInPaginationByNumber(1));
        private IElement PageNoText => driver.Element.GetElement(SearchType.ByXpath, Selectors.PageXfromYtextXpath);
        private IElement CollapseButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.CollapseAllButtonXpath);
        private IElement ExpandButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.ExpandAllButtonXpath);
        //private IElement YesButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerOnboardYesButtonXpath);
        private IElement CloseButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.CloseButtonXpath);
        private IElement ExistingCustomerMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.ExistingCustomerMessageXpath);
        private IEnumerable<IElement> CollapseButtonsInRows => driver.Element.GetElements(SearchType.ByXpath, Selectors.CollapseButtonsInRowsXpath);
        private IEnumerable<IElement> CustomerRows => driver.Element.GetElements(SearchType.ByXpath, Selectors.CustomerRowsXpath);
        private IElement OnBoardCustomerButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.OnBoardCustomerButtonXpath);
        private IElement GoToCustomerHomePageButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.GoToCustomerHomePageButtonXpath);
        private IElement CustomerSearchData(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerDataXpath(value));

        #endregion

        #region Customer and Customer Contact Information Elements
        private IElement ContactInfoLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.ContactInfoLinkXpath);
        private IElement ContactInfoPopUpTitle => driver.Element.GetElement(SearchType.ByXpath, Selectors.ContactInfoPopUpTitleXpath);
        private IEnumerable<IElement> FacilitiesContactInfo => driver.Element.GetElements(SearchType.ByXpath, Selectors.CustomerFacilityContactInfoXpath);
        private IElement CustomerHandlingNoteIcon => driver.Element.GetElement(SearchType.ByXpath, Selectors.NotepadIconXpath);
        private IElement CustomerHandlingNoteEditButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.EditButtonXpath);
        private IElement CustomerHandlingNoteEditField => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerHandlingNoteEditFieldXpath);
        private IElement CustomerHandlingNoteSaveButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.SaveButtonXpath);




        private IElement EmbeddedTabText => driver.Element.GetElement(SearchType.ByXpath, Selectors.EmbeddedTabTextXpath);
        private IElement CustomerName => driver.Element.GetElement(SearchType.ByXpath, Selectors.CustomerNameXpath);
        #endregion

        #region Solutions Page
        private IElement SolutionsTabButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionsTabButtonXpath);
        private IElement SolutionsBusinessUnitLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionsBusinessUnitLabelXpath);
        private IElement SolutionsNameLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionsNameLabelXpath);
        private IElement SolutionsCategoryLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionsCategoryLabelXpath);
        private IElement SolutionsDescriptionLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionsDescriptionLabelXpath);
        private IEnumerable<IElement> SolutionTableRows => driver.Element.GetElements(SearchType.ByXpath, Selectors.SolutionTableRowsXpath);
        private IElement SolutionPage => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionPageXpath);
        private IEnumerable<IElement> SolutionsNotepadIcon => driver.Element.GetElements(SearchType.ByXpath, Selectors.SolutionsNotepadIconXpath);
        private IElement NoSolutionText => driver.Element.GetElement(SearchType.ByXpath, Selectors.NoSolutionTextXpath);
        private IEnumerable<IElement> SolutionRows => driver.Element.GetElements(SearchType.ByXpath, Selectors.SolutionRowXpath);
        private IElement NoBUPermissionSolutionRow => driver.Element.GetElement(SearchType.ByXpath, Selectors.NoBUPermissionSolutionRowXpath);
        private IElement SolutionRowDropDown => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionRowDropDownXpath);
        private IElement SolutionDetailPopUpHeading => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionDetailPopUpHeadingXpath);
        private IElement SolutionDetailPopUpMessageText => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionDetailPopUpMessageTextXpath);
        private IElement ShowRowsOptions => driver.Element.GetElement(SearchType.ByXpath, Selectors.ShowRowsOptionsXpath);

        private IElement SolutionDashUnderscoreWarning => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionDashUnderscoreWarningXpath);

        private IElement StaticFields(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.StaticFieldsXpath(value));
        private IElement SolutionNameLink(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionNameLinkXpath(value));
        private IElement SolutionTabActive => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionTabActiveXpath);
        #endregion

        #region Embedded Tabs Elements        
        private IElement OpenEmbeddedTabButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.OpenEmbeddedTabButtonXpath);
        private IElement CloseEmbeddedTabButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.CloseEmbeddedTabsButtonXpath);
        private IEnumerable<IElement> OpenedEmbeddedTabs => driver.Element.GetElements(SearchType.ByXpath, Selectors.ActiveEmbeddedTabsXpath);
        private IElement MaxLimitOfOpenedEmbeddedTabsWarning => driver.Element.GetElement(SearchType.ByXpath, Selectors.MaxLimitOfOpenedTabsWarningXpath);
        #endregion

        #region Notepad Elements
        private IElement NotepadIcon => driver.Element.GetElement(SearchType.ByXpath, Selectors.NotepadIconXpath);
        private IElement EmptyNotepadIcon => driver.Element.GetElement(SearchType.ByXpath, Selectors.EmptyNotepadIconXpath);
        private IElement FullNotepadIcon => driver.Element.GetElement(SearchType.ByXpath, Selectors.FilledNotepadIconXpath);
        private IElement NotepadPopUp => driver.Element.GetElement(SearchType.ByXpath, Selectors.NotepadPopUpXpath);
        private IElement NotepadTextArea => driver.Element.GetElement(SearchType.ByXpath, Selectors.NotepadTextAreaXpath);
        private IElement NotepadWarningUnsavedChanges => driver.Element.GetElement(SearchType.ByXpath, Selectors.NotepadWarningXpath);
        private IElement NotepadWarningYesButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.YesButtonXpath);
        private IElement NotepadWarningNoButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.NoButtonXpath);

        private IElement NotesLoadingSpinner => driver.Element.GetElement(SearchType.ByXpath, Selectors.LoadingSpinnerXpath);
        #endregion

        #region Add Solution
        private IElement AddNewSolutionLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionLinkXpath);
        private IElement AddNewSolutionPopUp => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionPopUpXpath);
        private IElement AddNewSolutionNameLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionNameLabelXpath);
        private IElement AddNewSolutionNameInputBox => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionNameInputBoxXpath);
        private IElement AddNewSolutionNameRequired => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionNameRequiredXpath);
        private IElement AddNewSolutionCategoryLabel => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionCategoryLabelXpath);
        private IElement AddNewSolutionCategoryInputBox => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionCategoryInputBoxXpath);
        private IElement AddNewSolutionCategoryRequired => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionCategoryRequiredXpath);
        private IElement AddNewSolutionTemplateType => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionTemplateTypeXpath);
        private IElement AddNewSolutionTemplateTypeInputBox => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionTemplateTypeInputBoxXpath);
        private IElement AddNewSolutionTemplateTypeRequired => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionTemplateTypeRequiredXpath);
        private IElement AddNewSolutionDescription => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionDescriptionXpath);
        private IElement AddNewSolutionDescriptionInput => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionDescriptionInputXpath);
        private IElement AddNewSolutionSaveButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionSaveButtonXpath);
        private IElement AddNewSolutionCancelButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionCancelButtonXpath);
        private IElement AddNewSolutionCloseIcon => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionCloseIconXpath);
        private IElement AddNewSolutionNameLengthWarningMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionNameLengthWarningMessageXpath);
        private IElement AddNewSolutionNameTextWarningMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionNameTextWarningMessageXpath);
        private IElement AddNewSolutionNameExistWarningMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionNameExistWarningMessageXpath);
        private IElement AddNewSolutionDescriptionWarningMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutionDescriptionWarningMessageXpath);
        private IElement SolutionDescriptionField => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionDescriptionFieldXpath);
        private IElement SolutionBreadcrumb => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionBreadcrumbXpath);
        private IElement SolutionsHandlingNotePopup => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionsHandlingNotePopupXpath);
        private IElement EditNoteOnPopup => driver.Element.GetElement(SearchType.ByXpath, Selectors.EditButtonXpath);
        private IElement SaveNoteOnPopup => driver.Element.GetElement(SearchType.ByXpath, Selectors.SaveButtonXpath);
        private IElement CancelNoteOnPopup => driver.Element.GetElement(SearchType.ByXpath, Selectors.CancelButtonXpath);
        private IElement SolutionNotepadTextArea => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionNotepadTextAreaXpath);
        private IElement SolutionNotepadYesWarning => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionNotepadYesWarningXpath);
        private IElement SolutionNotepadNoWarning => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionNotepadNoWarningXpath);
        private IElement AddNewSolutiondropdownValues(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewSolutiondropdownValuesXpath(value));
        private IElement SolutionHandlingNote => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionHandlingNoteXpath);
        #endregion

        #region Solution Configuration
        private IElement EditButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.EditButtonXpath);
        private IElement DeleteButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.DeleteButtonXpath);
        private IElement SolutionConfigurationPage => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionConfigurationPageXpath);
        private IElement SolutionConfigurationNavigationLabel(string solutionName) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionConfigurationNavigationLabelXpath(solutionName));
        private IElement ModalPopup => driver.Element.GetElement(SearchType.ByXpath, Selectors.ModalPopupXpath);
        private IElement SolutionGeneralData(string data) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionGeneralDataXpath(data));
        private IElement SolutionConfigurationData(string data) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionConfigurationDataXpath(data));
        private IElement PublishButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.PublishButtonXpath);

        private IElement PublishRequiredFieldsMissing => driver.Element.GetElement(SearchType.ByXpath, Selectors.PublishRequiredFieldsMissingXpath);
        private IElement Publish_EditButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.Publish_EditButtonXpath);
        private IElement Publish_CloseButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.Publish_CloseButtonXpath);

        private IElement FacilityCodeMissing => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityCodeMissingXpath);

        private IElement UpdateButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.UpdateButtonXpath);

        private IElement ConfirmPublishButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.ConfirmPublishButtonXpath);

        private IElement MappingTemplateViewButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.MappingTemplateViewButtonXpath);

        private IElement MappingTemplateEditButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.MappingTemplateEditButtonXpath);

        private IElement MappingTemplateCancelButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.MappingTemplateCancelButtonXpath);

        private IElement MappingTemplateSaveButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.MappingTemplateSaveButtonXpath);

        private IElement MappingTemplateInput => driver.Element.GetElement(SearchType.ByXpath, Selectors.MappingTemplateInputXpath);

        private IElement SolutionConfigurationSection => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionConfigurationSectionXpath);

        private IElement SolutionConfigurationGeneralSection => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionConfigurationGeneralSectionXpath);
        private IElement DynamicConfigurationFields(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.DynamicConfigurationFieldsXpath(value));

        private IElement DynamicFieldsInputType(string value, string type) => driver.Element.GetElement(SearchType.ByXpath, Selectors.DynamicFieldsInputTypeXpath(value, type));
        private IElement DynamicFieldsInput(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.DynamicFieldsInputXpath(value));

        private IElement DynamicFieldsRequiredIcon(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.DynamicFieldsRequiredIconXpath(value));

        private IElement DynamicFieldsWarningRequiredIcon(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.DynamicFieldsWarningRequiredIconXpath(value));
        private IElement DynamicFieldsUpdated(string data) => driver.Element.GetElement(SearchType.ByXpath, Selectors.DynamicFieldsUpdatedXpath(data));
        private IElement Uploadfile => driver.Element.GetElement(SearchType.ByXpath, Selectors.UploadFileXpath);
        private IElement UploadedFacilityCodeValue => driver.Element.GetElement(SearchType.ByXpath, Selectors.UploadedFacilityCodeValueXpath);
        private IElement UploadedFileIncompleteWanring => driver.Element.GetElement(SearchType.ByXpath, Selectors.UploadedFileIncompleteWarningXpath);
        private IElement UploadedFileInvalidWarning => driver.Element.GetElement(SearchType.ByXpath, Selectors.UploadedFileInvalidWarningXpath);
        private IElement RemoveUploadedFileButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.RemoveUploadedFileButtonXpath);
        private IElement UploadedFacilityCodeTempValue => driver.Element.GetElement(SearchType.ByXpath, Selectors.UploadedFacilityCodeTempValueXpath);
        private IElement SolutionButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionButtonXpath);
        private IElement UploadedFileDuplicateWarning => driver.Element.GetElement(SearchType.ByXpath, Selectors.UploadedFileDuplicateWarningXpath);
        private IElement SolutionConfigurationLabel(string configurationLabel) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionConfigurationLabelXpath(configurationLabel));
        private IElement FacilityCodeInput => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityCodeInputXpath);
        private IElement SiteCode => driver.Element.GetElement(SearchType.ByXpath, Selectors.SiteCodeXpath);
        private IElement FacilityConfigurationsEditButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityConfigurationsEditButtonXpath);
        private IElement FacilityConfigurationsViewButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityConfigurationsViewButtonXpath);
        private IElement AddRowLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddRowLinkXpath);
        private IEnumerable<IElement> FacilityConfigurationRecords => driver.Element.GetElements(SearchType.ByXpath, Selectors.FacilityConfigurationRecordsXpath);
        private IElement AddRecordsErrorMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddRecordsErrorMessageXpath);
        private IElement AddRecordsErrorMessageCloseButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.AddRecordsErrorMessageCloseButtonXpath);
        private IElement FacilityConfigurationClosePopOut => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityConfigurationClosePopOutXpath);
        private IElement SiteIdentity => driver.Element.GetElement(SearchType.ByXpath, Selectors.SiteIdentityXpath);
        private IElement SiteName => driver.Element.GetElement(SearchType.ByXpath, Selectors.SiteNameXpath);
        private IElement SitePassword => driver.Element.GetElement(SearchType.ByXpath, Selectors.SitePasswordXpath);
        private IElement SiteCodePopUp => driver.Element.GetElement(SearchType.ByXpath, Selectors.SiteCodePopUpXpath);
        private IElement HL7FileTypeFileName => driver.Element.GetElement(SearchType.ByXpath, Selectors.HL7FileType_FileName);

        private IElement HL7FileTypeMessageType => driver.Element.GetElement(SearchType.ByXpath, Selectors.HL7FileType_MessageType);
        private IEnumerable<IElement> FacilityConfigurationRemoveIcon => driver.Element.GetElements(SearchType.ByXpath, Selectors.FacilityConfigurationRemoveIconXpath);
        private IElement FacilityConfigurationInputField(string FieldName) => driver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityConfigurationInputFieldXpath(FieldName));

        #endregion

        #region Message Tracing Page
        private IElement MessageTracingTab => driver.Element.GetElement(SearchType.ByXpath, Selectors.MessageTracingTabXpath);
        private IEnumerable<IElement> OpenedEmbeddedTabsMessageTracing => driver.Element.GetElements(SearchType.ByXpath, Selectors.OpenedEmbeddedTabsMessageTracingXapth);
        private IElement SearchTermField => driver.Element.GetElement(SearchType.ByXpath, Selectors.SearchTermFieldXpath);
        private IElement SolutionLabelMandatory => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionLabelMandatoryXpath);
        private IElement SolutionMandatoryMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionMandatoryMessageXpath);
        //private IElement SolutionDropDown => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionDropDownXpath);
        private IEnumerable<IElement> SolutionNameColumnData => driver.Element.GetElements(SearchType.ByXpath, Selectors.SolutionNameColumnDataXpath);
        private IElement SearchButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.SearchButtonXpath);
        private IElement MessageTracingErrorPopup => driver.Element.GetElement(SearchType.ByXpath, Selectors.ModalPopupXpath);

        private IElement StartDateCheckBox => driver.Element.GetElement(SearchType.ByXpath, Selectors.StartDateCheckboxXpath);

        private IElement EndDateCheckBox => driver.Element.GetElement(SearchType.ByXpath, Selectors.EndDateCheckboxXpath);

        //private IElement StartDateCalender => driver.Element.GetElement(SearchType.ByXpath, Selectors.StartDateCalenderXpath);

        //private IElement EndDateCalender => driver.Element.GetElement(SearchType.ByXpath, Selectors.EndDateCalenderXpath);

        private IElement SelectStartDateCalender(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SelectStartDateCalenderXpath(value));

        private IElement SelectEndDateCalender(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SelectEndDateCalenderXpath(value));

        private IElement StartDateTextField => driver.Element.GetElement(SearchType.ByXpath, Selectors.StartDateFieldXpath);
        private IElement EndDateTextField => driver.Element.GetElement(SearchType.ByXpath, Selectors.EndDateFieldXpath);

        private IElement SelectStartDateNextDayCalender(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SelectStartDateNextDayCalenderXpath(value));

        private IElement SelectEndDateNextDayCalender(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SelectEndDateNextDayCalenderXpath(value));
        private IElement ShowsDropdownArrow => driver.Element.GetElement(SearchType.ByXpath, Selectors.ShowsDropdownArrowXpath);
        private IElement ShowsDropdownCurrentValue => driver.Element.GetElement(SearchType.ByXpath, Selectors.ShowsDropdownCurrentValueXpath);
        private IElement NumberofDisplayedSearchResults => driver.Element.GetElement(SearchType.ByXpath, Selectors.NumberofDisplayedSearchResultsXpath);
        //private IElement NextSearchResults => driver.Element.GetElement(SearchType.ByXpath, Selectors.NextSearchResultsXpath);
        private IElement MessageTracingEmbeddedTabText => driver.Element.GetElement(SearchType.ByXpath, Selectors.MessageTracingEmbeddedTabTextXpath);
        private IElement SolutionNameInDropdown(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionNameInDropdownXpath(value));
        private IElement SolutionDropdownButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionDropdownButtonXpath);
        private IElement SolutionRequiredWarning => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionRequiredWarningXpath);
        private IEnumerable<IElement> MessageTracingResultsRow => driver.Element.GetElements(SearchType.ByXpath, Selectors.MessageTracingResultsRowXpath);
        private IElement SolutionDropdownField => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionDropdownFieldXpath);
        private IElement StartDateCalenderIcon => driver.Element.GetElement(SearchType.ByXpath, Selectors.StartDateCalenderIconXpath);
        private IElement EndDateCalenderIcon => driver.Element.GetElement(SearchType.ByXpath, Selectors.EndDateCalenderIconXpath);
        private IEnumerable<IElement> CalendarDays => driver.Element.GetElements(SearchType.ByXpath, Selectors.CalendarDaysXpath);
        private IElement CalenderNextHours => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderNextHoursXpath);
        //private IElement CalenderPreviousHours => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderPreviousHoursXpath);
        private IElement CalenderNextMinute => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderNextMinuteXpath);
        //private IElement CalenderPreviousMinute => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderPreviousMinuteXpath);
        private IElement CalenderNextSecond => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderNextSecondXpath);
        //private IElement CalenderPreviousSecond => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderPreviousSecondXpath);
        private IElement CalenderNextAM_PM => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderNextAM_PM_Xpath);
        //private IElement CalenderPreviousAM_PM => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderPreviousAM_PM_Xpath);
        private IElement SelectNextCalendarMonth => driver.Element.GetElement(SearchType.ByXpath, Selectors.SelectNextCalenderMonthXpath);
        private IElement SelectPreviousCalenderMonth => driver.Element.GetElement(SearchType.ByXpath, Selectors.SelectPreviousCalenderMonthXpath);
        private IElement CalenderMonth => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderMonthXpath);
        private IElement CalenderYear => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalenderYearXpath);
        private IElement DisplayedHoursCalendar => driver.Element.GetElement(SearchType.ByXpath, Selectors.DisplayedHoursCalendarXpath);
        private IElement DisplayedMinuteCalendar => driver.Element.GetElement(SearchType.ByXpath, Selectors.DisplayedMinuteCalendarXpath);
        private IElement DisplayedSecondCalendar => driver.Element.GetElement(SearchType.ByXpath, Selectors.DisplayedSecondCalendarXpath);
        private IElement DisplayedAM_PMCalendar => driver.Element.GetElement(SearchType.ByXpath, Selectors.DisplayedAM_PMCalendarXpath);
        private IElement HideFiltersLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.HideFiltersXpath);
        private IElement ShowFiltersLink => driver.Element.GetElement(SearchType.ByXpath, Selectors.ShowFiltersXpath);
        private IElement MessageTracingRecordByIndex(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.MessageTracingRecordByIndexXpath(value));
        //private IElement MessageTracingRecordCloseButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.MessageTracingRecordCloseButtonXpath);
        //private IElement CalendarOKButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalendarOKButtonXpath);
        private IElement CalendarPopup => driver.Element.GetElement(SearchType.ByXpath, Selectors.CalendarPopupXpath);

        private IElement StartDatePlaceHolder(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.StartDatePlaceHolderXpath(value));

        private IElement EndDatePlaceHolder(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.EndDatePlaceHolderXpath(value));

        private IElement InvalidDateTimeError => driver.Element.GetElement(SearchType.ByXpath, Selectors.InvalidDateTimeErrorXpath);
        private IElement EndDateError => driver.Element.GetElement(SearchType.ByXpath, Selectors.EndDateErrorXpath);
        private IElement NextSearchResults => driver.Element.GetElement(SearchType.ByXpath, Selectors.NextSearchResultsXpath);
        private IElement TimeModal => driver.Element.GetElement(SearchType.ByXpath, Selectors.TimeModalXpath);
        private IElement MessageTracingTabColumns(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.MessageTracingTabColumnsXpath(value));
        private IElement ResizerMessageTracing(string value) => driver.Element.GetElement(SearchType.ByXpath, Selectors.ResizerXpath(value));
        private IElement HL7MessageText => driver.Element.GetElement(SearchType.ByXpath, Selectors.HL7MessageTextXpath);

        private IEnumerable<IElement> HL7Level1 => driver.Element.GetElements(SearchType.ByXpath, Selectors.HL7Level1Xpath);

        private IEnumerable<IElement> HL7Level2 => driver.Element.GetElements(SearchType.ByXpath, Selectors.HL7Level2Xpath);

        private IEnumerable<IElement> CollapsableHL7Tree => driver.Element.GetElements(SearchType.ByXpath, Selectors.CollapsableHL7TreeXpath);
        private IEnumerable<IElement> ExpandAllHL7Tree => driver.Element.GetElements(SearchType.ByXpath, Selectors.ExpandAllHL7TreeXpath);

        #endregion

        //private IEnumerable<IElement> FacilityCodeText => _webDriver.Element.GetElements(SearchType.ByXpath, Selectors.FacilityCodeTextXpath);
        //private IElement DisplayedAM_PMCalendar(string value) => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.DisplayedAM_PMCalendarXpath(value));


        //private IElement FacilityCodeSpecialCharWarning => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityCodeSpecialCharWarningXpath);
        //private IElement FacilityCodeLengthWarning => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.FacilityCodeLengthWarningXpath);

        //Monitoring tab
        #region Monitoring tab
        private IElement MonitoringTab => driver.Element.GetElement(SearchType.ByXpath, Selectors.MonitoringTabXpath);
        private IElement MonitoringTabError => driver.Element.GetElement(SearchType.ByXpath, Selectors.MonitoringTabNotAccessXpath);
        //private IElement MonitoringTab_DropDownList => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.MonitoringTabDropDownListXpath);
        private IElement SolutionDropdownList_MonitoringTab => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionDropdownMonitoringTabXpath);
        private IEnumerable<IElement> SolutionDropdown_MonitoringTab => driver.Element.GetElements(SearchType.ByXpath, Selectors.SolutionDropdownList_MonitoringXpath);
        private IElement SolutionNameInDropdownList_MonitoringTab(string solutionName) => driver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionNameInSolutionDropdown_MonitoringTabXpath(solutionName));
        private IElement SearchButton_MonitoringTab => driver.Element.GetElement(SearchType.ByXpath, Selectors.SearchButtonMonitoringTabXpath);
        private IElement DateTime_MonitoringTab => driver.Element.GetElement(SearchType.ByXpath, Selectors.DateTime_MonitoringTabXpath);
        private IElement LastRefreshed => driver.Element.GetElement(SearchType.ByXpath, Selectors.LastRefreshedXpath);
        private IElement LastFailedMessageDelivery => driver.Element.GetElement(SearchType.ByXpath, Selectors.LastFailedMessageDeliveryXpath);
        private IElement ReasonForLastFailedMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.ReasonForLastFailedMessageDeliveryXpath);
        private IElement LastSuccessfullMessageDelivered => driver.Element.GetElement(SearchType.ByXpath, Selectors.LastSuccessfulMessageDeliveredXpath);
        private IElement UnProcessableMessagesInLast24Hrs => driver.Element.GetElement(SearchType.ByXpath, Selectors.UnProcessableMessagesInLast24HrsXpath);
        private IElement UnProcessableMessagesInLast5mins => driver.Element.GetElement(SearchType.ByXpath, Selectors.UnProcessableMessagesInLast5minsXpath);
        private IElement LastUnProcessableMessageReceived => driver.Element.GetElement(SearchType.ByXpath, Selectors.LastUnProcessableMessageReceivedAtXpath);
        private IElement ReasonForLastUnProcessableMessage => driver.Element.GetElement(SearchType.ByXpath, Selectors.ReasonForLastUnProcessableMessageXpath);

        private IElement RefreshButton_MonitoringTab => driver.Element.GetElement(SearchType.ByXpath, Selectors.RefreshButtonXpath);
        #endregion

        #region Global Connection/Comm Status (NOT USE CURRENTLY)
        //private IElement GlobalConnectionShowRowsDropdown => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.ShowRowsDropdownXpath);
        //private IElement HL7EditButton => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.ConfigurationEditButtonXpath);
        private IElement GeneralAccordion => driver.Element.GetElement(SearchType.ByXpath, Selectors.GeneralAccordion);
        //public IElement GlobalConnectionsButton => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionsTabButtonXpath);
        //public IElement AddNewGlobalConnectionButton => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewGlobalConnectionButtonXpath);
        //public IElement AddNewGlobalConnectionHeading => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.AddNewGlobalConnectionHeadingXpath);
        //public IElement ShowRowsDropdownValue(string value) => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.ShowRowsDropdownValueXpath(value));
        //public IEnumerable<IElement> FacilityCodeText => _webDriver.Element.GetElements(SearchType.ByXpath, Selectors.FacilityCodeTextXpath);
        //private IEnumerable<IElement> GlobalConnectionRows => _webDriver.Element.GetElements(SearchType.ByXpath, Selectors.GlobalConnectionRowXpath);
        //private IElement GlobalConnectionIpField => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionIpFieldXpath);
        //private IElement GlobalConnectionTypeField => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionTypeDropdownXpath);
        //private IElement GlobalConnectionPortField => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionPortFieldXpath);
        //private IElement GlobalConnectionNameField => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionNameFieldXpath);
        //private IElement GlobalConnectionDescriptionField => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionDescriptionFieldXpath);
        //private IElement GlobalConnectionIpResult => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionIpInRow);
        //private IElement GlobalConnectionPortResult => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionPortInRow);
        //private IElement GlobalConnectionNameRequiredText => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionNameRequiredTextXpath);
        //private IElement GlobalConnectionTypeRequiredText => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionTypeRequiredTextXpath);
        //private IElement GlobalConnectionDescriptionRequiredText => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionDescriptionRequiredTextXpath);
        //private IElement GlobalConnectionPage => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionPageXpath);
        //public IElement CommStatusTabButton => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.CommStatusTabButtonXpath);
        //public IElement CommStatusPage => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.CommStatusPageXpath);
        //public IElement GlobalConnection => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.ExpandRowsXpath);
        //public IElement DeleteConfirmationPopup => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.DeleteConfirmationPopupXpath);
        //public IElement NoGlobalConnectionText => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.NoGlobalConnectionTextXpath);
        //private IElement GlobalConnectionNameLabel => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionNameLabelXpath);
        //private IElement GlobalConnectionTypeLabel => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionTypeLabelXpath);
        //private IElement GlobalConnectionDescriptionLabel => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.GlobalConnectionDescriptionLabelXpath);
        //public IElement SolutionsDropdownField => _webDriver.Element.GetElement(SearchType.ByXpath, Selectors.SolutionDropdownFieldXpath);
        #endregion


    }

}
