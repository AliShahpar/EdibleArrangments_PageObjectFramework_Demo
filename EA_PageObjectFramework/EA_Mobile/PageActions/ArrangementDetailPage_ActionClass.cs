using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class ArrangementDetailPage_ActionClass
    {
        private ArrangementDetailPage arrgdetailpageObject = new ArrangementDetailPage();

        // select the smallest or lowest order arrangement size
        internal void SelectArrgSize(IWebDriver driver)
        {
            IWebElement arrgDiv = driver.FindElements(arrgdetailpageObject.dynArrgSize).Last();
            Task.Delay(1500).Wait();
            arrgDiv.Click();
        }

        // select product Quantity
        internal void SelectQuantity_DeltaOrder(IWebDriver driver)
        {
            SelectElement quantity = new SelectElement(driver.FindElement(arrgdetailpageObject.ArrgQuantity));
            quantity.SelectByValue("4");         
        }

        // click Continue button
        internal void clickContinuebtn(IWebDriver driver)
        {
            driver.FindElement(arrgdetailpageObject.Continuebtn).Click();
        }

    }
}
