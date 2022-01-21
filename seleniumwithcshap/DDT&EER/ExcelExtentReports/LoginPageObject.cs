
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ExcelExtentReports
{
    class LoginPageObject
    {

        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Name, Using = "Login")]
        public IWebElement btnLogin { get; set; }

        public EAPageObject Login(string userName, string password)
        {
            txtUserName.EnterText(userName);
            txtPassword.EnterText(password);
            btnLogin.Submit();
            return new EAPageObject();
        }
    }
}


