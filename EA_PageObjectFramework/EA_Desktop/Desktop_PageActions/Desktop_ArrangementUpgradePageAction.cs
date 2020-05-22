using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects;
using OpenQA.Selenium;


namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageActions
{
    class Desktop_ArrangementUpgradePageAction
    {
        public Desktop_ArrangementUpgradePage arrgUpgradeObject = new Desktop_ArrangementUpgradePage();


        // this would click on Continue button on Arrangement Upgrade page
        public void ClickContinueBtn(IWebDriver driver)
        {
          driver.FindElement(arrgUpgradeObject.ContinueBtn).Click();
        }

        // this would click on GoBack button on Arrangement Upgrade page  
        public void ClickGoBackBtn(IWebDriver driver)
        {
          driver.FindElement(arrgUpgradeObject.GoBackBtn).Click();
        }

    }
}
