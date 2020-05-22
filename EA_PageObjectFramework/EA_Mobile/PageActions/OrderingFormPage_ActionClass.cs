using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing;


namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class OrderingFormPage_ActionClass
    {
        private OrderingFormPage orderformpageObject = new OrderingFormPage();

        /*  given below are the methods for filling the pickup form  */
        // enter first name for pickup form
        internal void EnterFirstNamePickup(IWebDriver driver, String strfname)
        {
           driver.FindElement(orderformpageObject.firstname_pickupform).SendKeys(strfname);
        }

        // enter last name for pickup form 
        internal void EnterLastNamePickup(IWebDriver driver, String strlname)
        {
            driver.FindElement(orderformpageObject.lastname_pickupform).SendKeys(strlname);
        }

        // select first index from pickup drop down list for pickup form 
        internal void SelectPickupTime(IWebDriver driver)
        {
            SelectElement pickuptime = new SelectElement(driver.FindElement(orderformpageObject.timedropdown_pickupform));
            pickuptime.SelectByIndex(3);
        }

        // enter phone no for pickup form 
        internal void PhoneNoPickup(IWebDriver driver, String strphone)
        {
            driver.FindElement(orderformpageObject.phone_pickupform).SendKeys(strphone);
        }


        /* given below are the methods for filling the delivery form */
        // enter the firstname for delivery form
        internal void EnterFirstNameDelivery(IWebDriver driver, String strfname)
        {
            driver.FindElement(orderformpageObject.firstname_deliveryform).SendKeys(strfname);
        }

        // enter last name for delivery form 
        internal void EnterLastNameDelivery(IWebDriver driver, String strlname)
        {
            driver.FindElement(orderformpageObject.lastname_deliveryform).SendKeys(strlname);
        }

        // select first residential index for address type for delivery form 
        internal void SelectAddressTypeDelivery(IWebDriver driver)
        {
            SelectElement addresstype = new SelectElement(driver.FindElement(orderformpageObject.addresstype_deliveryform));
            addresstype.SelectByIndex(1);
        }

        // enter the street address for the delivery order 
        internal void EnterStreetAddressDelivery(IWebDriver driver, String straddress)
        {
            driver.FindElement(orderformpageObject.streetaddress_deliveryform).SendKeys(straddress);
        }

        // enter the apt-floor address for the delivery order
        internal void EnterAptfloorDelivery(IWebDriver driver, String straddress)
        {
            driver.FindElement(orderformpageObject.aptfloor_deliveryform).SendKeys(straddress);
        }

        // select the city/town from drop down list
        internal void SelectCityTownDelivery(IWebDriver driver)
        {
            SelectElement citytown = new SelectElement(driver.FindElement(orderformpageObject.citytown_deliveryform));
            citytown.SelectByIndex(1);
        }

        // enter the phone number for the delivery order 
        internal void EnterPhoneDelivery(IWebDriver driver, String strphone)
        {
            driver.FindElement(orderformpageObject.phone_deliveryform).SendKeys(strphone);
        }


        // enter pickup instruction for both pickup & delivery form
        internal void OrderGeneralInstruction(IWebDriver driver, String strinstruction)
        {
            driver.FindElement(orderformpageObject.pickupinstruction_pickupform).SendKeys(strinstruction);
        }

        // enter card message for both pickup & delivery form 
        internal void CardMessageInstruction(IWebDriver driver, String strcardmssg)
        {
            driver.FindElement(orderformpageObject.cardmessage_pickupform).SendKeys(strcardmssg);
        }


        internal void PredefinedCardMsg(IWebDriver driver)
        {
            Task.Delay(2000).Wait();
            driver.FindElement(orderformpageObject.suggested_cardmessageLink).Click();
            Task.Delay(1500).Wait();
            SelectElement cardlistindex = new SelectElement(driver.FindElement(orderformpageObject.suggested_cardmsglist));
            cardlistindex.SelectByValue("1");
            Task.Delay(1500).Wait();
            driver.FindElement(orderformpageObject.firstmsg_cardmsgcontentsDiv).Click();
            Task.Delay(1500).Wait();
        }

        // click Continue button for both pickup and delivery form 
        internal void ClickContinuebtn(IWebDriver driver)
        {
            driver.FindElement(orderformpageObject.Continuebtn_OrderingForm).Click();
        }

        // verify the delivery address via clicking on delivery div confirm address option
        internal void DeliveryShippmentDiv_verifyaddress(IWebDriver driver)
        {
            // here verify the delivery address verification 
            try
            {
                driver.FindElement(orderformpageObject.deliveryDiv_verifyaddress).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(" div for delivery address verification didnot loaded ... " + e);
                Console.WriteLine("-----------------------------------------------------");
            }

            // here verify the delivery address verification
            try
            {
                driver.FindElement(orderformpageObject.shipmentDiv_verifyaddress).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(" div for shipment address verification didnot loaded  ... " + e);
                Console.WriteLine("-----------------------------------------------------");
            }

        }

        // click on continue button on Delivery/Shipment address verification div  
        internal void DeliveryDiv_continuebtn(IWebDriver driver)
        {
            try
            {
                driver.FindElement(orderformpageObject.deliveryDiv_continubtn).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
