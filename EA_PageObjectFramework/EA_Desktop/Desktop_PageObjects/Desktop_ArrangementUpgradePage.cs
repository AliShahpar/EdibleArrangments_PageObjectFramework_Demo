using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects
{
    class Desktop_ArrangementUpgradePage
    {
        public By UpgradeDiv = By.ClassName("UpBody");
        public By AddOnDiv = By.ClassName("AddonsBody");
        public By Container = By.ClassName("AddonContainer");
        public By ItemSelect = By.ClassName("aitem");
        public By ContinueBtn = By.XPath("//*[@alt='Continue']");
        public By GoBackBtn = By.XPath("//*[@alt='Go Back']");

    }
}
