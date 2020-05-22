using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class ArrangementAddonPage_ActionClass
    {
        private ArrangementAddonPage arrgAddonPageObject = new ArrangementAddonPage();

        // click on the Continue button
        internal void ClickContinue(IWebDriver driver)
        {
            driver.FindElement(arrgAddonPageObject.ContinueButton).Click();
            Task.Delay(1000).Wait();
        }

        // select any upgrade item for the arrangement 
        internal void SelectAnyUpgrade(IWebDriver driver)
        {
            try
            {
                driver.FindElements(arrgAddonPageObject.UpgradeDiv).First().Click();
                driver.FindElements(arrgAddonPageObject.UpgradeDiv_Child).First().Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // select any addon for the arrangment
        internal void SelectAnyAddon(IWebDriver driver)
        {
            try
            {
                driver.FindElements(arrgAddonPageObject.AddonDiv).First().Click();
                driver.FindElements(arrgAddonPageObject.AddonDiv_Child).First().Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
