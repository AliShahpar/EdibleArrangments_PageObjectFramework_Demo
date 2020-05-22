using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;

namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class HeaderPage_ActionClass
    {
        private HeaderPage headerpageObject = new HeaderPage();

        // this will click on loginIcon and then on login link
        internal void ClickLoginLink(IWebDriver driver)
        {
            Task.Delay(3000).Wait();
            driver.FindElement(headerpageObject.loginIcon).Click();
            driver.FindElement(headerpageObject.loginLink).Click();
            Task.Delay(2000).Wait();
        }


        //  enter the email address on loginDiv
        internal void DivLogin_EnterEmail(IWebDriver driver, String stremail)
        {
            driver.FindElement(headerpageObject.logindiv_email).SendKeys(stremail);
        }


        // enter the password on loginDiv
        internal void DivLogin_EnterPassword(IWebDriver driver, String strpassword)
        {
            driver.FindElement(headerpageObject.logindiv_password).SendKeys(strpassword);
        }


        // click on the login button on loginDiv
        internal void DivLogin_ClickLoginbtn(IWebDriver driver)
        {
            driver.FindElement(headerpageObject.logindiv_signInBtn).Click();
        }


        // this will click on signup link ... here href
        internal void ClickSignupLink(IWebDriver driver)
        {
            driver.FindElement(headerpageObject.logindiv_signupLink).Click();
            Task.Delay(1000).Wait();
        }
    }
}
