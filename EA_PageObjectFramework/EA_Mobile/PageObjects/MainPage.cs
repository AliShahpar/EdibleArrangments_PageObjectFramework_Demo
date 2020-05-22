using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class MainPage
    {
        internal By searchbox = By.Id("txtSearch");
        internal By custrewardDiv = By.Id("divCustomerRewards");
        internal By closebtn_custrewardDiv = By.XPath("//*[@id='divCustomerRewards']//*[contains(text(), 'CLOSE')]");
        internal By MonetateBanner = By.XPath("//*[contains(@id, 'monetate_selectorBanner_')]");
        internal By MonetateShopForAll = By.XPath("//*[@class='body']//*[contains(@id, 'monetate_selectorBanner_')]/area[4]");
        internal By Donutpopup = By.XPath("//*[@class='donut - popup - container']//*[@class='close']");

        internal By FeaturedArrg = By.XPath("//*[@id='divArr']//*[@class='Arr']");
    }
}
