using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Admin.PageActions;
using EA_PageObjectFramework.EA_Desktop.Desktop_PageActions;


namespace EA_PageObjectFramework.TestCases.RegressionTestSuite
{
    public class RegressionClass
    {
        // first call the EA-Admin object 
        AdminLoginAction adminObject = new AdminLoginAction();
        private IWebDriver driver;

        private string URL = "https://qadesktopus.local/";
        private Desktop_HomePageAction desktop_homeObject = new Desktop_HomePageAction();
        private Desktop_FruitArrangementsPageActions desktop_fruitarrgsObject = new Desktop_FruitArrangementsPageActions();
        private Desktop_FruitArrgDetailPageAction desktop_fruitarrgdetailObject = new Desktop_FruitArrgDetailPageAction();
        private Desktop_ArrangementUpgradePageAction desktop_arrgupgradeObject = new Desktop_ArrangementUpgradePageAction();
        private Desktop_SmartDivAction desktop_smartdivObject = new Desktop_SmartDivAction();
        private Desktop_OrderFormPageAction desktop_orderformObject = new Desktop_OrderFormPageAction();
        private Desktop_FruitCartPageAction desktop_fruitcartObject = new Desktop_FruitCartPageAction();

        public void Method1()
        {
            adminObject.Arrangements();
            adminObject.ArrangementAvailabilityStore();
        }

        public void DesktopPickupMethod()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://qadesktopus.local/");
            Task.Delay(1500).Wait();
            // close the birthday div on homepage
            desktop_homeObject.CloseBithdayDiv(driver);
            // search arrangement and skip availability div
            desktop_homeObject.SearchArrangement(driver, "1047");
            Task.Delay(1000).Wait();
            desktop_fruitarrgsObject.ClickSkipAvailDiv(driver);
            Task.Delay(500).Wait();
            // select the 1047 arragenment after searching it
            desktop_fruitarrgsObject.ClickFirstArrg(driver);
            // check if the small size available against catalog# 1047
            desktop_fruitarrgdetailObject.CheckArrgSmallSize(driver);
            desktop_fruitarrgdetailObject.ClickContinueBtn(driver);
            Task.Delay(1000).Wait();
            // Provide Zip, date and select 414 test store
            desktop_smartdivObject.EnterZipCode(driver, "80123");
            Task.Delay(1000).Wait();
            desktop_smartdivObject.SelectCalenderDate(driver);
            Task.Delay(1000).Wait();
            // click on the Pickup option on Smart Div
            desktop_smartdivObject.SelectPickupOrder(driver);
            Task.Delay(500).Wait();
            desktop_smartdivObject.SelectAStore(driver);
            desktop_smartdivObject.ClickContinueBtn(driver);
            Task.Delay(1000).Wait();
            // click on continue button-- arrangement upgrade
            desktop_arrgupgradeObject.ClickContinueBtn(driver);
            Task.Delay(1000).Wait();
            desktop_orderformObject.EnterFirstName(driver, "Test");
            desktop_orderformObject.EnterLastName(driver, "User");
            desktop_orderformObject.SelectPickupTime(driver);
            desktop_orderformObject.EnterPhone(driver, "0123456789");
            desktop_orderformObject.EnterInstruction(driver, "Order placed on local QA ");
            desktop_orderformObject.EnterCardMsg(driver, "Test Card Message");
            desktop_orderformObject.ClickAddToCart(driver);
            Task.Delay(6000).Wait();
            // fill in billing page on fruit cart page
            desktop_fruitcartObject.EnterFirstName(driver, "User");
            desktop_fruitcartObject.EnterLastName(driver, "TEST");
            desktop_fruitcartObject.EnterAddress(driver, "Test Address 1");
            desktop_fruitcartObject.EnterZipCode(driver, "06514");
            desktop_fruitcartObject.EnterCellPhone(driver, "0123456789");
            desktop_fruitcartObject.EnterEmail(driver, "eaqa@broadpeak.com");
            //enter credit card information
            desktop_fruitcartObject.EnterCreditCardNo(driver, "5424180279791765");
            desktop_fruitcartObject.CardMonthYear(driver);
            desktop_fruitcartObject.EnterCardCVV(driver, "123");





        }
    }
}

