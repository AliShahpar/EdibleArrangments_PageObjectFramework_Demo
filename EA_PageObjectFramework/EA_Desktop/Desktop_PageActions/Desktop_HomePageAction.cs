using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects;
using OpenQA.Selenium;


namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageActions
{
    class Desktop_HomePageAction
    {
        public Desktop_HomePage homepage = new Desktop_HomePage();

        // this method will close the Birthday div
        public void CloseBithdayDiv(IWebDriver driver)
        {
            try
            {
                Task.Delay(2500).Wait();
                driver.FindElement(homepage.BirthdayPopClose).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // this would close the Donut PopUp on homepage
        public void CloseDonutPopUp(IWebDriver driver)
        {
            try
            {
                Task.Delay(2500).Wait();
                driver.FindElement(homepage.Donutpopup).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // this method will search the arrangement via Searchtextbox
        public void SearchArrangement(IWebDriver driver, string str_arrgID)
        {
            try
            {
                /*
                var jsDriver = (IJavaScriptExecutor)driver;
                var element = homepage.SearchTextBox; // some element you find;
                string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""10px"", ""border-style"" : ""solid"", ""border-color"" : ""blue"" });";
                jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
                */

                driver.FindElement(homepage.SearchTextBox).SendKeys(str_arrgID);
                driver.FindElement(homepage.SearchTextBox).SendKeys(Keys.Enter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // this method would search and click first arrangement on homepage
        public void HomePage_ClickFirstArrg(IWebDriver driver)
        {
          driver.FindElements(homepage.FirstArrg).First().Click();
        }

        // check if MonetateBanner exists on homepage
        public bool VerifyMonetateBanner(IWebDriver driver)
        {
            bool banner;
            try
            {
                banner = driver.FindElement(homepage.MonetateBanner).Displayed;
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
          driver.FindElement(homepage.MonetateShopForAll).Click();
        }

    }
}
