using OpenQA.Selenium;
using POMExample.Common;



namespace POMExample.PageObjects
{
    public class MainPage : Base
    {

        public IWebElement ServicesTab //Get ServicesTab Xpath
        {
            get
            {
                string servicetabXpath = "/html/body/div[1]/header/div[2]/nav/ul/li[3]/div[1]/span";
                findElement(servicetabXpath, 3);  // to check web element at regular intervals until the object is found or timeout happens.
                IWebElement _servicestab = Base._driver.FindElement(By.XPath(servicetabXpath));
                return _servicestab;
            }
        }

        public string ServicesTabColor
        {
            get
            {
                string _servicestabcolor = Base._driver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/nav/ul/li[3]/div[1]/span")).GetCssValue("color");
                return _servicestabcolor;
            }
        }

        public string ServicesTabbackgroundColor
        {
            get
            {

                string _servicestabbackgroundcolor = Base._driver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/nav/ul/li[3]/div[1]/span")).GetCssValue("background-color");
                return _servicestabbackgroundcolor;
            }
        }


        public IWebElement AutomationSubTab
        {
            get
            {
                string automationtabXpath = "//a[contains(@class,'subMenuLink')][normalize-space()='Automation']";
                findElement(automationtabXpath, 3);
                IWebElement _automationsubtab = Base._driver.FindElement(By.XPath(automationtabXpath));
                return _automationsubtab;
            }

        }

        public string AutomationTabColor
        {
            get
            {
                string _automationtabcolor = Base._driver.FindElement(By.XPath("//a[contains(@class,'subMenuLink')][normalize-space()='Automation']")).GetCssValue("color");
                return _automationtabcolor;
            }
        }

        public string AutomationTabbackgroundColor
        {
            get
            {
                string _automationtabbackgroundcolor = Base._driver.FindElement(By.XPath("//a[contains(@class,'subMenuLink')][normalize-space()='Automation']")).GetCssValue("background-color");
                return _automationtabbackgroundcolor;
            }
        }

        public IWebElement AutomationTextName
        {
            get
            {
                string automationtextnameXpath = "//span[normalize-space()='Automation']";
                findElement(automationtextnameXpath, 3);
                IWebElement _automationLabel = Base._driver.FindElement(By.XPath(automationtextnameXpath));
                return _automationLabel;
            }

        }
        public IWebElement ContactUsLabel
        {
            get
            {
                IWebElement _contactUsLabel = Base._driver.FindElement(By.XPath("//h2[@class='Form__Title']"));
                return _contactUsLabel;
            }

        }
        public IWebElement FirstNameTextbox
        {
            get
            {
                IWebElement _firstnametxtbox = Base._driver.FindElement(By.XPath("//input[@id='4ff2ed4d-4861-4914-86eb-87dfa65876d8']"));
                return _firstnametxtbox;
            }
        }
        public IWebElement LastNameTextbox
        {
            get
            {
                IWebElement _lastnametxtbox = Base._driver.FindElement(By.XPath("//input[@id='11ce8b49-5298-491a-aebe-d0900d6f49a7']"));
                return _lastnametxtbox;
            }
        }
        public IWebElement EmailTextbox
        {
            get
            {
                IWebElement _emailtxtbox = Base._driver.FindElement(By.XPath("//input[@id='056d8435-4d06-44f3-896a-d7b0bf4d37b2']"));
                return _emailtxtbox;
            }
        }
        public IWebElement PhoneTextbox
        {
            get
            {
                IWebElement _phonetxtbox = Base._driver.FindElement(By.XPath("//input[@id='755aa064-7be2-432b-b8a2-805b5f4f9384']"));
                return _phonetxtbox;
            }
        }

        public IWebElement CompanyTextbox
        {
            get
            {
                IWebElement _companytxtbox = Base._driver.FindElement(By.XPath("//input[@id='703dedb1-a413-4e71-9785-586d609def60']"));
                return _companytxtbox;
            }
        }
        public IWebElement CountryDropdown
        {
            get
            {
                IWebElement _countryDrpbox = Base._driver.FindElement(By.XPath("//select[@id='e74d82fb-949d-40e5-8fd2-4a876319c45a']"));
                return _countryDrpbox;
            }
        }
        public IWebElement MessageTextbox
        {
            get
            {
                IWebElement _messagetxtbox = Base._driver.FindElement(By.XPath("//textarea[@id='88459d00-b812-459a-99e4-5dc6eff2aa19']"));
                return _messagetxtbox;
            }
        }
        public IWebElement Iagreecheckbox
        {
            get
            {
                IWebElement _iagreechkbox = Base._driver.FindElement(By.XPath("//label[@for='__field_1239350']"));
                return _iagreechkbox;
            }
        }

        public IWebElement IamNotRobotcheckbox
        {
            get
            {
                IWebElement _iamnotrobotchkbox = Base._driver.FindElement(By.XPath("//div[@class='recaptcha-checkbox-border' and @role='presentation']"));
                return _iamnotrobotchkbox;
            }
        }
        public IWebElement SubmitButton
        {
            get
            {
                IWebElement _submitbtn = Base._driver.FindElement(By.XPath("//button[@id='b35711ee-b569-48b4-8ec4-6476dbf61ef8']"));
                return _submitbtn;
            }

        }

        public IWebElement ThankyouLabel
        {
            get
            {
                IWebElement _thankyouLbl = Base._driver.FindElement(By.XPath("//p[normalize-space()='Thank you for contacting us.']"));
                return _thankyouLbl;
            }
        }
        public IWebElement WorldwideLink
        {
            get
            {
                IWebElement _worldwidelink = Base._driver.FindElement(By.XPath("//span[@aria-label='Worldwide']"));
                return _worldwidelink;
            }
        }
        public IWebElement CountryLink(string countryName)
        {

            return Base._driver.FindElement(By.XPath("//a[@title='" + countryName + " (new window) (new window)']"));

        }


    }
}
