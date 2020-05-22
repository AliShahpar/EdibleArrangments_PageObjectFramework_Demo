using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class OrderingFormPage
    {
        internal By firstname_pickupform = By.Id("txtPickupFirstName");
        internal By lastname_pickupform = By.Id("txtPickupLastName");
        internal By timedropdown_pickupform = By.Id("ctl00_cpbody_ddlPickupTime");
        internal By phone_pickupform = By.Id("txtPickupPhone");

        internal By firstname_deliveryform = By.Id("txtFirstName");
        internal By lastname_deliveryform = By.Id("txtLastName");
        internal By addresstype_deliveryform = By.Id("ddlAddressType");
        internal By streetaddress_deliveryform = By.Id("txtAddress1");
        internal By aptfloor_deliveryform = By.Id("txtAddress2");
        internal By citytown_deliveryform = By.Id("ctl00_cpbody_ddlCity");
        internal By phone_deliveryform = By.Id("txtCellPhone");
        internal By deliveryDiv_verifyaddress = By.XPath("//*[@id='dv_OriginalText']");
        internal By shipmentDiv_verifyaddress = By.XPath("//*[@class='divSAM']//*[@class='ContactList']//*[@id='selrow_0']");
        internal By deliveryDiv_continubtn = By.XPath("//*[@id='SuggBtn']");

        internal By pickupinstruction_pickupform = By.Id("txtInstructions");
        internal By cardmessage_pickupform = By.Id("txtCardMessage");
        internal By suggested_cardmessageLink = By.XPath("//*[@id='divCardMessage']//*[contains(text(), 'Suggested Messages')]");
        internal By suggested_cardmsglist = By.Id("ddlCardMsg");
        internal By suggested_cardmsgcontents = By.XPath("//*[@class='CardList']");
        internal By firstmsg_cardmsgcontentsDiv = By.XPath("//*[@class='CardList']//*[@message='1']");

        internal By Continuebtn_OrderingForm = By.XPath("//*[@id='divOrderingForm1']//*[contains(text(), 'Continue')]");


    }
}
