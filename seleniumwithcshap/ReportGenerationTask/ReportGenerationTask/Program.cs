using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit;

using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.IO;



namespace videoForm
{   [TestFixture]
    public class Program
    {
        static void Main(string[] args)
        {
            
        }
        public static ExtentTest test;
        public static ExtentReports extent;


        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("https://executeautomation.com/demosite/Login.html");
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\Users\nida.ramzan\source\repos\ExcelExtentReports\ExcelExtentReports\ReportResults" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
        }

        [Test]
        public void ExecutionTest() {
            test = null;
            test = extent.CreateTest("Test1").Info("Test Started");
            ExcelLib.PopulateIncollection(@"D:\Data.xlsx");
            test.Log(Status.Info, "Data Fatched");
            LoginPageObject pageLogin = new LoginPageObject();
            EAPageObject pageEA = pageLogin.Login(ExcelLib.ReadData(1,"UserName"), ExcelLib.ReadData(1,"Password"));
            test.Log(Status.Info, "Login is done!");
            pageEA.FillUserForm(ExcelLib.ReadData(1, "Initial"), ExcelLib.ReadData(1, "FirstName"),ExcelLib.ReadData(1, "MiddleName"));
            test.Log(Status.Pass, "Data is Entered Successfully!");
        }
        [TearDown]
        public void CleanUp() {
            PropertiesCollection.driver.Close();
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}
