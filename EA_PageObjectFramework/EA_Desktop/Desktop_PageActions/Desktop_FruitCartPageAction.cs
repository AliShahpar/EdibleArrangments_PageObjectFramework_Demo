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
    class Desktop_FruitCartPageAction
    {
        public Desktop_FruitCartPage fruitcartObject = new Desktop_FruitCartPage();

        // this would enter credit-card number
        public void EnterCreditCardNo(IWebDriver driver, string str_creditcard)
        {
          driver.FindElement(fruitcartObject.creditcard).SendKeys(str_creditcard);
        }

        // this would select month and year
        public void CardMonthYear(IWebDriver driver)
        {
          SelectElement month = new SelectElement(driver.FindElement(fruitcartObject.cardexpiremonth));
          month.SelectByValue("11");
          SelectElement year = new SelectElement(driver.FindElement(fruitcartObject.cardexpireyear));
          year.SelectByValue("2021");
        }

        // this would enter CVV number 
        public void EnterCardCVV(IWebDriver driver, string str_cardcvv)
        {
          driver.FindElement(fruitcartObject.cvv).SendKeys(str_cardcvv);
        }

        // this would enter Delta credit-card number
        public void EnterCreditCardNoDelta(IWebDriver driver, string str_creditcard)
        {
          driver.FindElement(fruitcartObject.creditcard).SendKeys(str_creditcard);
        }

        // this would select month and year
        public void CardMonthYearDelta(IWebDriver driver)
        {
          SelectElement month = new SelectElement(driver.FindElement(fruitcartObject.cardexpiremonth));
          month.SelectByValue("4");
          SelectElement year = new SelectElement(driver.FindElement(fruitcartObject.cardexpireyear));
          year.SelectByValue("2020");
        }

        // this would enter CVV number 
        public void EnterCardCVVDelta(IWebDriver driver, string str_cardcvv)
        {
          driver.FindElement(fruitcartObject.cvv).SendKeys(str_cardcvv);
        }

        // this would enter firstname 
        public void EnterFirstName(IWebDriver driver, string str_Fname)
        {
           driver.FindElement(fruitcartObject.firstname).SendKeys(str_Fname);
        }

        // this would enter lastname
        public void EnterLastName(IWebDriver driver, string str_Lname)
        {
          driver.FindElement(fruitcartObject.lastname).SendKeys(str_Lname);
        }

        // this would enter address 
        public void EnterAddress(IWebDriver driver, string str_address)
        {
          driver.FindElement(fruitcartObject.address).SendKeys(str_address);
        }

        // this would enter zipcode
        public void EnterZipCode(IWebDriver driver, string str_zipcode)
        {
          driver.FindElement(fruitcartObject.zip).SendKeys(str_zipcode);
        }

        // this would enter cell-phone 
        public void EnterCellPhone(IWebDriver driver, string str_cellphone)
        {
          driver.FindElement(fruitcartObject.phone).SendKeys(str_cellphone);
        }

        // this would enter email-address 
        public void EnterEmail(IWebDriver driver, string str_email)
        {
          driver.FindElement(fruitcartObject.email).SendKeys(str_email);
        }

        // this would click on SubmitMyOrder button
        public void ClickSubmitOrderBtn(IWebDriver driver)
        {
          driver.FindElement(fruitcartObject.submitorder).Click();
        }

        // this would close the PromoDiv
        public void PromoDiv_ClickNoThankYou(IWebDriver driver)
        {
            try
            {
                driver.FindElement(fruitcartObject.NoThankYouPromoDiv).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // this would click on ContinueShopping btn on the fruit-cart page
        public void ClickContinueShopping(IWebDriver driver)
        {
            driver.FindElement(fruitcartObject.ContinueShoppingbtn).Click();
        }

        // this would check if price is revelant in case of Delta Delivery and Delta Pickup order
        internal Boolean CartPriceValidate_DeltaDeliveryPickup(IWebDriver driver)
        {
            Task.Delay(1500).Wait();
            string cartprice = driver.FindElement(fruitcartObject.CartTotalPrice).Text.ToString();
            cartprice = cartprice.Replace("$", "");
            float pricedouble = float.Parse(cartprice);
            // condition to check Price Range
            if (pricedouble > 1 && pricedouble < 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // this would apply the Coupon code on the desktop site
        public void ApplyCouponFruitCart(IWebDriver driver, String strCouponCode, int strContshopIndex)
        {
            driver.FindElement(By.Id("ctl00_cpBody_rptSale_ctl0" + strContshopIndex + "_txtCoupon")).Clear();
            Task.Delay(2000).Wait();
            // enter coupon code
            driver.FindElement(By.Id("ctl00_cpBody_rptSale_ctl0" + strContshopIndex + "_txtCoupon")).SendKeys(strCouponCode);
            Task.Delay(500).Wait();
            // Send Enter key from the keyboard to apply the coupon code
            driver.FindElement(By.Id("ctl00_cpBody_rptSale_ctl0" + strContshopIndex + "_txtCoupon")).SendKeys(Keys.Enter);
            Task.Delay(2000).Wait();
        }

    }
}
