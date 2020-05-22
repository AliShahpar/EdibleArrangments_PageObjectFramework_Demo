using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    class ContinueShoppingDiv_ActionClass
    {

        private ContinueShoppingDiv ContinueShopDivObject = new ContinueShoppingDiv();

        // click on the Shop For New Recipient 
        internal void ClickShopForNewRecipient(IWebDriver driver)
        {
            driver.FindElement(ContinueShopDivObject.ShopForNewRecipient).Click();
        }

    }
}
