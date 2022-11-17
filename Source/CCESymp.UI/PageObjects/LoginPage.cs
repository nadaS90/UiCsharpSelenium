using BD.Automation.Core.Drivers;
using BD.Automation.Core.Drivers.Enums;
using CCESymp.Data;
using CCESymp.UI.Utilities;
using Common;

namespace CCESymp.UI.PageObjects
{
    public partial class LoginPage : BasePage<LoginPage>
    {        
        /// <summary>
        /// Checks the login page is displayed by verifying the user email field exists
        /// </summary>
        public bool IsLoginPageDisplayed() => Utilities.IsElementDisplayed(SearchType.ByXpath, Selectors.EmailInputXpath,30, "login page is displayed");
             
        /// <summary>
        /// Enters a provided string into the email field displayed on the login screen
        /// </summary>
        /// <param name="username">The string value to be entered into the email field</param>
        public void EnterEmail(string username)
        {
            Logger.Info("Waiting for email input field existence");
            driver.Wait.UntilElementExists(SearchType.ByXpath, Selectors.EmailInputXpath, 30);
            Logger.Info("Entering selected username/email into email field");
            EmailInput.SendKeys(username);
        }

        /// <summary>
        /// Clicks on the Next button displayed on the login screen
        /// </summary>
        public void ClickNext() => Utilities.ClickElement(SearchType.ByXpath, Selectors.NextButtonXpath, 20, "Next button");
        

        /// <summary>
        /// Enters a provided string into the password field displayed on the login screen
        /// </summary>
        /// <param name="password">The string value to be entered into the password field</param>
        public void EnterPassword(string password)
        {
            Logger.Info("Waiting for password input field existence");
            driver.Wait.UntilElementExists(SearchType.ByXpath, Selectors.PasswordInputXpath, 30);
            Logger.Info("Entering provided password into password field");
            PasswordInput.SendKeys(password);
        }

        /// <summary>
        /// Clicks on the Sign In button displayed on the login screen
        /// </summary>
        public void ClickSignInButton() => Utilities.ClickElement(SearchType.ByXpath, Selectors.SignInButtonXpath,20 ,"Sign In button");    
        

        /// <summary>
        /// Performs a user login when username, and password are provided
        /// deleteSessions is an optional parameter which is used to decide
        /// whether existing sessions for mentioned user should be deleted
        /// </summary>
        public void Login(string username, string password, bool deleteSessions = true)
        {
            Logger.Info($"Attempting to login into the CCE Symphony dashboard using {username} account");
            Common.Common.CurrentUsername = Common.Common.GetEnvVar(@"CurrentUsername", $@"{username}");
            EnterEmail(username);
            ClickNext();
            EnterPassword(password);
            ClickSignInButton();            
        }

    }
}
