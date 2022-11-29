using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using BD.Automation.Core.Drivers.Models;
namespace CCESymp.UI.Utilities
{
    public class Wrappers : BaseDriver 
    {
        private void WaitInterval(int seconds = 2) => System.Threading.Thread.Sleep(seconds * 1000);

        /// <summary>
        /// Clicks on the element specified on the provided <paramref name="selector"/>
        /// </summary>
        public void ClickElement(SearchType type, string selector, int timeout = 20, string elementInfo = "")
        {
            WaitInterval();
            try
            {
                driver.Wait.UntilElementIsVisible(type, selector, timeout);
                driver.Wait.UntilElementToBeClickable(type, selector, timeout);
                Logger.Info($"The searched button element was successfully found");
            }
            catch
            {
                //Logger.Info(ex.Message);
                Logger.Info($"Could not find element using selector: {selector}");
            }

            var _buttonElement = driver.Element.GetElement(type, selector);

            try
            {
                if (string.IsNullOrEmpty(elementInfo)) 
                { 
                    elementInfo = _buttonElement.Text;
                }
                Logger.Info($"Attempting to click {elementInfo} element using Selenium component");
                _buttonElement.Click();
            }
            catch
            {
                Logger.Info("Could not click specified element using selenium");
                Logger.Info("Attempting to click element using JS");
                driver.Browser.ExecuteScript("arguments[0].click();", _buttonElement);
            }
        }
        /// <summary>
        /// Validates if the element specified on the provided <paramref name="selector"/> is visible on GUID
        /// </summary>
        public bool IsElementDisplayed(SearchType type, string selector, int timeout, string elementLog) {
            try
            {
                Logger.Info($"Waiting until {elementLog} exists on the DOM, timeout will stop at {timeout} seconds");
                driver.Wait.UntilElementExists(type, selector, timeout);
                Logger.Info($"Waiting until {elementLog} is displayed on the UI, timeout will stop at {timeout} seconds");
                driver.Wait.UntilElementIsVisible(type, selector, timeout);
                WaitInterval();
                return driver.Element.GetElement(type, selector).Displayed;
            }
            catch {
                Logger.Info($"The element called {elementLog} was not displayed on the UI");
                WaitInterval();
                return false;
            }
        }

        /// <summary>
        /// Validate if mouse hover on icon
        /// </summary>

        public void MouseHoverToElement(SearchType type, string selector)
        {
            Logger.Info("Hover mouse to specific element '" + selector);
            try
            {
                var element = driver.Element.GetElement(type, selector);
                driver.Action.MoveToElement(element);
                driver.Action.Perform();
            }
            catch (Exception e)
            {
                Logger.Info($" Unable to hover mouse to specific element '{selector}' \n Error: " + e.Message);
                throw new Exception("Error Message: " + e.Message);
            }
        }

        /// <summary>
        /// Validates if the element specified on the provided <paramref name="selector"/> is exists on the current page... element visibility is optional
        /// </summary>
        public bool DoesElementExist(SearchType type, string selector, int timeout = 20, string log = "" ) {
            try
            {
                Logger.Info($"Attempting to locate {log} element on the page");
                Logger.Info($"Waiting until {log} exists on the page");
                driver.Wait.UntilElementExists(type, selector, timeout);
                Logger.Info("returning result");
                return driver.Element.Exists(type, selector);
            }
            catch {
                Logger.Info("Specified element could not be found\nReturning false value...");
                return false;
            }
        }

        public string decToHexa(int n)
        {

            // char array to store
            // hexadecimal number
            char[] hexaDeciNum = new char[2];

            // Counter for hexadecimal
            // number array
            int i = 0;
            while (n != 0)
            {

                // Temporary variable to
                // store remainder
                int temp = 0;

                // Storing remainder in
                // temp variable.
                temp = n % 16;

                // Check if temp < 10
                if (temp < 10)
                {
                    hexaDeciNum[i] = (char)(temp + 48);
                    i++;
                }
                else
                {
                    hexaDeciNum[i] = (char)(temp + 55);
                    i++;
                }
                n = n / 16;
            }
            string hexCode = "";

            if (i == 2)
            {
                hexCode += hexaDeciNum[1];
                hexCode += hexaDeciNum[0];
            }
            else if (i == 1)
            {
                hexCode = "0";
                hexCode += hexaDeciNum[0];
            }
            else if (i == 0)
                hexCode = "00";

            // Return the equivalent
            // hexadecimal color code
            return hexCode;
        }

        public string convertRGBtoHex(int R, int G,
                                     int B)
        {
            if ((R >= 0 && R <= 255) &&
                (G >= 0 && G <= 255) &&
                (B >= 0 && B <= 255))
            {
                string hexCode = "#";
                hexCode += decToHexa(R);
                hexCode += decToHexa(G);
                hexCode += decToHexa(B);

                return hexCode;
            }

            // The hex color code doesn't exist
            else
                return "-1";
        }

        public void ScrollToFindElement(SearchType type, string selector)
        {
            Logger.Info("Scroll to specific element '" + selector);

            try
            {
                var element = driver.Element.GetElement(type, selector);
                element.SendKeys(Keys.PageDown);
            }
            catch (Exception e)
            {
                Logger.Info($" Unable to Scroll to specific element '{selector}' \n Error: " + e.Message);
                throw new Exception("Error Message: " + e.Message);
            }
        }

        /// <summary>
        /// Validate if links are clickable
        /// </summary>

        public void ClickOnElement(SearchType type, string selector)
        {
            Logger.Info("Click on specific element '" + selector);
            var element = driver.Element.GetElement(type, selector);

            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                Logger.Info($" Unable to click on specific element '{selector}' \n Error: " + e.Message);
                throw new Exception("Error Message: " + e.Message);
            }
        }

    }
}
