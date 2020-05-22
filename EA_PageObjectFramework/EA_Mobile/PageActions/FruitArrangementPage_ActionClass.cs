using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class FruitArrangementPage_ActionClass
    {
        private FruitArrangementPage arrgpageObject = new FruitArrangementPage();

        // this will get the text from the searched arrangement result query
        internal string ArrgSearchedMsgdiv(IWebDriver driver)
        {
            try
            {
                return driver.FindElement(arrgpageObject.ArrgSearchResultMsg).Text.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "";
        }


        // this will click on the first arrangement in ArrangementList on FruitArrangements page
        internal void SelectArrgfromList(IWebDriver driver)
        {         
            driver.FindElements(arrgpageObject.FirstArrangInList).First().Click();
        }


        // this would select first arrangment from list for shipment order
        internal void SelectArrgListShipment(IWebDriver driver)
        {
            driver.FindElements(arrgpageObject.FirstArrgListShipment).First().Click();
        }

        // this will click on the OrderNow button
        internal void ClickOrderNowButton(IWebDriver driver)
        {
            driver.FindElement(arrgpageObject.OrderNowbtn).Click();
        }
    }
}
