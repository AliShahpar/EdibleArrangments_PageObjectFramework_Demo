using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Admin.PageObjects
{
    class LoginPage
    {
        public By Admin_username = By.Id("txtLogin");
        public By Admin_Password = By.Id("txtPassword");
        public By Admin_LabelCode = By.Id("lblPinCode");
        public By Admin_PinCode = By.Id("txtPassPinCode");
        public By Admin_LoginButton = By.Id("btnLogin");
    }
}
