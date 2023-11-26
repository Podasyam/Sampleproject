using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using POMExample.PageFlow;
using POMExample.Common;
using System;
using System.IO;
using System.Reflection;
using Tests.TestData;


namespace Tests.Testcases
{
    [TestFixture]
    public class Test
    {

        private readonly MainPageFlow mainpageflow = new MainPageFlow();
        ExtentReports rep = ExtentReporting.getInstance();
        public static ExtentTest test;
        public ExtentReports extent;


        [OneTimeSetUp]
        public void Setup()
        {
            try
            {            

                mainpageflow.StartExecution();
                ExtentReporting.LogPass($"Initial Setup has Passed");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Exception:  { ex.Message }");
                ExtentReporting.LogPass($"Initial Setup has Failed");
            }
        }

        [Test, Order(1)]
        public void TC1_VerifyTextAutomation() // Testcase to check the text Automation is present on the screen or not.
        {
            try
            {

                ExtentReporting.LogInfo("Starting Testcase001 - check Text Automation");

                string _textAutomation = mainpageflow.CheckTextAutomationOnScreen();
                Assert.AreEqual("Automation", _textAutomation, "Text 'Automation' is not matching");

                ExtentReporting.LogPass($"Test has Passed");
                getScreenshot();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:  { ex.Message }");
                ExtentReporting.LogFail($"Test has Failed");
                getScreenshot();

            }
        }

         [Test, Order(2)]
         public void TC2_VerifyservicesandautomationTabIsSelectedTest() // Testcase to check the services and automation tab is selected.
         {
             try
             {
                 ExtentReporting.LogInfo("Start Testcase 002 - VerifyservicesandautomationTabIsSelectedTest");
                 bool flag = mainpageflow.validateServicetabIsSelected();
                 Assert.IsTrue(flag);
                 ExtentReporting.LogPass($"Test has Passed");
                 getScreenshot();


             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Exception:  { ex.Message }");
                 ExtentReporting.LogFail($"Test has Failed");
                 getScreenshot();
             }
         }

         [Test, Order(3)]
         public void TC3_SubmitContactDetails() // Testcase to submit contact details and verify the Thank you message.
         {
             try
             {
                 var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                 var relativepath = @"..\..\..\..\Tests\TestData";
                 var DataSheetPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativepath));
                 ExcelOperations.PopulateInCollection(DataSheetPath + "\\Data1.xlsx");
                 var Firstname = ExcelOperations.ReadData(1, "FirstName");    // Get the row 1 value from Row 1 and column name = FirstName. Tried it only for FirstName only to show DataDriven sample          
                 var LastName = ExcelOperations.ReadData(1, "LastName");
                 string _textThankyouforContacting = mainpageflow.EnterContactUsDetails(Firstname, LastName, "Test@test.com", "+9181919", "CompanyName", "Message");
                 Assert.AreEqual("Thank you for contacting us.", _textThankyouforContacting, "Thank you message is not matching");
                 ExtentReporting.LogPass($"Test has Passed");
                 getScreenshot();
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Exception:  { ex.Message }");
                 ExtentReporting.LogFail($"Test has Failed");
                 getScreenshot();
             }

         }
         [Test, Order(4)]
         public void TC4_VerifyCountryLinks() // Check the country link is working or not
         {
             try
             {
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("Belgium").Contains("Sogeti Belgium"), "new window title 'Sogeti Belgium' is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("Finland").Contains("Sogeti | Etusivu"), "Finland new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("France").Contains("Sogeti France"), "France new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("Germany").Contains("Sogeti Deutschland GmbH"), "Germany new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("Ireland").Contains("Sogeti Ireland"), "Ireland new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("Luxembourg").Contains("Sogeti Luxembourg"), "Luxembourg new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("Netherlands").Contains("We Make Technology Work | Sogeti"), "Netherlands new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("Norway").Contains("Sogeti Norge"), "Norway new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("Spain").Contains("Sogeti Espa"), "Spain new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("Sweden").Contains("Sogeti Sverige"), "Sweden new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("UK").Contains("Sogeti UK"), "UK new window title is not matching");
                 Assert.IsTrue(mainpageflow.CheckWorldwideCountryLinks("USA").Contains("Sogeti USA"), "USA new window title is not matching");
                 ExtentReporting.LogPass($"Test has Passed");
                 getScreenshot();

             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Exception:  { ex.Message }");
                 ExtentReporting.LogFail($"Test has Failed");
                 getScreenshot();
             }
         }

        public void getScreenshot() // Quit the execution after executing all the testcases.
        {
            try
            {

                mainpageflow.CaptureScreenshot();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:  { ex.Message }");
            }

        }

        [OneTimeTearDown]
        public void OneTimeTearDown() // Quit the execution after executing all the testcases.
        {
            try
            {
                
                mainpageflow.StopExecution();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:  { ex.Message }");
            }

        }

    }
}