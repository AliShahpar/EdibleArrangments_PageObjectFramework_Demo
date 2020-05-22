using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class PaymentMethodPage
    {
        internal By creditcard_div = By.Id("divCCOption");

        internal By creditcardNo = By.Id("txtCreditCardNumber");
        internal By expiryMonth = By.Id("ddlMonth");
        internal By expiryYear = By.Id("ddlYear");
        internal By cvvNo = By.Id("txtCVVNumber");

        internal By firstname = By.Id("txtFirstName");
        internal By lastname = By.Id("txtLastName");
        internal By address = By.Id("txtAddress1");
        internal By zipcode = By.Id("txtZip");
        internal By phone = By.Id("txtCellPhone");
        internal By email = By.Id("txtEmail");

        internal By submitorderbtn = By.XPath("//*[@id='ctl00_cpbody_divPaymentMethod']//*[contains(text(), 'SUBMIT ORDER NOW')]");

    }
}
