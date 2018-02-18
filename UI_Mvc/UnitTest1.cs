using System;


namespace UI_Mvc
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using System;
    [TestClass]
    public class UnitTest1
    {
        private string baseURL = "https://usfglobaldepartments.azurewebsites.net";
        private RemoteWebDriver driver;
        private string browser;
        public TestContext TestContext
        {
            get; set;
        }
            [TestMethod]
        public void Verify_Navigation_to_Dept()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(this.baseURL);
            driver.FindElementByName("userId").Clear();
            driver.FindElementByName("userId").SendKeys("farzanajahan");

            driver.FindElementByName("password").Clear();
            driver.FindElementByName("password").SendKeys("123");


            driver.FindElementByXPath("/html/body/div/form/input[3]").Click();
            Console.WriteLine("Test");
            System.Threading.Thread.Sleep(5000);



            // String text= driver.FindElementByXPath("/html/body/div").Text;
            // Assert.IsTrue(text.Contains("Status: Authenticated"));

            String header = driver.FindElementByXPath("html/body/header/div/h1").Text;
            Assert.IsTrue(header.Contains("USF Health Global Departments"));

               driver.FindElementById("toggle").Click();
            System.Threading.Thread.Sleep(5000);


            String deptText = driver.FindElementByXPath(".//*[@id='fast_table']/thead/tr/th[1]").Text;
              Assert.IsTrue(deptText.Contains("USF_DEPT_CODE"));
            System.Threading.Thread.Sleep(1000);


            String firstDept=driver.FindElementByXPath(".//*[@id='SC_fast_GK_1_DK_487']/td[1]").Text;
            Assert.IsTrue(firstDept.Contains("600120"));

            driver.FindElementById("toggle").Click();
            System.Threading.Thread.Sleep(1000);


            Assert.IsFalse(IsDeptHeaderDisplayed());

        }
        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
            driver.Dispose();
        }

        public Boolean IsDeptHeaderDisplayed()
        {
            try
            {
                String deptText = driver.FindElementByXPath(".//*[@id='fast_table']/thead/tr/th[1]").Text;
                return deptText.Contains("USF_DEPT_CODE");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }
    }
}
