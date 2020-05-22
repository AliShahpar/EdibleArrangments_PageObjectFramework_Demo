using EA_PageObjectFramework.EA_Mobile.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageActions
{
    public class ServingStorePage_ActionClass
    {
        private ServingStorePage servestorepageObject = new ServingStorePage();

        // click on by-default serving store page 
        internal void ClickDefaultStore(IWebDriver driver)
        {
            try
            {
                driver.FindElement(servestorepageObject.DefaultStore).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        // return a string array that contains addresses for all stores listed on serving store page 
        internal String[] ServingStoreList(IWebDriver driver)
        {
            IList<IWebElement> all = driver.FindElements(servestorepageObject.ServingStoreList);
            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }

            return allText;
        }


        // this function will select any test store available on web page, provided that store is mentioned in excel too
        internal int SelectAnyValidTestStore(IWebDriver driver, String[] excelStoresAddress, int excelcount)
        {
            String[] Pagelistedstores = ServingStoreList(driver);
            int count = Pagelistedstores.Count();
            int varteststore = 0;

            for (int m = 0; m < count; m++)
            {
                if (varteststore == 0)
                {
                    String test1 = Pagelistedstores[m];
                    test1 = test1.Trim().Replace("\r\n", " ");

                    for (int j = 0; j <= excelcount - 1; j++)
                    {
                        if (test1.Contains(excelStoresAddress[j]))
                        {
                            String varselectstore = excelStoresAddress[j];
                            driver.FindElement(By.XPath("//*[contains(text()," + '"' + varselectstore + '"' + ")]")).Click();
                            varteststore = 1;
                            break;
                        }
                    }
                }
            }

            if (varteststore == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        // this function will select the test store as specified in the excel file
        internal int SelectSpecifiedTestStore(IWebDriver driver, string storeaddress)
        {
            String[] Pagelistedstores = ServingStoreList(driver);
            int count = Pagelistedstores.Count();
            int varteststore = 0;

            for (int m = 0; m < count; m++)
            {
                if (varteststore == 0)
                {
                    string test1 = Pagelistedstores[m];
                    test1 = test1.Trim().Replace("\r\n", " ");
                    if (test1.Contains(storeaddress))
                    {
                        driver.FindElement(By.XPath("//*[contains(text()," + '"' + storeaddress + '"' + ")]")).Click();
                        varteststore = 1;
                        break;
                    }
                }
            }

            if (varteststore == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // click on continue button
        internal void ClickContinuebtn(IWebDriver driver)
        {
            try
            {
                driver.FindElement(servestorepageObject.ContinueBtn).Click();
                Task.Delay(2000).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
