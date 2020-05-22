using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class FruitCartPage_ActionClass
    {
        private FruitCartPage fruitcartpageObject = new FruitCartPage();

        // close on Continue button on promotion div 
        internal void PromoDiv_Continuebtn(IWebDriver driver)
        {
            try
            {
                Task.Delay(4000).Wait();
                driver.FindElement(fruitcartpageObject.PromotionalDiv_Continuebtn).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // apply the Coupon code 
        internal void FruitCartApplyCouponCode(IWebDriver driver, String strCouponCode, int strContshopIndex)
        {
            driver.FindElement(By.Id("rptSale_ctl0" + strContshopIndex + "_txtCoupon")).Clear();
            Task.Delay(2000).Wait();
            // enter coupon code
            driver.FindElement(By.Id("rptSale_ctl0" + strContshopIndex + "_txtCoupon")).SendKeys(strCouponCode);
            Task.Delay(500).Wait();
            // Apply on the relevant Apply image button
            driver.FindElement(By.XPath("//*[@id=" + '"' + "rptSale_ctl0" + strContshopIndex + "_pnlCoupon" + '"' + "]" + "//*[contains(text(),'Apply')]")).Click();
            Task.Delay(2000).Wait();
        }

        // click on the Continue Shopping button
        internal void ClickContinueShopping(IWebDriver driver)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(250,0)"); // scroll the browser to the top
            Task.Delay(2000).Wait();
            driver.FindElement(fruitcartpageObject.ContinueShoppingBtn).Click();
        }

        // click CheckOut button
        internal void ClickCheckOutbtn(IWebDriver driver)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(250,0)"); // scroll the browser to the top
            Task.Delay(2000).Wait();
            driver.FindElement(fruitcartpageObject.CheckOutbtn).Click();
        }


        // select the promotional product from fruitcart page 
        internal void SelectPromotionalProduct(IWebDriver driver, string selectedvalue)
        {
            int n = driver.FindElements(By.XPath("//*[@id='divFreeProducts']//*[@class='item']")).Count();
            int var_val = Convert.ToInt32(selectedvalue);
            if (var_val == 1)
            {
                driver.FindElement(fruitcartpageObject.PromotionalDiv_ItemCheckbox).Click();
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    driver.FindElement(fruitcartpageObject.PromotionalDiv_ItemCheckbox).Click();
                }
            }
        }


        // click on the Reward Apply button
        internal void Reward_ClickApply(IWebDriver driver)
        {
            try
            {
                driver.FindElement(fruitcartpageObject.Rewards_btn).Click();
                Task.Delay(2500).Wait();
                driver.FindElement(fruitcartpageObject.RewardApply_btn).Click();
                Task.Delay(2000).Wait();
                if (driver.FindElement(fruitcartpageObject.RewardApplyFailMsg).Displayed)
                {
                    Console.WriteLine(" ---- failed to apply reward ---- ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


        // close the Reward div
        internal void CloseRewardDiv(IWebDriver driver)
        {
            try
            {
                driver.FindElement(fruitcartpageObject.RewardDiv_Closebtn).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // this would check if price is revelant in case of Delta Delivery and Delta Pickup order
        internal Boolean CartPriceValidate_DeltaDeliveryPickup(IWebDriver driver)
        {
            Task.Delay(1500).Wait();
            string cartprice = driver.FindElement(fruitcartpageObject.CartTotalPrice).Text.ToString();
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


        // this would check if the price is revelant in case for Delta Shipment order
        internal Boolean CartPriceValidate_DeltaShipment(IWebDriver driver)
        {
            Task.Delay(1500).Wait();
            string cartprice = driver.FindElement(fruitcartpageObject.CartTotalPrice).Text.ToString();
            cartprice = cartprice.Replace("$", "");
            float pricedouble = float.Parse(cartprice);

            if (pricedouble > 1 && pricedouble < 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // click the GoBack button
        internal void ClickGoBackbtn(IWebDriver driver)
        {
            try
            {
                driver.FindElement(fruitcartpageObject.GoBackBtn).Click();
            }
            catch (Exception)
            {
                //  Console.WriteLine(e);
            }
        }

    }
}
