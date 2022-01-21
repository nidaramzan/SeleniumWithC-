using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
namespace videoForm
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();

            driver.Navigate().GoToUrl("https://demosite.executeautomation.com/index.html");
            IWebElement e1 = driver.FindElement(By.Name("Initial"));
            IWebElement e2 = driver.FindElement(By.Name("FirstName"));
            IWebElement e3 = driver.FindElement(By.Name("MiddleName"));
            driver.FindElement(By.Name("Male")).Click();
            driver.FindElement(By.Name("Hindi")).Click();
            new SelectElement(driver.FindElement(By.Name("TitleId"))).SelectByText("Mr.");
            e1.SendKeys("Ececute Automation");
            e2.SendKeys("Kar");
            e3.SendKeys("tik");
            driver.FindElement(By.Name("Save")).Click();//first page
            //driver.Close();
        }
    }
}
