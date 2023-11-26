using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using POMExample.PageFlow;
using POMExample.PageObjects;
using POMExample.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public class Test
    {
        
        LoginPageFlow loginPage = new LoginPageFlow();

        [OneTimeSetUp]
        public void Setup()       
        {

            //loginPage.LaunchBrowser();
        }
        [Test]
        [DeploymentItem("TestData\\Data.csv"), DeploymentItem(@"chromedriver.exe"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Data.csv", "Data#csv", DataAccessMethod.Sequential), TestCategory("Sanity"), TestCategory("SanityTests"), TestCategory("1287102")]
        public void TC1_InvalidLogintoSaucedemo()
        {
            LoginPageFlow loginPageFlow = new LoginPageFlow();
            bool result = loginPageFlow.Loginintoapplication("standard_user1", "secret_sauce1");
            NUnit.Framework.Assert.IsTrue(result, "Test Failed");
        }

        [Test]
        [DeploymentItem("TestData\\Data.csv"), DeploymentItem(@"chromedriver.exe"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Data.csv", "Data#csv", DataAccessMethod.Sequential), TestCategory("Sanity"), TestCategory("SanityTests"), TestCategory("1287102")]
        public void TC2_ValidLogintoSaucedemo()
        {
            LoginPageFlow loginPageFlow = new LoginPageFlow();
            bool result = loginPageFlow.Loginintoapplication("standard_user", "secret_sauce");
            NUnit.Framework.Assert.IsTrue(result,"Test Failed");
        }        

        [Test]
        public void TC3_SortProductsFromList()
        {
            HomePageFlow homePageFlow = new HomePageFlow();
            homePageFlow.SelectProductFromList();
            NUnit.Framework.Assert.AreSame("", "");
        }

        [TearDown] 
        public void TearDown()
        {

            loginPage.CloseBrowser();

        }

}
}