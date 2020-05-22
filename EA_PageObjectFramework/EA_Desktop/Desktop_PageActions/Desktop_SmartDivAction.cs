using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects;
using OpenQA.Selenium;


namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageActions
{
    public class Desktop_SmartDivAction
    {
        private Desktop_SmartDiv smartdivObject = new Desktop_SmartDiv();

        // this method enters zip-code in Zip-input field
        public void EnterZipCode(IWebDriver driver, string str_zipcode)
        {
            driver.FindElement(smartdivObject.Zipcode).SendKeys(str_zipcode);
        }

        // this method set date from calendar control
        public void SelectCalenderDate(IWebDriver driver)
        {
            try
            {
                driver.FindElement(smartdivObject.Date).Click();
                Task.Delay(1000).Wait();
                //Date Conversion Code
                DateTime dateTimeToday = DateTime.Now;
                DateTime dateTimeTommorrow = dateTimeToday.AddDays(1);
                String date = dateTimeTommorrow.ToString("dd").TrimStart(new Char[] { '0' });
                driver.FindElement(By.LinkText(date)).Click();
                Task.Delay(2000).Wait();
            }
            catch
            {
                Console.WriteLine("Failed to select next day as date in SmartDiv, so selecting current date from calender");
            }
            finally
            {
                driver.FindElement(smartdivObject.Date).Click();
                Task.Delay(1000).Wait();
                //Date Conversion Code
                DateTime dateTimeToday = DateTime.Now;
                String date = dateTimeToday.ToString("dd").TrimStart(new Char[] { '0' });
                driver.FindElement(By.LinkText(date)).Click();
            }      
        }

        // this would click on Go-button
        public void ClickGoBtn(IWebDriver driver)
        {
          driver.FindElement(smartdivObject.GoBtn).Click();
        }


        // this would click on Skip-hperlink on smart-div
        public void ClickSmartDivSkipLink(IWebDriver driver)
        {
          driver.FindElement(smartdivObject.SkipSmartDiv).Click();
        }

        // Select order type as Pickup via clicking on pickup-div
        public void SelectPickupOrder(IWebDriver driver)
        {
          driver.FindElement(smartdivObject.PickupDiv).Click();
        }

        // Select order type as Delivery via clicking on delivery-div
        public void SelectDeliveryOrder(IWebDriver driver)
        {
          driver.FindElement(smartdivObject.DeliveryDiv).Click();
        }

        // select a Store from Smart-Div
        public void SelectAStore(IWebDriver driver)
        {
           driver.FindElement(smartdivObject.StoreItem).Click();
        }

        // Click Continue button on Smart-Div
        public void ClickContinueBtn(IWebDriver driver)
        {
           driver.FindElement(smartdivObject.ContinueImgbtn).Click();
        }

        // Click GoBack button on Smart-Div
        public void ClickGoBack(IWebDriver driver)
        {
           driver.FindElement(smartdivObject.GoBackBtn).Click();
        }

        // this would close the smart-div 
        public void CloseSmartDiv(IWebDriver driver)
        {
            driver.FindElement(smartdivObject.CloseSmartDiv).Click();
        }

        // return a string array that contains addresses for all stores listed on serving store page 
        internal String[] ServingStoreList(IWebDriver driver)
        {
            IList<IWebElement> all = driver.FindElements(smartdivObject.StoreItemAddress);
            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }

            return allText;
        }

        // this would check if any test store is available 
        public int SelectAnyValidTestStore(IWebDriver driver, String[] excelStoresAddress, int excelcount)
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
        public int SelectSpecifiedTestStore(IWebDriver driver, string storeaddress)
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
    }
}
