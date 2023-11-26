using OpenQA.Selenium;
using System;
using System.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace POMExample.Common
{
    public class Base
    {
        public enum Drivers
        { 
         Chrome,
         Firefox        
        }
        public static IWebDriver _driver;
        public string baseUrl = "https://www.sogeti.com/";
        
        

        internal static IWebDriver GetDriver(Drivers drivers)
        {

            //ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);

           var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);            
           var relativepath = @"..\..\..\..\POMExample\Drivers";
           var chromeDriverPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativepath));
            return new ChromeDriver(chromeDriverPath);
        }

         public void LaunchBrowser() //Launch the chrome browser and pass the website url
         {
            try
            {
                _driver = GetDriver(Drivers.Chrome);              
                System.Threading.Thread.Sleep(5000);               
                
                _driver.Navigate().GoToUrl(baseUrl);
                
                _driver.Manage().Window.Maximize();

                AcceptCookies();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error:  { ex.Message }");
            }

        }

        public void AcceptCookies() // Accept the cookies on the page
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            string cookies_accept = "//*[@id='CookieConsent']/div[1]/div/div[2]/div[2]/button[1]";
            findElement(cookies_accept, 6);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='CookieConsent']/div[1]/div/div[2]/div[2]/button[1]"))).Click();

        }
        public IWebElement findElement(string locator, int timeoutSeconds)// Wait the element is available in a certain interval of time
        {
            //FluentWait Declaration
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(400);
            return fluentWait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
        }
        public string GetPageTitle() // To get the page Title for each country
        {

            try
            {
                string newTabHandle = _driver.WindowHandles.Last();
                var newTab = _driver.SwitchTo().Window(newTabHandle);
                return newTab.Title;
            }

            catch (Exception ex)
            {
                return ex.Message;

            }

            finally
            {
                _driver.Close();
                _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            }

        }

        //public void TakeScreenshot()
        //{
        //    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    var relativepath = @"..\..\..\..\POMExample\Screenshots";
        //    var ScreenshotPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativepath));
        //    Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
        //    var screen = ScreenshotPath + "Image.png";
        //    screenshot.SaveAsFile(screen);
                 
        //}

        public string TakeScreenshot()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativepath = @"..\..\..\..\POMExample\Screenshots";
            var ScreenshotPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativepath));
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var img = screenshot.AsBase64EncodedString;
            return img;

        }
        public void QuitDriver()//Stop the execution and quit the driver after executing all the cases.
        {

            //EndTest();            
            ExtentReporting.EndReport();
            _driver.Quit();
        }

        private void EndTest()
        {

            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;


            switch (testStatus)
            {

                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has Failed{message}");
                    break;

                case TestStatus.Skipped:
                    ExtentReporting.LogFail($"Test skipped{message}");
                    break;

                default:
                    break;


            }


            ExtentReporting.LogScreenshot("Ending Test",TakeScreenshot());
        
        }

        public void QuitTest()//Stop the execution and quit the driver after executing all the cases.
        {

            EndTest();
           
        }

    }
}



