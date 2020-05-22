using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects
{
    class Desktop_FruitArrangementsPage
    {
        public By FirstArrg = By.XPath("//*[@id='divArrangementList']//*[@class='arr']");
        public By ContinueShopNewUser = By.XPath("//*[@id='divPR']//*[@class='rbull']");
        public By DivAvailSkip = By.XPath("//*[@id='divAvl']//*[@class='askip']");
    }
}
