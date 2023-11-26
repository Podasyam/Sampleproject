using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using System.Reflection;

namespace POMExample.Common
{
    public class ExtentReporting
    {

        public static ExtentTest test;
        public static ExtentReports extent;

        public static ExtentReports getInstance()
        {
          if(extent == null)
            {

           
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\";           
            //var htmlreporter = new ExtentHtmlReporter(@"C:\Users\QUO9\Desktop\Load\index" +" " + DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm:ss") + ".html");
            var htmlreporter = new ExtentHtmlReporter(path);
            string date = @"C:\Users\QUO9\Desktop\Load\index" + DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss") + ".html";
            extent = new ExtentReports();     
            extent.AttachReporter(htmlreporter);            
            extent.AddSystemInfo("OS", "Windows");
            extent.AddSystemInfo("Execution Type", "System Testing");
            test = extent.CreateTest("Demo Website");
            test.AssignAuthor("Syam Poda");
            test.AssignDevice("Local Machine");           
           }

            return extent;
        }

        public static void CreateTest(string TestTitle)
        {
            test = getInstance().CreateTest(TestTitle);

        }

        public void LogResult(bool result)
        {
            if (result)
                test.Log(Status.Pass, "Test Passed");
            else
                test.Log(Status.Fail, "Error observed");
        }

        public static void EndReport()
        {

            getInstance().Flush();
        }
        public static void LogScreenshot(string info, string image)
        {
            test.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }

        public static void LogPass(string info)
        {
            test.Pass(info);
        }

        public static void LogFail(string info)
        {
            test.Fail(info);
        }
        public static void LogInfo(string info)
        {
            test.Info(info);
        }


    }
}
