using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects
{
    class Desktop_FruitCartPage
    {
        public By firstname = By.Id("ctl00_cpBody_txtFirstName");
        public By lastname = By.Id("ctl00_cpBody_txtLastName");
        public By address = By.Id("ctl00_cpBody_txtAddress1");
        public By country = By.Id("ctl00_cpBody_ddlCountry");
        public By zip = By.Id("ctl00_cpBody_txtZip");
        public By phone = By.Id("ctl00_cpBody_txtCellPhone");
        public By email = By.Id("ctl00_cpBody_txtEmail");
        public By creditcard = By.Id("ctl00_cpBody_txtCreditCardNumber");
        public By cardexpiremonth = By.Id("ctl00_cpBody_ddlCreditCardExpiryMonth");
        public By cardexpireyear = By.Id("ctl00_cpBody_ddlCreditCardExpiryYear");
        public By cvv = By.Id("ctl00_cpBody_txtCVVNumber");
        public By coupon = By.Id("ctl00_cpBody_rptSale_ctl00_txtCoupon");
        public By applyBtn = By.Id("ctl00_cpBody_rptSale_ctl00_btnApplyCoupon");
        public By submitorder = By.XPath("//*[@id='divProcessCC']/a/img");

        public By NoThankYouPromoDiv = By.XPath("//*[@id='divPromo']//*[contains(@alt, 'No Thankyou')]");
        public By ContinueShoppingbtn = By.XPath("//*[@id='dvHead']//*[contains(@alt, 'Continue Shopping')]");

        public By CartTotalPrice = By.XPath("//*[@class='footer']//*[contains(text(), '$')]");
    }
}
