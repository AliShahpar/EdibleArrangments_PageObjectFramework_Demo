using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class CreateProfilePage
    {
        internal By emailAddress = By.Id("ctl00_cpbody_txtEmailAddress");
        internal By password = By.Id("ctl00_cpbody_txtPassword");
        internal By verifypassword = By.Id("ctl00_cpbody_txtVerifyPassword");

        internal By firstname = By.Id("ctl00_cpbody_txtFirstName");
        internal By lastname = By.Id("ctl00_cpbody_txtLastName");
        internal By zipcode = By.Id("ctl00_cpbody_txtZip");
        internal By city = By.Id("ctl00_cpbody_txtCity");
        internal By state = By.Id("ctl00_cpbody_txtState");
        internal By cellphone = By.Id("ctl00_cpbody_txtCellPhone");
        internal By birthdayMonth = By.Id("ctl00_cpbody_ddlMonth");
        internal By birthdayDay = By.Id("ctl00_cpbody_ddlDay");
        internal By birthdayYear = By.Id("ctl00_cpbody_ddlYear");
        internal By createAccountBtn = By.Id("ImageBtn");

        internal By divclick_myaccount = By.XPath("//*[@id='divThankYouCreateProfile']//*[contains(text(), 'MY ACCOUNT')]");

    }
}
