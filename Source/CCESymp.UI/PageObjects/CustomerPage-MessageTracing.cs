using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Resources;
using CCESymp.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CCESymp.UI.Utilities;
using CCESymp.Data;
using OpenQA.Selenium.Chrome;
using BD.Automation.Core.Drivers.Models;
using CCESymp.Data.Mapping.IMSMapping;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Interactions;

namespace CCESymp.UI.PageObjects
{
    public partial class CustomerPage
    {

        /// <summary>
        /// Click on message tracing tab
        /// </summary>
        public void ClickMessageTracingTab() => Utilities.ClickElement(SearchType.ByXpath, Selectors.MessageTracingTabXpath);

        
        /// <summary>
        /// Checks if the warning for the maximum limit of message tracing search tabs is displayed
        /// </summary>
        public bool IsMaxMessageTrackingTabsLimitWarningDisplayed() => Utilities.IsElementDisplayed(SearchType.ByXpath, Selectors.MaxLimitMessageTracingTabsWarningXpath, 20, "MAX LIMIT WARNING MESSAGE");

        /// <summary>
        /// Returns the count of search tabs that are currently opened
        /// </summary>
        public int GetCountOfActiveEmbeddedTabsMessageTracing() => OpenedEmbeddedTabsMessageTracing.Count();


        private void SendUTCValueToStartDate(string Value)
        {
            StartDateTextField.SendKeys(Value);

            if (string.IsNullOrEmpty(StartDateTextField.GetAttributeValue("value").Trim()))
            {
                SendUTCValueToStartDate(Value);
            }
        }

    }
}
