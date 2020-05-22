using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using System.Drawing;

namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class SmartDivPage_ActionClass
    {
        private SmartDivPage smartdivpageObject = new SmartDivPage();


        // enter zip code 
        internal void EnterZip(IWebDriver driver, String strvalue)
        {
            try
            {
                driver.FindElement(smartdivpageObject.ZipCode).SendKeys(strvalue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // select month and date from calendar
        internal void SelectMonthDate(IWebDriver driver)
        {
            try
            {
                driver.FindElement(smartdivpageObject.Calender).Click();
                Task.Delay(1000).Wait();
                // var today = DateTime.Today;
                // var tomorrow = DateTime.Now.AddDays(1);
                // string orderdate = tomorrow.ToString("dd");
                driver.FindElement(By.LinkText("30")).Click();
                Task.Delay(1000).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // Click on GO button
        internal void ClickGObtn(IWebDriver driver)
        {
            try
            {
                driver.FindElement(smartdivpageObject.GOButton).Click();
                Task.Delay(1000).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // select pickup Div if order is pickup type
        internal void PickupOrder(IWebDriver driver)
        {
            try
            {
                driver.FindElement(smartdivpageObject.PickupDiv).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // select delivery Div if order is delivery type
        internal void DeliveryOrder(IWebDriver driver)
        {
            try
            {
                // click on the Delivery Div if it exists
                driver.FindElement(smartdivpageObject.DeliveryDiv).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Delivery Div not appeared ... " + e);
                Console.WriteLine("-----------------------------------------------------");
            }
        }


        // select delivery Div if order is delivery type
        internal void ShipmentOrder(IWebDriver driver)
        {
            // second try catch for shipment div 
            try
            {
                // click on the Shipment Div if it exists
                driver.FindElement(smartdivpageObject.ShipmentDiv).Click();
                SelectNewDeliveryDate(driver);
            }
            catch (Exception e)
            {
                Console.WriteLine("Shipment Div did not appeared ... " + e);
                Console.WriteLine("-----------------------------------------------------");
            }

        }


        // select a new delivery data if that div appeared
        internal void SelectNewDeliveryDate(IWebDriver driver)
        {
            // click on any available delivery date 
            try
            {
                driver.FindElement(smartdivpageObject.AvailableDate).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("No available date for delivery and shipment order ... " + e);
                Console.WriteLine("-----------------------------------------------------");
            }

        }


        // click on continue button
        internal void Continuebtn(IWebDriver driver)
        {
            try
            {
                driver.FindElement(smartdivpageObject.ContinueBtn).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Continue button on smart div page did not appeared ... " + e);
                Console.WriteLine("-----------------------------------------------------");
            }
        }

    }
}
