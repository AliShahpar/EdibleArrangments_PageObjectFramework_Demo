using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class ArrangementDetailPage
    {
        internal By ArrgSize = By.XPath("//*[@id='s']");
        internal By dynArrgSize = By.XPath("//*[@id='s']");
        internal By ArrgName = By.ClassName("arrnamewithsup");

        internal By ArrgQuantity = By.Id("ddlArrangmentQuantity");

        internal By Continuebtn = By.XPath("//*[@id='divContinuebtn']/a");
    }
}
