using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects
{
    class Desktop_OrderFormPage
    {
        public By pickup_firstname = By.Id("txtPickupFirstName"); 
        public By pickup_lastname = By.Id("txtPickupLastName");
        public By delivery_firstname = By.Id("txtFirstName");
        public By delivery_lastname = By.Id("txtLastName");
        public By pickup_timelist = By.Id("ddlPickupTime");
        public By pickup_phone = By.Id("txtPickupPhone");
        public By delivery_addresstype = By.Id("ddlAddressType");
        public By delivery_streetaddress = By.Id("txtAddress1");
        public By delivery_homephone = By.Id("txtHomePhone");
        public By orderinstruction = By.Id("txtInstructions");
        public By pickup_occasion = By.Id("ddlOccassion");
        public By ordercardmessage = By.Id("txtCardMessage");
        public By AddToCart = By.XPath("//*[@alt='Add to Cart']");

        public By Div_SuggetedAddressConfirm = By.XPath("//*[@id='dvSuggestedAddress']//*[@id='dv_OriginalText']");
        public By DivSuggestedAddress_Submit = By.XPath("//*[@id='dvSuggestedAddress']//*[@alt='Submit']");
    }
}
