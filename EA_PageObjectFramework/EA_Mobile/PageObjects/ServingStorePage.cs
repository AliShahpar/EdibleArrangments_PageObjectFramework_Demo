using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class ServingStorePage
    {
        internal By DefaultStore = By.XPath("//*[@id='divSS']/div[2]/div/div/div/div[1]");
        internal By ServingStoreList = By.XPath("//*[@class='inD']//*[contains(@class, 'servingstores')]//*[contains(@class, 'address')]");
        internal By ContinueBtn = By.XPath("//*[@class='divB']//*[contains(text(), 'CONTINUE')]");

    }
}
