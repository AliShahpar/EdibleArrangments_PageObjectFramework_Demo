using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects
{
    class Desktop_HomePage
    {
        public By BirthdayPopClose = By.XPath("//*[@id='divEmailSignUpTini_Birthday']//*[@class='emailsignup_Crosssprite']");
        public By SearchTextBox = By.Id("txtArrangementSearch");
        public By FeaturedArrg = By.ClassName("arr");
        public By FirstArrg = By.XPath("//*[@id='divArrList']//*[@class='arr']");
        public By MonetateBanner = By.Id("monetate_selectorBanner_b3f7abed_00Map");
        public By MonetateShopForAll = By.XPath("//*[@id='monetate_selectorBanner_b3f7abed_00Map']/area[4]");
        public By Donutpopup = By.XPath("//*[@id='divDonutPopup']/map/area[1]");

    }
}

