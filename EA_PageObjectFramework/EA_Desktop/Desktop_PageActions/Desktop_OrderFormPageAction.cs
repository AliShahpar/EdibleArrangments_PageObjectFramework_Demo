using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageActions
{
    class Desktop_OrderFormPageAction
    {
        private Desktop_OrderFormPage orderformObject = new Desktop_OrderFormPage();


        // Pickup -- enter first name 
        public void EnterFirstName(IWebDriver driver, string str_firstname)
        {
          driver.FindElement(orderformObject.pickup_firstname).SendKeys(str_firstname);
        }

        // Pickup -- enter last name 
        public void EnterLastName(IWebDriver driver, string str_lastname)
        {
          driver.FindElement(orderformObject.pickup_lastname).SendKeys(str_lastname);
        }

        // Delivery -- enter first name
        public void Delivery_FirstName(IWebDriver driver, string str_fname)
        {
            driver.FindElement(orderformObject.delivery_firstname).SendKeys(str_fname);  
        }

        // Delivery -- enter last name
        public void Delivery_LastName(IWebDriver driver, string str_lname)
        {
            driver.FindElement(orderformObject.delivery_lastname).SendKeys(str_lname);
        }

        // Pickup -- select PickupTime
        public void SelectPickupTime(IWebDriver driver)
        {
           SelectElement pickuptime = new SelectElement(driver.FindElement(orderformObject.pickup_timelist));
           pickuptime.SelectByIndex(3);
        }

        // Pickup -- enter phone 
        public void EnterPhone(IWebDriver driver, string str_phone)
        {
          driver.FindElement(orderformObject.pickup_phone).SendKeys(str_phone);
        }

        // Pickup -- enter instruction
        public void EnterInstruction(IWebDriver driver, string str_instruction)
        {
          driver.FindElement(orderformObject.orderinstruction).SendKeys(str_instruction);
        }

        // Pickup -- select occasion/event  
        public void SelectOccationEvent(IWebDriver driver)
        {
            // do nothing yet
        }

        // Pickup & Delivery -- enter card message 
        public void EnterCardMsg(IWebDriver driver, string str_cardmsg)
        {
          driver.FindElement(orderformObject.ordercardmessage).SendKeys(str_cardmsg);
        }

        // Delivery -- select AddressType
        public void Delivery_SelectAddressType(IWebDriver driver)
        {
          SelectElement addresstype = new SelectElement(driver.FindElement(orderformObject.delivery_addresstype));
          addresstype.SelectByIndex(1);
        }

        // Delivery -- Enter StreetAddress
        public void Deilvery_EnterStreertAddress(IWebDriver driver, string str_streetaddress)
        {
          driver.FindElement(orderformObject.delivery_streetaddress).SendKeys(str_streetaddress);
        }

        // Delivery -- Enter HomePhone
        public void Delivery_EnterHomePhone(IWebDriver driver, string str_homephone)
        {
          driver.FindElement(orderformObject.delivery_homephone).SendKeys(str_homephone);
        }

        // Pickup & Delivery -- AddToCart click
        public void ClickAddToCart(IWebDriver driver)
        {
          driver.FindElement(orderformObject.AddToCart).Click();
        }

        // this would click and confirm delivery address inside DivSuggestedDeliveryAddress 
        public void Div_ConfirmDeliveryAddress(IWebDriver driver)
        {
            driver.FindElement(orderformObject.Div_SuggetedAddressConfirm).Click();
        }

        // this would click on Submit button on DivSuggestedDeliveryAddress
        public void DivDelSuggAddress_Submitbtn(IWebDriver driver)
        {
            driver.FindElement(orderformObject.DivSuggestedAddress_Submit).Click();
        }

    }
}
