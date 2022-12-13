using BD.Automation.Core.Common.Enums;
using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Interface;
using BD.Automation.Core.Drivers.Models;
using BD.Automation.Core.Drivers.Selenium;
using CCESymp.API.Validation;
using CCESymp.Data;
using CCESymp.Data.Mapping;
using CCESymp.IDMServices.Services;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.IO;

namespace CCESymp.API
{
    public class TestBase
    {
        public RestClient client;
        protected IDriver _webDriver;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<OutputAnalisis>")]
        protected ValidateOutput validateOutput { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<DatabaseAccess>")]
        //protected DataRepository dataRepo { get; set; }

        public static string sessionId;


        public TestBase()
        {
            validateOutput = new ValidateOutput();
            //dataRepo = new DataRepository();
        }
        protected log4net.ILog Logger => log4net.LogManager.GetLogger(GetType());



        [OneTimeSetUp]
        public void BeforeClass()
        {
            //IDMUserCreationService.IDMUserCreationScript();
            //GenerateTokens();
            //log4net.Config.XmlConfigurator.Configure();
            ConfigProvider.LoadConfiguration();


        }


        [SetUp]
        public void Beforetest()
        {
            //Need to access to the CCE Symphony site to get the session cookies
            try
            {
            }
            catch (Exception e)
            {
                throw (e);
            }
        }



        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                switch (status)
                {
                    case TestStatus.Failed:
                        //string screenShotPath = Capture(driver, TestContext.CurrentContext.Test.Name);
                        //_test.Log(logstatus, "Snapshot below: " +_test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        break;
                    default:
                        break;
                }
                //dataRepo.DeleteUserSessions();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                //_webDriver.Quit();
            }

        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            try
            {
            }
            catch (Exception e)
            {
                throw (e);
            }
            // _webDriver.Quit();
        }
        public void GenerateTokens()
        {
            if (Common.Common.UserTypeToken.Equals("Admin"))
            {
                AdminToken();
            }
            else
            {
                NonAdminToken();
            }
        }
        private void AdminToken()
        {
            if (Common.Common.AdminAPIAccessToken.Length < 6)
            {
                DataRepository.DeleteUserSessions();
                ChromeOptions options = new ChromeOptions();
                // options.AddArgument("--headless");
                _webDriver = new Driver(WebDriverType.Chrome, LoggerType.Log4Net, WindowSize.Maximize, options);
                NavigateToCCESPostmanEchoURL();
                //Login(Common.Common.HSCEAutoAdminUser, Common.Common.HSCEAutomationPassword);
                //var token = _webDriver.Browser.ExecuteScript("return sessionStorage.getItem('access_token')");
                //Common.Common.AdminAPIAccessToken = Common.Common.GetEnvVar(@"AdminAPIAccessToken", token.ToString());
                //sessionId = _webDriver.Browser.ExecuteScript("return sessionStorage.getItem('session_uuid')").ToString();
                //_webDriver.Quit();
                //dataRepo.DeleteUserSessions();
            }
        }
        private void NonAdminToken()
        {
            if (Common.Common.UserAPIAccessToken.Length < 6)
            {
                DataRepository.DeleteUserSessions();
                ChromeOptions options = new ChromeOptions();
                // options.AddArgument("--headless");
                _webDriver = new Driver(WebDriverType.Chrome, LoggerType.Log4Net, WindowSize.Maximize, options);
                NavigateToCCESPostmanEchoURL();
                //Login(Common.Common.HSCEUser, Common.Common.HSCEAutomationPassword);
                //var token = _webDriver.Browser.ExecuteScript("return sessionStorage.getItem('access_token')");
                //Common.Common.UserAPIAccessToken = Common.Common.GetEnvVar(@"UserAPIAccessToken", token.ToString());
                //sessionId = _webDriver.Browser.ExecuteScript("return sessionStorage.getItem('session_uuid')").ToString();
                ////dataRepo.DeleteUserSessions();
                _webDriver.Quit();
            }
        }
        public void NavigateToCCESymphonyURL()
        {
            Logger.Info("Attempting to navigate to the CCE Symphony URL");
            _webDriver.Navigation.SetUrl(Common.Common.CCESymp_DashboardUI_Url);
            Logger.Info("Trying to locate email input field on the CCE Symphony login screen");
            _webDriver.Wait.UntilElementExists(SearchType.ByXpath, Common.Common.EmailInputXpath, 60);
        }

        public void NavigateToCCESPostmanEchoURL()
        {
            Logger.Info("Attempting to navigate to postman-echo URL");
            _webDriver.Navigation.SetUrl($"{Common.Common.CCESymp_Postman_Echo_Url}/get");
        }

        /// <summary>
        /// Checks the login page is displayed by verifying the user email field exists
        /// </summary>
        public bool IsLoginPageDisplayed()
        {
            Logger.Info("Waiting for email input field existence");
            _webDriver.Wait.UntilElementExists(SearchType.ByXpath, Common.Common.EmailInputXpath, 60);
            Logger.Info("Returning boolean value to check if email input field is displayed");
            return EmailInput.Displayed;
        }
        /// <summary>
        /// Enters a provided string into the email field displayed on the login screen
        /// </summary>
        /// <param name="username">The string value to be entered into the email field</param>
        public void EnterEmail(string username)
        {
            Logger.Info("Waiting for email input field existence");
            _webDriver.Wait.UntilElementExists(SearchType.ByXpath, Common.Common.EmailInputXpath, 60);
            Logger.Info($"Entering provided ({username}) string to email field");
            EmailInput.SendKeys(username);
        }
        /// <summary>
        /// Clicks on the Next button displayed on the login screen
        /// </summary>
        public void ClickNext()
        {
            Logger.Info("Waiting for Next button existence");
            _webDriver.Wait.UntilElementToBeClickable(NextButton, 60);
            Logger.Info("Attempting to click on the next button");
            NextButton.Click();
        }
        /// <summary>
        /// Enters a provided string into the password field displayed on the login screen
        /// </summary>
        /// <param name="password">The string value to be entered into the password field</param>
        public void EnterPassword(string password)
        {
            Logger.Info("Waiting for password input field existence");
            _webDriver.Wait.UntilElementExists(SearchType.ByXpath, Common.Common.PasswordInputXpath, 60);
            Logger.Info($"Entering provided ({password}) string to password field");
            PasswordInput.SendKeys(password);
        }
        /// <summary>
        /// Clicks on the Sign In button displayed on the login screen
        /// </summary>
        public void ClickSignInButton()
        {
            Logger.Info("Waiting for sign in button existence");
            _webDriver.Wait.UntilElementToBeClickable(SignInButton, 60);
            Logger.Info("Attempting to click on the sign in button");
            SignInButton.Click();
        }
        /// <summary>
        /// Performs a user login when username, and password are provided
        /// deleteSessions is an optional parameter which is used to decide
        /// whether existing sessions for mentioned user should be deleted
        /// </summary>
        public void Login(string username, string password, bool deleteSessions = true)
        {
            DataRepository.DeleteUserSessions(deleteSessions);
            Logger.Info("Attempting to login into the CCE Symphony dashboard");
            Common.Common.CurrentUsername = Common.Common.GetEnvVar(@"CurrentUsername", $@"{username}");
            EnterEmail(username);
            ClickNext();
            EnterPassword(password);
            ClickSignInButton();
            try
            {
                _webDriver.Wait.UntilElementExists(SearchType.ByXpath, Common.Common.NavigationBarXpath, 60);
            }
            catch (Exception e)
            {
                Logger.Info("Unable to find navigation bar");
                Logger.Info(e.ToString());
            }
        }

        public IElement EmailInput => _webDriver.Element.GetElement(SearchType.ByXpath, Common.Common.EmailInputXpath);
        public IElement NextButton => _webDriver.Element.GetElement(SearchType.ByXpath, Common.Common.NextButtonXpath);
        public IElement PasswordInput => _webDriver.Element.GetElement(SearchType.ByXpath, Common.Common.PasswordInputXpath);
        public IElement SignInButton => _webDriver.Element.GetElement(SearchType.ByXpath, Common.Common.SignInButtonXpath);
        public IElement NavigationBar => _webDriver.Element.GetElement(SearchType.ByXpath, Common.Common.NavigationBarXpath);
    }
}



