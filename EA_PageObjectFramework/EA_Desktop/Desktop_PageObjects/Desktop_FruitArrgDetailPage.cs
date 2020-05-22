using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects
{
    class Desktop_FruitArrgDetailPage
    {
        public By ArrangementSize = By.XPath("//*[@id='divSizes']//*[@class='spnSize o ']");
        public By Continuebtn = By.Id("divContinuebtn");
        public By QuantityList = By.ClassName("ddl");

        public By SmallSize = By.XPath("//*[@id='divSizes']//*[@class='spnSize o ']//*[contains(text(), 'Small')]");

    }
}
