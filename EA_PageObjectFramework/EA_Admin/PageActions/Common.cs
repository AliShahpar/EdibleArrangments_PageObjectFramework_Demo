using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Admin.PageActions
{
    class Common
    {
        //static IWebDriver driver = new ChromeDriver();
        public void SetText(IWebElement control, String value)
        {
            control.SendKeys(value);
            System.Threading.Thread.Sleep(1000);
        }

    }
}
