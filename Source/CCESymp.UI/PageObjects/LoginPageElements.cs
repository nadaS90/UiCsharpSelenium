using BD.Automation.Core.Drivers.Enums;
using BD.Automation.Core.Drivers.Models;

namespace CCESymp.UI.PageObjects
{
    public partial class LoginPage
    {
        private IElement EmailInput => driver.Element.GetElement(SearchType.ByXpath, Selectors.EmailInputXpath);
        private IElement NextButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.NextButtonXpath);
        private IElement PasswordInput => driver.Element.GetElement(SearchType.ByXpath, Selectors.PasswordInputXpath);
        private IElement InvalidLoginWarning => driver.Element.GetElement(SearchType.ByXpath, Selectors.InvalidLoginWarningXpath);

        private IElement SignInButton => driver.Element.GetElement(SearchType.ByXpath, Selectors.SignInButtonXpath);
    }
}
