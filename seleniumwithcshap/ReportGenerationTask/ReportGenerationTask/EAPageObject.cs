using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace videoForm
{
    class EAPageObject
    {

        public EAPageObject()
        { 
        PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        //[FindsBy(How = How.Id, Using = "TitleId")]
        //public IWebElement TitleID { get; set; }

        [FindsBy(How = How.Name, Using = "Initial")]
        public IWebElement txtInitial { get; set; }

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Name, Using = "MiddleName")]
        public IWebElement txtMiddleName { get; set; }

        [FindsBy(How = How.Name, Using = "Save")]
        public IWebElement btnsave { get; set; }

        public void FillUserForm(string initial, string middleName, string firstName)
        {
            txtInitial.EnterText(initial);
            txtMiddleName.EnterText(middleName);
            txtFirstName.EnterText(firstName);
            //TitleID.DDL(titleId);
            btnsave.Clicks();
            //txtInitial.SendKeys(initial);
            //txtFirstName.SendKeys(firstName);
            //.SendKeys(middleName);
           // btnsave.Click();
        }
    }
}
