using OpenQA.Selenium;
using POMExample.Common;
using POMExample.PageObjects;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;



namespace POMExample.PageFlow
{
    public class MainPageFlow : Base
    {

        private readonly MainPage pageDetails = new MainPage();

        public void StartExecution() // Method to Launch Browser
        {
            LaunchBrowser();
        }
        private MainPageFlow HoveronServiesTab() // Method to Mouse Hoveron the Tab
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(pageDetails.ServicesTab).Perform();
            return this;

        }
        private MainPageFlow ClickonAutomationSubTab()
        {
            pageDetails.AutomationSubTab.Click();// This line is to click on AutomationSubTab
            return this;
        }

        public string CheckTextAutomationOnScreen()
        {
            try
            {
                ExtentReporting.LogInfo("HoveronServices tab");
                HoveronServiesTab();
                ClickonAutomationSubTab();
                return pageDetails.AutomationTextName.Text;
            }
            catch (NoSuchElementException ex)
            {
                return ex.Message;

            }

        }
        public bool validateServicetabIsSelected() // Method to check Services and Automation Tab is Selected by its color change.
        {
            HoveronServiesTab();
            ClickonAutomationSubTab();
            HoveronServiesTab();
            if (!pageDetails.ServicesTabColor.Equals(pageDetails.ServicesTabbackgroundColor))
            {
                if (!pageDetails.AutomationTabColor.Equals(pageDetails.AutomationTabbackgroundColor))
                {
                    return true;
                }
                else
                { return false; }
            }
            else
            {
                return false;
            }
        }

        public string EnterContactUsDetails(string firstname, string lastname, string email, string phone, string company, string message) // Submit Contact Details and get the Thank you text
        {
            try
            {
                HoveronServiesTab();
                ClickonAutomationSubTab();
                //to perform Scroll on application
                IWebElement scroll = pageDetails.ContactUsLabel;
                Actions actions = new Actions(_driver);
                actions.MoveToElement(scroll);
                actions.Perform();
                pageDetails.FirstNameTextbox.SendKeys(firstname);
                pageDetails.LastNameTextbox.SendKeys(lastname);
                pageDetails.EmailTextbox.SendKeys(email);
                pageDetails.PhoneTextbox.SendKeys(phone);
                pageDetails.CompanyTextbox.SendKeys(company);
                pageDetails.CountryDropdown.Click();
                SelectElement oSelect = new SelectElement(pageDetails.CountryDropdown);
                oSelect.SelectByIndex(2);
                pageDetails.MessageTextbox.SendKeys(message);
                pageDetails.Iagreecheckbox.Click();
                pageDetails.IamNotRobotcheckbox.Click();
                pageDetails.SubmitButton.Click();
                ExtentReporting.LogScreenshot("Ending Test", TakeScreenshot());
            }
            catch (Exception ex)
            {

                if (ex is NoSuchElementException)
                {
                    Console.WriteLine("NoSuchElementException", ex.Message);
                }
                else
                {
                    throw ex;
                }

            }

            return pageDetails.ThankyouLabel.Text;
        }
        public string CheckWorldwideCountryLinks(string countrylink)// Check all the countries link is working
        {
            try
            {
                pageDetails.WorldwideLink.Click();
                IList<IWebElement> CountryList = _driver.FindElements(By.TagName("ul"));
                

                foreach (IWebElement e in CountryList)
                {
                    string s = e.Text;
                    int c = CountryList.Count;
                    
                    pageDetails.CountryLink(countrylink).Equals(e.Text);
                    pageDetails.CountryLink(countrylink).Click();
                    break;

                }
            }
            catch (NoSuchElementException ex)
            {
                return ex.Message;

            }
            pageDetails.WorldwideLink.Click();
            return GetPageTitle();
        }

        public void CaptureScreenshot()
        {
            QuitTest();
        }

        public void StopExecution()
        {
            QuitDriver();
        }

    }
}
