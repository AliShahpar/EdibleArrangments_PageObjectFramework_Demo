using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class CreateProfilePage_ActionClass
    {
        private CreateProfilePage createprofilepageObject = new CreateProfilePage();

        // enter random generated email address 
        internal void EnterEmailAddress(IWebDriver driver)
        {
            String datatime = DateTime.Now.ToString("yyyyMMddHHmmss");
            String usersignupname = "TestAutomationUser" + datatime + "@test.com";
            driver.FindElement(createprofilepageObject.emailAddress).SendKeys(usersignupname);
        }

        // enter password 
        internal void EnterPassword(IWebDriver driver)
        {
            driver.FindElement(createprofilepageObject.password).SendKeys("Password@12345");
        }

        // enter password to verify it 
        internal void VerifyPassword(IWebDriver driver)
        {
            driver.FindElement(createprofilepageObject.verifypassword).SendKeys("Password@12345");
        }

        // enter firstname 
        internal void EnterFirstName(IWebDriver driver)
        {
            driver.FindElement(createprofilepageObject.firstname).SendKeys("Muhammad");
        }

        // enter lastname
        internal void EnterLastName(IWebDriver driver)
        {
            driver.FindElement(createprofilepageObject.lastname).SendKeys("Ali");
        }

        // enter zip/postal code 
        internal void EnterZipPostal(IWebDriver driver, String strzipcode)
        {
            driver.FindElement(createprofilepageObject.zipcode).SendKeys(strzipcode);
            Task.Delay(1000).Wait();
        }

        // enter City  
        internal void EnterCityName(IWebDriver driver)
        {
            driver.FindElement(createprofilepageObject.city).SendKeys("test city");
            Task.Delay(1000).Wait();
        }

        // enter state  
        internal void EnterState(IWebDriver driver)
        {
            driver.FindElement(createprofilepageObject.state).SendKeys("test state");
            Task.Delay(1000).Wait();
        }

        // enter cell phone 
        internal void EnterCellPhone(IWebDriver driver)
        {
            driver.FindElement(createprofilepageObject.cellphone).SendKeys("0123456789");
        }

        // select birthday day, month and year
        internal void SelectBirthday(IWebDriver driver)
        {
            SelectElement birthday_month = new SelectElement(driver.FindElement(createprofilepageObject.birthdayMonth));
            birthday_month.SelectByValue("2");
            Task.Delay(1500).Wait();
            SelectElement birthday_day = new SelectElement(driver.FindElement(createprofilepageObject.birthdayDay));
            birthday_day.SelectByValue("2");
            Task.Delay(1500).Wait();
            SelectElement birthday_year = new SelectElement(driver.FindElement(createprofilepageObject.birthdayYear));
            birthday_year.SelectByValue("13");
            Task.Delay(1500).Wait();
        }

        // click on CreateAccount button
        internal void ClickCreateAccbtn(IWebDriver driver)
        {
            driver.FindElement(createprofilepageObject.createAccountBtn).Click();
        }

        // this will click on MyAccount link on CreateProfile div
        internal void ClickMyAccountDiv(IWebDriver driver)
        {
            driver.FindElement(createprofilepageObject.divclick_myaccount).Click();
        }

    }
}
