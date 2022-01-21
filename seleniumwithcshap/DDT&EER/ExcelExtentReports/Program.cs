using System;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;


namespace ExcelExtentReports
{
    [TestFixture]
    public class TestDemo1
    {
        static void Main(string[] args)
        {

        }
        //public IWebDriver driver;

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
            var htmlreporter = new ExtentHtmlReporter(@"C:\Users\nida.ramzan\source\repos\ExcelExtentReports\ExcelExtentReports\Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);

        }
       
        [Test]
        public void ExecutionTest()
        {
            test = null;
            test = extent.CreateTest("Test1").Info("Test Started");
            ExcelLib.PopulateIncollection(@"D:\Data.xlsx");
            test.Log(Status.Info, "Data Fatched");
            LoginPageObject pageLogin = new LoginPageObject();
            EAPageObject pageEA = pageLogin.Login(ExcelLib.ReadData(1, "UserName"), ExcelLib.ReadData(1, "Password"));
            test.Log(Status.Info, "Login is done!");
            pageEA.FillUserForm(ExcelLib.ReadData(1, "Initial"), ExcelLib.ReadData(1, "FirstName"), ExcelLib.ReadData(1, "MiddleName"));
            test.Log(Status.Pass, "Data is Entered Successfully!");
        }

        [TearDown]
        public void closeBrowser()
        {
            PropertiesCollection.driver.Close();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}