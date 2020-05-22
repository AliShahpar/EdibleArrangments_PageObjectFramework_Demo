using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects
{
    class Desktop_SmartDiv
    {
        public By Zipcode = By.Id("txtArea");
        public By Date = By.Id("txtDate");
        public By Calender = By.Id("ui-datepicker-div");
        public By CalendarNextMonth = By.XPath("//*[@id='ui - datepicker - div']//*[@class='ui - datepicker - next ui - corner - all']");
        public By StoreList = By.ClassName("_dvStoreList btnList");
        public By StoreItem = By.XPath("//*[@class='_dvStoreList btnList']//*[@class='rdbli rbull']");
        public By StoreItemAddress = By.XPath("//*[@class='_dvStoreList btnList']//*[contains(@class, 'rdbli rbull')]//*[@class='col1']");  // xpath contains partial XPath -- contains()
        public By PickupDiv = By.Id("dvP");
        public By DeliveryDiv = By.Id("dvD");
        public By ContinueImgbtn = By.XPath("//*[@class='sprite_btncontinue']");
        public By GoBackBtn = By.XPath("//*[@id='divContinue']/a[1]/img");
        public By GoBtn = By.XPath("//*[@id='divAvl']/div[2]/a[2]/img");
        public By SmartDiv = By.XPath("//*[@id='divAvl']");
        public By CloseSmartDiv = By.XPath("//*[@id='divAvl']//*[@id='imgClose']");
        public By SkipSmartDiv = By.Id("spnSkip");
        public By PickupSevenMin = By.Id("dv7MP");
    }
}
