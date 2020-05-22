using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class ArrangementAddonPage
    {
        internal By ContinueButton = By.XPath("//*[contains(text(), 'CONTINUE')]");
        internal By UpgradeDiv = By.ClassName("UpBody");
        internal By AddonDiv = By.ClassName("AdBody");
        internal By UpgradeDiv_Child = By.XPath("//*[@class='UpBody']//*[@class='AddonContainer selectedaddon']//*[@class='radioList  hidequantity upgradeslist subitemlist']");
        internal By AddonDiv_Child = By.XPath("//*[@class='AdBody']//*[@class='AddonContainer selectedaddon']//*[@class='checkList addonslist subitemlist']");

    }
}
