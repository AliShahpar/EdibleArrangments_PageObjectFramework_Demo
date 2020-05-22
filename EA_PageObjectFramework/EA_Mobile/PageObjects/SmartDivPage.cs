using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class SmartDivPage
    {
        internal By ZipCode = By.Id("txtArea");
        internal By Calender = By.Id("txtDate");

        internal By GOButton = By.XPath("//A[@href='javascript:void(0);'][text()='GO']/self::A");
        internal By BACKbtn = By.XPath("//A[@href='javascript:void(0);'][text()='BACK'][text()='BACK']/self::A");

        internal By PickupDiv = By.Id("dvP");
        internal By DeliveryDiv = By.Id("dvD");
        internal By ShipmentDiv = By.Id("dvS");

        internal By PickupNotAvailableDiv = By.ClassName("rdblid so");

        internal By AvailableDate = By.XPath("//*[@class='__aDS btnList']//*[@class='so']");

        internal By Pickup_SelectAnotherProduct = By.XPath("//*[@class='rdbli rbull so']//*[contains(text(), 'pickup')]");
        internal By Delivery_SelectAnotherProduct = By.XPath("//*[@class='rdbli rbull so']//*[contains(text(), 'delivery')]");
        internal By PickupDelivery_AnotherProductBanner = By.Id("product-rotator");

        internal By ContinueBtn = By.XPath("//A[@id='btnContinue']/self::A");

    }
}
