using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class HeaderPage
    {
        internal By header = By.XPath("//*[@class='header']");

        internal By loginIcon = By.Id("linkHeaderAccount");
        internal By loginLink = By.Id("lnkLogin");

        // loginUser div that contains UI elements
        internal By loginUserdiv = By.Id("divLoginUserPopup");
        internal By logindiv_email = By.Id("txtEmailLogin");
        internal By logindiv_password = By.Id("txtPasswordLogin");
        internal By logindiv_signInBtn = By.Id("btnSignInLogin");
        internal By logindiv_signupLink = By.XPath("//*[@id='divLoginUserPopup']//*[contains(text(), 'here')]");

    }
}
