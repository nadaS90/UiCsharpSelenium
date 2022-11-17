using BD.Automation.Core.Common.Enums;
using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Interface;
using BD.Automation.Core.Drivers.Selenium;
using Common;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium.Chrome;
using System;

namespace CCESymp.UI.Utilities
{
    public class BaseDriver
    {
        protected static IDriver driver = null;

        /// <summary>
        /// Create the webdriver depending on the Browser selected
        /// </summary>
        public void CreateDriver()
        {
            switch (Common.Common.browsersToRunWith)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddUserProfilePreference("download.default_directory", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads");
                    options.AddUserProfilePreference("download.prompt_for_download", false);
                    driver = new Driver(WebDriverType.Chrome, LoggerType.Log4Net, WindowSize.Maximize, options);
                    break;
                case "Chrome Incognito":
                    ChromeOptions IncognitoOptions = new ChromeOptions();
                    IncognitoOptions.AddUserProfilePreference("download.default_directory", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads");
                    IncognitoOptions.AddUserProfilePreference("download.prompt_for_download", false);
                    IncognitoOptions.AddArgument("--incognito");
                    driver = new Driver(WebDriverType.Chrome, LoggerType.Log4Net, WindowSize.Maximize, IncognitoOptions);
                    break;
                case "Edge":
                    driver = new Driver(WebDriverType.ChromiumEdge, LoggerType.Log4Net);
                    break;
                case "Edge inPrivate":
                    EdgeOptions edgeInPrivateOptions = new EdgeOptions
                    {
                        UseChromium = true
                    };
                    edgeInPrivateOptions.AddArgument("-inprivate");
                    driver = new Driver(WebDriverType.ChromiumEdge, LoggerType.Log4Net, WindowSize.Maximize, edgeInPrivateOptions);
                    break;
                default:
                    driver = new Driver(WebDriverType.Chrome, LoggerType.Log4Net);
                    break;
            }

        }

        /// <summary>
        /// Close all the instaces of the browser
        /// </summary>
        public void QuitDriver()
        {
            if(driver != null)
            {
                driver.Close();
                driver.Quit();
                //CommonUtilities.KillActiveChromeTasks();
                CommonUtilities.KillActiveEdgeTasks();
                //By making the driver null at the end will help us
                //to create a new driver after each test case is finished
                //if not the other test cases will try the driver that 
                //was created first time and that reference not longer exists.
                driver = null;

            }  
            
        }

    }
}
