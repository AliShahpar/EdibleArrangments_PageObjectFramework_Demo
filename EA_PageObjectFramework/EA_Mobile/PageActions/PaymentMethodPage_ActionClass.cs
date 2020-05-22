using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class PaymentMethodPage_ActionClass
    {
        private PaymentMethodPage paymentpageObject = new PaymentMethodPage();

        // select payment type as credit card
        internal void SelectCardType(IWebDriver driver)
        {
            try
            {
                driver.FindElement(paymentpageObject.creditcard_div).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // enter credit card no
        internal void EnterCardno(IWebDriver driver, String strCardno)
        {
            try
            {
                driver.FindElement(paymentpageObject.creditcardNo).SendKeys(strCardno);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // Pickup & Delivery -- select expiry month
        internal void SelectMonthExpiry(IWebDriver driver)
        {
            try
            {
                SelectElement monthvar = new SelectElement(driver.FindElement(paymentpageObject.expiryMonth));
                monthvar.SelectByValue("11");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // Shipment order -- select expiry month 
        internal void SelectMonthExpiryDelta(IWebDriver driver)
        {
            try
            {
                SelectElement monthvar = new SelectElement(driver.FindElement(paymentpageObject.expiryMonth));
                monthvar.SelectByValue("4");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // Pickup & Delivery -- select expiry year
        internal void SelectYearExpiry(IWebDriver driver)
        {
            try
            {
                SelectElement year = new SelectElement(driver.FindElement(paymentpageObject.expiryYear));
                year.SelectByValue("2021");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // shipment order --  select expiry year  
        internal void SelectYearExpiryDelta(IWebDriver driver)
        {
            try
            {
                SelectElement year = new SelectElement(driver.FindElement(paymentpageObject.expiryYear));
                year.SelectByValue("2020");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // Pickup & Delivery -- enter CCV no
        internal void EnterCCno(IWebDriver driver, String strCCno)
        {
            try
            {
                driver.FindElement(paymentpageObject.cvvNo).SendKeys(strCCno);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // shipment order -- enter CCV no
        internal void EnterCCnoShipment(IWebDriver driver, String strCCno)
        {
            try
            {
                driver.FindElement(paymentpageObject.cvvNo).SendKeys(strCCno);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // enter firstname
        internal void Enterfname(IWebDriver driver, String strfname)
        {
            try
            {
                driver.FindElement(paymentpageObject.firstname).SendKeys(strfname);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // enter lastname
        internal void EnterLname(IWebDriver driver, String strlname)
        {
            try
            {
                driver.FindElement(paymentpageObject.lastname).SendKeys(strlname);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // enter address 
        internal void EnterAddress(IWebDriver driver, String straddress)
        {
            try
            {
                driver.FindElement(paymentpageObject.address).SendKeys(straddress);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // enter zipcode
        internal void EnterZipCode(IWebDriver driver, String strzip)
        {
            try
            {
                driver.FindElement(paymentpageObject.zipcode).SendKeys(strzip);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // enter phone no
        internal void EnterPhone(IWebDriver driver, String strphone)
        {
            try
            {
                driver.FindElement(paymentpageObject.phone).SendKeys(strphone);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // enter email
        internal void EnterEmail(IWebDriver driver, String stremail)
        {
            try
            {
                driver.FindElement(paymentpageObject.email).SendKeys(stremail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // click on SubmitMyOrder btn
        public void ClickbtnSubmitMyOrder(IWebDriver driver)
        {
            try
            {
                driver.FindElement(paymentpageObject.submitorderbtn).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
