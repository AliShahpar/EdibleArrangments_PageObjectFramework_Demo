using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class MainPage_ActionsClass
    {
        private MainPage mainpageObject = new MainPage();

        // this would search the arrangement via catalogId
        internal void SearchArrangement(IWebDriver driver, String strvalue)
        {
            driver.FindElement(mainpageObject.searchbox).SendKeys(strvalue);
            Task.Delay(2000).Wait();
            driver.FindElement(mainpageObject.searchbox).SendKeys(Keys.Enter);
        }

        // close the Donut-PopUp on the homepage
        public void CloseDonutPopUp(IWebDriver driver)
        {
            try
            {
                driver.FindElement(mainpageObject.Donutpopup).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to close the donut popup");
            }
        } 


        // Click on the close button of the customerRwardDiv
        internal void CloseRewardDiv(IWebDriver driver)
        {
            driver.FindElement(mainpageObject.closebtn_custrewardDiv).Click();
        }

        // check if MonetateBanner exists on homepage
        public bool VerifyMonetateBanner(IWebDriver driver)
        {
            bool banner;
            try
            {
                banner = driver.FindElement(mainpageObject.MonetateBanner).Displayed;
                if (banner == true)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        // this would click on MonetateBanner area 'Shop for All Products"
        public void SelectAreaMonetateBanner(IWebDriver driver)
        {
            driver.FindElement(mainpageObject.MonetateShopForAll).Click();
            Task.Delay(1500).Wait();
        }

        // this would click on a featured arrangement on the homepage
        public void ClickFeaturedArrg(IWebDriver driver)
        {
            driver.FindElement(mainpageObject.FeaturedArrg).Click();
        }

    }
}
