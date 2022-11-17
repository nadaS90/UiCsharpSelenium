using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Interface;
using BD.Automation.Core.Drivers.Models;
using System.Collections.Generic;
using System.Linq;

namespace CCESymp.UI.Utilities
{
    public class TablesUtility : BaseDriver
    {
        private IDriver _webDriver;

        public TablesUtility(IDriver _webDriver)
        {
            this._webDriver = _webDriver;
        }

        public List<List<string>> GetTableData()
        {
            driver.Wait.UntilElementExists(SearchType.ByXpath, "//table", 600);
            driver.Wait.UntilElementToBeClickable(SearchType.ByXpath, "//table", 600);
            List<List<string>> tableElementsList = new List<List<string>>();
            var tableRows = driver.Element.GetElements(SearchType.ByXpath, "//tbody/tr");
            foreach (var tableRow in tableRows)
            {
                var rowCells = tableRow.GetChildElements(SearchType.ByXpath, "descendant::td");
                List<IElement> rowCellsList = rowCells.ToList();

                var stringElements = new List<string>();

                foreach (var Element in rowCellsList)
                {
                    stringElements.Add(Element.Text);
                };

                {
                    tableElementsList.Add(stringElements);
                };
            }
            return tableElementsList;
        }

        public List<List<string>> GetMessageTracingData()
        {

            _webDriver.Wait.UntilElementIsVisible(SearchType.ByXpath, "(//table)[last()]", 60);
            List<List<string>> tableElementsList = new List<List<string>>();
            var tableRows = _webDriver.Element.GetElements(SearchType.ByXpath, "//tr[contains(@class, 'tracing-row')]");
            int flag = 0;
            foreach (var tableRow in tableRows)
            {
                flag++;
                var rowCells = tableRow.GetChildElements(SearchType.ByXpath, "descendant::td");
                List<IElement> rowCellsList = rowCells.ToList();

                var stringElements = new List<string>();

                foreach (var Element in rowCellsList)
                {
                    stringElements.Add(Element.Text);
                };

                {
                    tableElementsList.Add(stringElements);
                };
                if (flag.Equals(15)) { break; }
            }
            return tableElementsList;
        }
    }
}
