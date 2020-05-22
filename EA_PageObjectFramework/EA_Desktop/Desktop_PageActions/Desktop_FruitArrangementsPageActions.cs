using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects;
using OpenQA.Selenium;


namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageActions
{
    class Desktop_FruitArrangementsPageActions
    {
        public Desktop_FruitArrangementsPage fruitarrgObjects = new Desktop_FruitArrangementsPage();

        // this would click on first arrangement on the page
        public void ClickFirstArrg(IWebDriver driver)
        {
          driver.FindElement(fruitarrgObjects.FirstArrg).Click();
        }

        // this would click on New Recipient user for continue-shopping
        public void ClickShopForNewRecipient(IWebDriver driver)
        {
            driver.FindElement(fruitarrgObjects.ContinueShopNewUser).Click();
        }

        // this would click on Skip link on the Availabilty Div
        public void ClickSkipAvailDiv(IWebDriver driver)
        {
            driver.FindElement(fruitarrgObjects.DivAvailSkip).Click();
        }
    }
}
