
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace ExcelExtentReports
{
    public static class SeleniumSetMethods
    {
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }
        public static void DDL(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);

        }
    }
}
