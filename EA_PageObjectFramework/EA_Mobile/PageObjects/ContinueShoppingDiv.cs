using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class ContinueShoppingDiv
    {
        internal By ContinueShopDiv = By.XPath("//*[@id='divPR']");
        internal By ShopForNewRecipient = By.XPath("//*[@class='btnTrans corner-all'][contains(text(), 'SHOP FOR NEW RECIPIENT')]");
        internal By CheckoutBtn = By.XPath("//*[@id='divPR']//*[contains(text(), 'CHECKOUT')]");

    }
}
