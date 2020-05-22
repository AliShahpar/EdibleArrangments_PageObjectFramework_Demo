using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class FruitArrangementPage
    {
        internal By FirstArrangInList = By.XPath("//*[@id='divArr']//*[@class='Arr  ']");
        internal By FirstArrgListShipment = By.XPath("//*[@id='divArr']//*[@class='Arr  ']");
        internal By ArrgSearchResultMsg = By.XPath("//*[@class='txtSR']");
        internal By OrderNowbtn = By.Id("neworderbtn");
    }
}
