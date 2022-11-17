namespace CCESymp.UI.PageObjects
{
    public partial class LoginPage
    {
        private class Selectors
        {
            public static string EmailInputXpath => "//input[@id='email']";
            public static string NextButtonXpath => "//button[@type='submit']";
            public static string PasswordInputXpath => "//input[@id='Password']";
            public static string SignInButtonXpath => "//button[@value='login']";
            public static string InvalidLoginWarningXpath => "//small";
        }
    }
}
