using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    class ConfirmationPage_ActionClass
    {
        internal ConfirmationPage confirmationpageObject = new ConfirmationPage();

        // this function will get the order ID value from the confirmation page
        public String GetOrderId(IWebDriver driver)
        {
            try
            {
                String orderid = "";
                orderid = driver.FindElement(confirmationpageObject.OrderID_conformationDiv).Text.ToString();
                return orderid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "Null";
        }
    }
}
