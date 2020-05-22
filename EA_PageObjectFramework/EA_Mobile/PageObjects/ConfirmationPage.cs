using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class ConfirmationPage
    {
        internal By OrderID_conformationDiv = By.XPath("//*[@class='dInfo']//*[@class='fontBold']");
        internal By OK_btn = By.XPath("//*[contains(text(), 'Ok')]");
        internal By TrackOrder_hyperlink = By.XPath("//*[contains(text(), 'Track Order')]");
        internal By EmailMyReciept_btn = By.XPath("//*[contains(text(), 'Email my receipt')]");

    }
}
