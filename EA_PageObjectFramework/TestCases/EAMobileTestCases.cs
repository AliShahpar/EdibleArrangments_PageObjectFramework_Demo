using System;
using System.IO;
using System.Linq;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Desktop.Desktop_PageActions;
using EA_PageObjectFramework.ExcelTestData;
using EA_PageObjectFramework.EA_Mobile.PageActions;


namespace SeleniumTest1
{
    public class EAMobile
    {
        private IWebDriver Driver;
        private ExcelConfig ExceldataObject = new ExcelConfig();

        // Mobile -- Action objects
        #region
        private MainPage_ActionsClass mainpageactionObject = new MainPage_ActionsClass();
        private FruitArrangementPage_ActionClass fruitarrgactionObject = new FruitArrangementPage_ActionClass();
        private ArrangementDetailPage_ActionClass arrgdetailactionObject = new ArrangementDetailPage_ActionClass();
        private SmartDivPage_ActionClass smartdivactionObject = new SmartDivPage_ActionClass();
        private ServingStorePage_ActionClass servingstoreactionObject = new ServingStorePage_ActionClass();
        private ArrangementAddonPage_ActionClass arrgaddonactionObject = new ArrangementAddonPage_ActionClass();
        private OrderingFormPage_ActionClass orderformactionObject = new OrderingFormPage_ActionClass();
        private FruitCartPage_ActionClass fruitcartactionObject = new FruitCartPage_ActionClass();
        private PaymentMethodPage_ActionClass PaymentMethodactionObject = new PaymentMethodPage_ActionClass();
        private ConfirmationPage_ActionClass confirmationpageactionObject = new ConfirmationPage_ActionClass();
        private ContinueShoppingDiv_ActionClass ContinueShoppingactionObject = new ContinueShoppingDiv_ActionClass();
        private HeaderPage_ActionClass headerpageactionObject = new HeaderPage_ActionClass();
        private CreateProfilePage_ActionClass profilepageactionObject = new CreateProfilePage_ActionClass();
        #endregion

        // Desktop -- Action objects
        #region
        private Desktop_HomePageAction desktop_homeObject = new Desktop_HomePageAction();
        private Desktop_FruitArrangementsPageActions desktop_fruitarrgsObject = new Desktop_FruitArrangementsPageActions();
        private Desktop_FruitArrgDetailPageAction desktop_fruitarrgdetailObject = new Desktop_FruitArrgDetailPageAction();
        private Desktop_ArrangementUpgradePageAction desktop_arrgupgradeObject = new Desktop_ArrangementUpgradePageAction();
        private Desktop_SmartDivAction desktop_smartdivObject = new Desktop_SmartDivAction();
        private Desktop_OrderFormPageAction desktop_orderformObject = new Desktop_OrderFormPageAction();
        private Desktop_FruitCartPageAction desktop_fruitcartObject = new Desktop_FruitCartPageAction();
        #endregion

        // these variables will hold data from excel
        #region
        private string TestEnvironment;
        private string Browser;
        private string Application;
        private string Instance;
        private string SkuId;
        private string PostalZip;
        private string OrderVariant;
        private string OrderType;
        private string StoreId;
        private string CouponCode;
        private string PaymentMethod;
        private string CustomerType;
        private string OrderFlag;
        private string PersonalizeOrder;
        private string CardMessage;
        private string RewardRedemption;
        private string PromotionalProduct;
        private string ContinueShopping;
        private string MatchHistory;
        private string CustomerProfile;
        string[] excelStoresAddress = new string[9];
        private string firstname, lastname, phone, instructionpickup, cardmsgpickup, creditcardnumber, creditcardcvvno, fnamebilling,
                       lnamebilling, address1billing, zipcodebilling, phonebilling, emailbilling;
        private string firstname_delivery, lastname_delivery, staddress_delivery, aptflooraddress_delivery, phone_delivery,
                       instruction_delivery, cardmsg_delivery;
        #endregion

        //public ArrgObject arrgtestObject = new ArrgObject();
        // List<ArrgObject> ListarrgtestObject = new List<ArrgObject>();

        private StreamWriter sw;
        private string MobileURL = "";
        private string DesktopURL = "";
        private int excel_rows = 0, excel_cols = 0, excel_column_excelwrite = 1, ContinueShoppingflag = 0, ContinueShoppingindex = 1;


        internal void MainOrderingFunction()
        {
            // this will create a Text Log file which will capture Errors from browser console
            String datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            String logtextfilename = "PageConsoleErrorLogs_" + datetime;
            sw = new StreamWriter(projectPath + logtextfilename + ".txt");
            int j = 0;

            // call excel rows columns count function first 
            ExcelRowsColsCount();
            ReadTestStoresExcel();

            // all these variables will hold the "DataSet" values of the excel
            for (int i = 1; i <= excel_cols - 1; i++) // loop through the dataset // correct ->  i<=8
            {
                j = i - 1; // used value of j to remove object from list
                excel_column_excelwrite++;
                int m = 1;

                TestEnvironment = ExceldataObject.ReadSheatData(1, m, i + 1).ToString();
                Browser = ExceldataObject.ReadSheatData(1, m + 1, i + 1).ToString();
                Application = ExceldataObject.ReadSheatData(1, m + 2, i + 1).ToString();
                Instance = ExceldataObject.ReadSheatData(1, m + 3, i + 1).ToString();
                SkuId = ExceldataObject.ReadSheatData(1, m + 4, i + 1).ToString();
                PostalZip = ExceldataObject.ReadSheatData(1, m + 5, i + 1).ToString();
                OrderVariant = ExceldataObject.ReadSheatData(1, m + 6, i + 1).ToString();
                OrderType = ExceldataObject.ReadSheatData(1, m + 7, i + 1).ToString();
                StoreId = ExceldataObject.ReadSheatData(1, m + 8, i + 1).ToString();
                CouponCode = ExceldataObject.ReadSheatData(1, m + 9, i + 1).ToString();
                PaymentMethod = ExceldataObject.ReadSheatData(1, m + 10, i + 1).ToString();
                CustomerType = ExceldataObject.ReadSheatData(1, m + 11, i + 1).ToString();
                OrderFlag = ExceldataObject.ReadSheatData(1, m + 12, i + 1).ToString();
                PersonalizeOrder = ExceldataObject.ReadSheatData(1, m + 13, i + 1).ToString();
                CardMessage = ExceldataObject.ReadSheatData(1, m + 14, i + 1).ToString();
                RewardRedemption = ExceldataObject.ReadSheatData(1, m + 15, i + 1).ToString();
                PromotionalProduct = ExceldataObject.ReadSheatData(1, m + 16, i + 1).ToString();
                ContinueShopping = ExceldataObject.ReadSheatData(1, m + 17, i + 1).ToString();
                //ordertime = ExceldataObject.ReadSheatData(1, m + 17, i + 1).ToString();
                MatchHistory = ExceldataObject.ReadSheatData(1, m + 19, i + 1).ToString();
                CustomerProfile = ExceldataObject.ReadSheatData(1, m + 20, i + 1).ToString();

                // launch the browser Instance based upon excel value
                if (ContinueShoppingflag == 0) // assuming if continue shopping flag is false
                {
                    Driver = LaunchBrowserInstance(Browser);
                }
                else
                {
                    // do nothing if the flag is set as 1 
                }

                // this IF-statement handles mobile ordering scenario
                if (Application == "Mobile") // check if application is mobile 
                {
                    #region -- Start -- Mobile US site
                    if (Instance == "US" && OrderFlag == "Yes") // check if Instance is US or else
                    {
                        SetUrl();
                        Driver.Navigate().GoToUrl(MobileURL);
                        
                        // here get the HomePage console error log and write it to text file 
                        sw.WriteLine("");
                        sw.WriteLine("##########  Home Page Error log Start's  #######");
                        GetPageErrorLog();
                        sw.WriteLine("##########   END   #########");
                        sw.WriteLine("");
                        sw.Flush();  // end of writing log text file 

                        //  arrgtestObject = new ArrgObject();
                        //  ListarrgtestObject.Add(new ArrgObject());
                        //  ListarrgtestObject.Count();

                        // call the signup function here 
                        SignupAndLoginFunction(Driver, MobileURL, CustomerType);

                        if (SkuId == "Featured") // check if arrangement to be ordered is featured 
                        {
                            FeaturedArrgFunction(MobileURL, i - 1);  // call the featured arrangement selection method
                            SelectZipFunction(PostalZip, i - 1); // call the zip selection method 

                            if (OrderVariant == "Pickup")
                            {
                                PickupOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Delivery")
                            {
                                DeliveryOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Shipment")
                            {
                                ShipmentOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                        }
                        else if (SkuId != "Featured") // else check if arrangement is to searched via catalog number
                        {
                            SearchArrgCatalogFunction(Driver, SkuId, MobileURL); // search the arrangement via catalog number
                            SelectZipFunction(PostalZip, i - 1); // call the zip selection method 

                            if (OrderVariant == "Pickup")
                            {
                                PickupOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Delivery")
                            {
                                DeliveryOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Shipment")
                            {
                                ShipmentOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                        }
                    }
                    #endregion -- End -- Mobile USA site 
                    #region -- Start -- Mobile CA site 
                    else if (Instance == "CA" && OrderFlag == "Yes")
                    {
                        SetUrl();
                        Driver.Navigate().GoToUrl(MobileURL);

                        // call the signup function here 
                        SignupAndLoginFunction(Driver, MobileURL, CustomerType);

                        if (SkuId == "Featured") // check if arrangement to be ordered is featured 
                        {
                            FeaturedArrgFunction(MobileURL, i - 1);  // call the featured arrangement selection method
                            SelectZipFunction(PostalZip, i - 1); // call the zip selection method 

                            if (OrderVariant == "Pickup")
                            {
                                PickupOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Delivery")
                            {
                                DeliveryOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                        }
                        else if (SkuId != "Featured") // else check if arrangement is to searched via catalog number
                        {
                            SearchArrgCatalogFunction(Driver, SkuId, MobileURL); // search the arrangement via catalog number
                            SelectZipFunction(PostalZip, i - 1); // call the zip selection method 

                            if (OrderVariant == "Pickup")
                            {
                                PickupOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Delivery")
                            {
                                DeliveryOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                        }
                    }
                    #endregion -- End -- Mobile CA site 
                }
                // end of If-Statement which handles mobile ordering scenario

                // this IF-statement handles Desktop ordering scenario
                if (Application == "Desktop") // check if application is mobile
                {
                    #region -- Start -- Desktop US site
                    if (Instance == "US" && OrderFlag == "Yes")
                    {
                        SetUrl();
                        Driver.Navigate().GoToUrl(DesktopURL);
                        Task.Delay(1500).Wait();
                        desktop_homeObject.CloseBithdayDiv(Driver);
                        desktop_homeObject.CloseDonutPopUp(Driver);
                        // call the signup function here 
                        Desktop_SignupAndLoginFunction(Driver, DesktopURL, CustomerType);

                        if (SkuId == "Featured") // check if arrangement to be ordered is featured 
                        {
                            Desktop_FeaturedArrgFunction(DesktopURL, i - 1);  // call the featured arrangement selection method
                            Desktop_SelectZipFunction(Driver, PostalZip, i - 1); // call the zip selection method 

                            if (OrderVariant == "Pickup")
                            {
                                Desktop_PickupOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Delivery")
                            {
                                Desktop_DeliveryOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Shipment")
                            {
                                Desktop_ShipmentOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                        }
                        else if (SkuId != "Featured")
                        {
                            Desktop_SearchArrgCatalogFunction(Driver, SkuId, DesktopURL); // search the arrangement via catalog number
                            Desktop_SelectZipFunction(Driver, PostalZip, i - 1); // call the zip selection method 

                            if (OrderVariant == "Pickup")
                            {
                                Desktop_PickupOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Delivery")
                            {
                                Desktop_DeliveryOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Shipment")
                            {
                                Desktop_ShipmentOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                        }
                    }
                    #endregion -- End -- Desktop US site 
                    #region  -- Start -- Desktop CA site 
                    else if (Instance == "CA" && OrderFlag == "Yes")
                    {
                        SetUrl();
                        Driver.Navigate().GoToUrl(DesktopURL);
                        desktop_homeObject.CloseDonutPopUp(Driver);
                        // call the signup function here 
                        Desktop_SignupAndLoginFunction(Driver, DesktopURL, CustomerType);

                        if (SkuId == "Featured") // check if arrangement to be ordered is featured 
                        {
                            Desktop_FeaturedArrgFunction(DesktopURL, i - 1);  // call the featured arrangement selection method
                            Desktop_SelectZipFunction(Driver, PostalZip, i - 1); // call the zip selection method 

                            if (OrderVariant == "Pickup")
                            {
                                Desktop_PickupOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Delivery")
                            {
                                Desktop_DeliveryOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                        }
                        else if (SkuId != "Featured")
                        {
                            Desktop_SearchArrgCatalogFunction(Driver, SkuId, DesktopURL); // search the arrangement via catalog number
                            Desktop_SelectZipFunction(Driver, PostalZip, i - 1); // call the zip selection method 

                            if (OrderVariant == "Pickup")
                            {
                                Desktop_PickupOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                            else if (OrderVariant == "Delivery")
                            {
                                Desktop_DeliveryOrderFunction(Driver, ContinueShopping, excel_column_excelwrite, i - 1);
                            }
                        }
                    }
                }
                #endregion
                // end of IF-statement which handles Desktop ordering scenario

                m = 0;
                if (ContinueShoppingflag == 0)
                {
                    Driver.Quit();
                }
                else
                {
                    // do nothing and continue using same driver Instance 
                }
            }

            ExceldataObject.CloseExcel();
        }

        // this will tell count of rows and columns in excel that contains some data and are not null 
        private void ExcelRowsColsCount()
        {
            // this will tell how many rows and columns contains data in sheet1
            int excelrownullvalue = 0, excelcolnullvalue = 0;
            int k = 1;
            // this will count the number of rows in the excel 
            for (int i = 1; i <= k; i++)
            {
                if (excelrownullvalue != 1)
                {
                    for (int j = 1; j <= (excel_rows + 1); j++)
                    {
                        try
                        {
                            if (ExceldataObject.ReadSheatData(1, j, i).ToString() != null)
                            {
                                excel_rows++;
                            }
                        }
                        catch
                        {
                            // System.Console.WriteLine("Excel rows = " + excel_rows + "..... ");
                            excelrownullvalue = 1;
                        }
                    }
                }
            }
            // this will count the number of columns in the excel 
            for (int i = 1; i <= (excel_cols + 1); i++)
            {
                if (excelcolnullvalue != 1)
                {
                    for (int j = 1; j <= k; j++)
                    {
                        try
                        {
                            if (ExceldataObject.ReadSheatData(1, j, i).ToString() != null)
                            {
                                excel_cols++;
                            }
                        }
                        catch
                        {
                            // System.Console.WriteLine("Excel columns = " + excel_cols + "..... ");
                            excelcolnullvalue = 1;
                        }
                    }
                }
            }
        }

        // this will lauch the required browser 
        private IWebDriver LaunchBrowserInstance(string strbrowsername)
        {
            IWebDriver StrDriver;

            switch (strbrowsername)
            {
                case "iPhone 6":
                    ChromeOptions options1 = new ChromeOptions();
                    options1.AddArguments("--start-maximized");
                    options1.EnableMobileEmulation("iPhone 6");
                    StrDriver = new ChromeDriver(options1);
                    return StrDriver;

                case "iPhone 6 Plus":
                    ChromeOptions options2 = new ChromeOptions();
                    options2.AddArguments("--start-maximized");
                    options2.EnableMobileEmulation("iPhone 6 Plus");
                    StrDriver = new ChromeDriver(options2);
                    return StrDriver;

                case "iPad Pro":
                    ChromeOptions options3 = new ChromeOptions();
                    options3.AddArguments("--start-maximized");
                    options3.EnableMobileEmulation("iPad Pro");
                    StrDriver = new ChromeDriver(options3);
                    return StrDriver;

                case "Galaxy S5":
                    ChromeOptions options4 = new ChromeOptions();
                    options4.AddArguments("--start-maximized");
                    options4.EnableMobileEmulation("Galaxy S5");
                    StrDriver = new ChromeDriver(options4);
                    return StrDriver;

                case "FireFox":
                    //StrDriver = new FirefoxDriver();
                    StrDriver = new ChromeDriver();
                    StrDriver.Manage().Window.Maximize();
                    return StrDriver;

                case "Chrome-Node":
                    /* DesiredCapabilities capability = new DesiredCapabilities();
                    capability = DesiredCapabilities.Chrome();
                    capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    StrDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability); */

                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--start-maximized");
                    DesiredCapabilities capabilities = options.ToCapabilities() as DesiredCapabilities;
                    capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
                    StrDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
                    return StrDriver;

                case "Chrome":
                    StrDriver = new ChromeDriver();
                    StrDriver.Manage().Window.Maximize();
                    return StrDriver;

                case "Internet Explorer":
                    StrDriver = new InternetExplorerDriver();
                    StrDriver.Manage().Window.Maximize();
                    return StrDriver;

                default:
                    StrDriver = new ChromeDriver();
                    StrDriver.Manage().Window.Maximize();
                    return StrDriver;
            }
        }

        // this function will select first arrangement on featured arrangement page
        private void FeaturedArrgFunction(string strUrl, int str_i)
        {
            Driver.Navigate().GoToUrl(strUrl);
            Task.Delay(2000).Wait();
            mainpageactionObject.ClickFeaturedArrg(Driver);
            Task.Delay(4000).Wait();
            // select arrangement size 
            arrgdetailactionObject.SelectArrgSize(Driver);
            // if the order type is Delta, then select Quantity as 3
            if (OrderType == "Delta")
            {
                arrgdetailactionObject.SelectQuantity_DeltaOrder(Driver);
            }

            // here get the ArrangementDetail Page console error log and write it to text file 
            sw.WriteLine("");
            sw.WriteLine("##########  ArrangementDetail Page Console Error Log   #######");
            GetPageErrorLog();
            sw.WriteLine("##########   END   #########");
            sw.WriteLine("");
            sw.Flush();   // end of page console log 

            // here is the List of Object 
            // ListarrgtestObject[str_i].arrgname = Driver.FindElement(fruitarrgdetailpageObject.ArrgName).Text.ToString();
            // string arrgsize = Driver.FindElements(fruitarrgdetailpageObject.ArrgSize).Last().Text.ToString();
            // ListarrgtestObject[str_i].size = arrgsize + "\r\n";
            // ListarrgtestObject[str_i].price = Driver.FindElements(fruitarrgdetailpageObject.ArrgSize).Last().Text.ToString();

            // you should get all arrangement information in arrgtestObject before clicking Continue button 
            arrgdetailactionObject.clickContinuebtn(Driver);
            Task.Delay(1000).Wait();
        }

        // Desktop -- Select Feartured arrangement 
        private void Desktop_FeaturedArrgFunction(string strUrl, int str_i)
        {
            Driver.Navigate().GoToUrl(strUrl);
            Task.Delay(1500).Wait();
            // select the first arrangement available on homepage
            desktop_homeObject.HomePage_ClickFirstArrg(Driver);
            Task.Delay(2000).Wait();
            // select arrangement size
            desktop_fruitarrgdetailObject.SelectArrangementSize(Driver);
            // if order is Shipment type, then select the Quantity 
            if (OrderType == "Delta")
            {
                desktop_fruitarrgdetailObject.SelectArrQuantity_Shipment(Driver);
            }
            // you should get all arrangement information in arrgtestObject before clicking Continue button 
            desktop_fruitarrgdetailObject.ClickContinueBtn(Driver);
            Task.Delay(1000).Wait();
        }

        // this function will search arrangement via catalog number 
        private void SearchArrgCatalogFunction(IWebDriver driver, string varcatalog, string strUrl)
        {
            driver.Navigate().GoToUrl(strUrl);
            Task.Delay(1500).Wait();
            // search the arrangement via catalog 
            mainpageactionObject.SearchArrangement(driver, varcatalog);
            Task.Delay(3000).Wait();
            fruitarrgactionObject.SelectArrgfromList(driver);
            Task.Delay(1500).Wait();

            // If the order is Delta type, then select the Quantity as 3
            if (OrderType == "Delta")
            {
                arrgdetailactionObject.SelectQuantity_DeltaOrder(driver);
                arrgdetailactionObject.SelectArrgSize(driver);
            }
            else
            {
                arrgdetailactionObject.SelectArrgSize(driver);
            }
            Task.Delay(500).Wait();
            arrgdetailactionObject.clickContinuebtn(driver);
        }

        // Desktop -- Search arrangement via catalog-Id
        private void Desktop_SearchArrgCatalogFunction(IWebDriver driver, string var_catalog, string strUrl)
        {
            driver.Navigate().GoToUrl(strUrl);
            Task.Delay(1500).Wait();
            // search an arrangement via catalog number 
            desktop_homeObject.SearchArrangement(driver, var_catalog);
            Task.Delay(2500).Wait();
            desktop_fruitarrgsObject.ClickSkipAvailDiv(driver);
            Task.Delay(1000).Wait();
            desktop_fruitarrgsObject.ClickFirstArrg(driver);
            Task.Delay(1000).Wait();
            desktop_fruitarrgdetailObject.SelectArrangementSize(driver);
            desktop_fruitarrgdetailObject.SelectArrangementQuantity(driver);
            desktop_fruitarrgdetailObject.ClickContinueBtn(driver);
            Task.Delay(1000).Wait();
        }

        // this function will select a zip code which is mentioned in excel
        private void SelectZipFunction(string varPostalZip, int str_i)
        {
            // enter the zip code 
            smartdivactionObject.EnterZip(Driver, varPostalZip);
            Task.Delay(1000).Wait();
            smartdivactionObject.SelectMonthDate(Driver);
            Task.Delay(1000).Wait();

            // List of Object 
            // arrgtestObject.zip = PostalZip;
            // ListarrgtestObject[str_i].zip = PostalZip;

            // click on the GO button
            smartdivactionObject.ClickGObtn(Driver);
            Task.Delay(2000).Wait();

            // here get the HomePage console error log and write it to text file 
            sw.WriteLine("");
            sw.WriteLine("##########  Smart Div log Start's  #######");
            GetPageErrorLog();
            sw.WriteLine("##########   END   #########");
            sw.WriteLine("");
            sw.Flush(); // end of writing log file 
        }

        // Deskstop -- Select zipcode 
        private void Desktop_SelectZipFunction(IWebDriver driver, string varPostalZip, int str_i)
        {
            desktop_smartdivObject.EnterZipCode(driver, varPostalZip);
            desktop_smartdivObject.SelectCalenderDate(driver);
        }

        // this function will perform pickup order 
        private void PickupOrderFunction(IWebDriver driver, string strContinueShopping, int strExcelColumnWriteindex, int str_i)
        {
            int var_continueshopindex;
            int teststorevar;

            smartdivactionObject.PickupOrder(driver);
            Task.Delay(1000).Wait();

            // set OrderType value for arrgtestObject as pickup
            // arrgtestObject.ordertype = OrderVariant;
            // ListarrgtestObject[str_i].ordertype = OrderVariant;

            smartdivactionObject.Continuebtn(driver);
            Task.Delay(1000).Wait();
            // call the function to read all the test stores listed in excel 
            int excelcount = excelStoresAddress.Count();

            // check if the selected is a specific test store or any test store
            if (StoreId == "any")
            {
                teststorevar = servingstoreactionObject.SelectAnyValidTestStore(driver, excelStoresAddress, excelcount);
            }
            else
            {
                string str_storeaddress = ReadTestStoreIdAddress();
                teststorevar = servingstoreactionObject.SelectSpecifiedTestStore(driver, str_storeaddress);
            }

            #region -- Start IF statement -- Check if TestStore is available or not  -- 
            // place order if test store is available 
            if (teststorevar == 1)
            {
                servingstoreactionObject.ClickContinuebtn(driver);
                Task.Delay(4000).Wait();

                // here you need to handle the logic to add upgrade and addon 
                IncludeUpgradeAddonMethod(driver);
                Task.Delay(2000).Wait();

                // use excel data in variables to submit form
                orderformactionObject.EnterFirstNamePickup(driver, firstname);
                orderformactionObject.EnterLastNamePickup(driver, lastname);
                orderformactionObject.SelectPickupTime(driver);
                orderformactionObject.PhoneNoPickup(driver, phone);
                orderformactionObject.OrderGeneralInstruction(driver, instructionpickup);
                if (CardMessage == "Pre-Defined")
                {
                    orderformactionObject.PredefinedCardMsg(driver);
                }
                else
                {
                    orderformactionObject.CardMessageInstruction(driver, cardmsgpickup);
                }

                // here get the Order Form page console error log and write it to text file 
                sw.WriteLine("");
                sw.WriteLine("##########  Pickup Order - OrderForm Page Error log Start's  #######");
                GetPageErrorLog();
                sw.WriteLine("##########   END   #########");
                sw.WriteLine("");
                sw.Flush();  // end of writing log file 

                // click on the Continue button 
                orderformactionObject.ClickContinuebtn(driver);

                // set values of card message to arrgtestObject 
                // ListarrgtestObject[str_i].cardmessage = cardmsgpickup;

                Task.Delay(5000).Wait();
                // on fruit cart page, check if promotion div appears and handle it accordingly
                if (PromotionalProduct == "No")
                {
                    fruitcartactionObject.PromoDiv_Continuebtn(driver);
                    if (RewardRedemption == "Yes")
                    {
                        fruitcartactionObject.Reward_ClickApply(driver);
                    }
                    else
                    {
                        fruitcartactionObject.CloseRewardDiv(driver);
                    }
                }
                else
                {
                    fruitcartactionObject.SelectPromotionalProduct(driver, PromotionalProduct);
                    fruitcartactionObject.PromoDiv_Continuebtn(driver);
                    if (RewardRedemption == "Yes")
                    {
                        fruitcartactionObject.Reward_ClickApply(driver);
                    }
                    else
                    {
                        fruitcartactionObject.CloseRewardDiv(driver);
                    }
                }

                Task.Delay(5000).Wait();
                // Continue shopping if the value is YES else place the order
                if (strContinueShopping == "Yes")
                {
                    fruitcartactionObject.ClickContinueShopping(driver);
                    ContinueShoppingflag = 1;
                    ContinueShoppingindex++;
                    ContinueShoppingactionObject.ClickShopForNewRecipient(driver);
                }
                else
                {
                    // call the function which will Apply Coupon Code for all cases 
                    var_continueshopindex = ApplyCouponCode(ContinueShoppingindex, ContinueShoppingflag, Instance);

                    // check the price validation against the Delta order
                    if (OrderType == "Delta")
                    {
                        Boolean flagprice = fruitcartactionObject.CartPriceValidate_DeltaDeliveryPickup(driver);
                        if (flagprice == false)  // quit the driver incase Price check fails for delta order 
                        {
                            driver.Quit();
                            // write status into the Excel 
                            WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, "OrderTotal greater than 3$");
                            return;
                        }
                    }

                    ScrollUpBrowserWin(driver);
                    /*
                    call the fruit cart assertion method validate assertions 
                    FruitCartAssertionMethod(str_i);
                    */
                    fruitcartactionObject.ClickCheckOutbtn(driver);
                    Task.Delay(5000).Wait();

                    // If Instance is USA, then select card type   
                    if (Instance == "US")
                    {
                        PaymentMethodactionObject.SelectCardType(driver);
                    }

                    Task.Delay(1500).Wait();
                    // calling method EnterBillingInformation 
                    // EnterBillingInformation(Instance, OrderType, TestEnvironment, PaymentMethod);                                    

                    if (PaymentMethod == "Credit Card")
                    {
                        if (OrderType == "Delta")
                        {
                            PaymentMethodactionObject.EnterCardno(driver, "5366310668741002");
                            PaymentMethodactionObject.EnterCCno(driver, "434");
                            PaymentMethodactionObject.SelectMonthExpiryDelta(driver);
                            PaymentMethodactionObject.SelectYearExpiryDelta(driver);
                        }
                        else
                        {
                            PaymentMethodactionObject.EnterCardno(driver, creditcardnumber);
                            PaymentMethodactionObject.EnterCCno(driver, creditcardcvvno);
                            PaymentMethodactionObject.SelectMonthExpiry(driver);
                            PaymentMethodactionObject.SelectYearExpiry(driver);
                        }
                        PaymentMethodactionObject.Enterfname(driver, fnamebilling);
                        PaymentMethodactionObject.EnterLname(driver, lnamebilling);
                        PaymentMethodactionObject.EnterAddress(driver, address1billing);
                        PaymentMethodactionObject.EnterZipCode(driver, PostalZip);
                        if (CustomerType == "NewUser" || CustomerType == "Customer")
                        {
                            // do nothing as data automatically populated for phoneno and email
                        }
                        else
                        {
                            PaymentMethodactionObject.EnterPhone(driver, phonebilling);
                            PaymentMethodactionObject.EnterEmail(driver, emailbilling);
                        }

                        Task.Delay(1000).Wait();

                        // here get the PaymentMethod Page console error log and write it to text file 
                        sw.WriteLine("");
                        sw.WriteLine("##########  Pickup Order -- Payment Method Page Console Error Log   #######");
                        GetPageErrorLog();
                        sw.WriteLine("##########   END   #########");
                        sw.WriteLine("");
                        sw.Flush();  // end of console log 

                        // here click on Order now button 
                        PaymentMethodactionObject.ClickbtnSubmitMyOrder(driver);
                        Task.Delay(9000).Wait();

                        // get the order ID's after placing order
                        string[] tempStringArr_orderID = GetOrderIDConfirmationPage(var_continueshopindex);
                        string result_orderId = string.Join("|", tempStringArr_orderID);
                        // write the order ID into the Excel 
                        WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, result_orderId);
                    }

                }
            }
            #endregion -- If statement -- END -- 
            else
            {
                driver.Quit(); // quit the driver if no test store is available
            }
        }

        // Desktop -- Pickup order method
        private void Desktop_PickupOrderFunction(IWebDriver driver, string strContinueShopping, int strExcelColumnWriteindex, int str_i)
        {
            int var_continueshopindex;
            int teststorevar;
            Task.Delay(2000).Wait();
            desktop_smartdivObject.SelectPickupOrder(driver);
            Task.Delay(2000).Wait();
            // here handle the logic of checking and selecting test-store 
            int excelcount = excelStoresAddress.Count();
            // check if the selected is a specific test store or any test store
            if (StoreId == "any")
            {
                teststorevar = desktop_smartdivObject.SelectAnyValidTestStore(driver, excelStoresAddress, excelcount);
                // teststorevar = des.SelectAnyValidTestStore(driver, excelStoresAddress, excelcount);
            }
            else
            {
                string str_storeaddress = ReadTestStoreIdAddress();
                teststorevar = desktop_smartdivObject.SelectSpecifiedTestStore(driver, str_storeaddress);
            }
            // place order if test store is available 
            if (teststorevar == 1)
            {
                desktop_smartdivObject.ClickContinueBtn(driver);
                Task.Delay(3500).Wait();
                // Upgrade Arrangement page -- Click Continue button 
                desktop_arrgupgradeObject.ClickContinueBtn(driver);
                Task.Delay(2500).Wait();
                // Order form Page -- enter pickup information 
                desktop_orderformObject.EnterFirstName(driver, firstname);
                desktop_orderformObject.EnterLastName(driver, lastname);
                desktop_orderformObject.SelectPickupTime(driver);
                desktop_orderformObject.EnterPhone(driver, phone);
                desktop_orderformObject.EnterInstruction(driver, instructionpickup);
                desktop_orderformObject.EnterCardMsg(driver, cardmsgpickup);
                desktop_orderformObject.ClickAddToCart(driver);
                Task.Delay(9000).Wait();
                // FruitCart page --- enter information
                desktop_fruitcartObject.PromoDiv_ClickNoThankYou(driver);
                Task.Delay(1500).Wait();

                if (strContinueShopping == "Yes")
                {
                    desktop_fruitcartObject.ClickContinueShopping(driver);
                    Task.Delay(1500).Wait();
                    ContinueShoppingflag = 1;
                    ContinueShoppingindex++;
                    desktop_fruitarrgsObject.ClickShopForNewRecipient(driver);
                }
                else
                {
                    // call the function which will Apply Coupon Code for all cases 
                    var_continueshopindex = Desktop_ApplyCouponCode(ContinueShoppingindex, ContinueShoppingflag, Instance);

                    // check the price validation against the Delta order
                    if (OrderType == "Delta")
                    {
                        bool flagprice = desktop_fruitcartObject.CartPriceValidate_DeltaDeliveryPickup(driver);
                        if (flagprice == false)  // quit the driver incase Price check fails for delta order 
                        {
                            driver.Quit();
                            // write status into the Excel 
                            WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, "OrderTotal greater than 3$");
                            return;
                        }
                    }

                    Task.Delay(2000).Wait();
                    desktop_fruitcartObject.EnterFirstName(driver, fnamebilling);
                    desktop_fruitcartObject.EnterLastName(driver, lnamebilling);
                    desktop_fruitcartObject.EnterAddress(driver, address1billing);
                    desktop_fruitcartObject.EnterZipCode(driver, PostalZip);
                    desktop_fruitcartObject.EnterCellPhone(driver, phonebilling);
                    desktop_fruitcartObject.EnterEmail(driver, emailbilling);
                    // FruitCart page --- CreditCard Information
                    if (OrderType == "Delta")
                    {
                        desktop_fruitcartObject.EnterCreditCardNoDelta(driver, "5366310668741002");
                        desktop_fruitcartObject.CardMonthYearDelta(driver);
                        desktop_fruitcartObject.EnterCardCVVDelta(driver, "434");
                    }
                    else
                    {
                        desktop_fruitcartObject.EnterCreditCardNo(driver, "5424180279791765");
                        desktop_fruitcartObject.CardMonthYear(driver);
                        desktop_fruitcartObject.EnterCardCVV(driver, "123");
                    }
                    //click on Submit order btn 
                    desktop_fruitcartObject.ClickSubmitOrderBtn(driver);
                    Task.Delay(8000).Wait();

                    // get the order ID's after placing order
                    string[] tempStringArr_orderID = Desktop_GetOrderIDConfirmationPage(var_continueshopindex);
                    string result_orderId = string.Join("|", tempStringArr_orderID);
                    // write the order ID into the Excel 
                    WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, result_orderId);
                }
            }
            else // quit driver instance incase of no test store available
            {
                driver.Quit();
            }
        }

        // this function will perform Delivery order based upon the third paramter value of this function
        private void DeliveryOrderFunction(IWebDriver driver, string strContinueShopping, int strExcelColumnWriteindex, int str_i)
        {
            int var_continueshopindex, teststorevar;
            smartdivactionObject.DeliveryOrder(driver);
            Task.Delay(1500).Wait();
            // set OrderType value for arrgtestObject as delivery
            // arrgtestObject.OrderType = OrderVariant;
            // arrgtestObject[str_i].OrderType = OrderVariant;

            // here hanlde the addon and upgrade logic for an arrangement 
            smartdivactionObject.Continuebtn(driver);
            Task.Delay(1500).Wait();
            String currentURL = driver.Url;

            if (currentURL.Contains("ServingStore.aspx"))  // it means serving store page is diplayed 
            {
                // call the function to read all the test stores listed in excel 
                int excelcount = excelStoresAddress.Count();
                // check if the selected is a specific test store or any test store
                if (StoreId == "any")
                {
                    teststorevar = servingstoreactionObject.SelectAnyValidTestStore(driver, excelStoresAddress, excelcount);

                    // here get the Store Page console error log and write it to text file 
                    sw.WriteLine("");
                    sw.WriteLine("##########  Delivery order - Store Page Console Error Log   #######");
                    GetPageErrorLog();
                    sw.WriteLine("##########   END   #########");
                    sw.WriteLine("");
                    sw.Flush(); // end of page console log  
                }
                else
                {
                    string str_storeaddress = ReadTestStoreIdAddress();
                    teststorevar = servingstoreactionObject.SelectSpecifiedTestStore(driver, str_storeaddress);
                }

                if (teststorevar == 1) // place order if test store is available 
                {
                    servingstoreactionObject.ClickContinuebtn(driver);
                    Task.Delay(2000).Wait();
                }
                else // no test store is avaiable, so quit the driver Instance
                {
                    driver.Quit();
                    return;
                }
            }

            // here you need to handle the logic to add upgrade and addon 
            IncludeUpgradeAddonMethod(Driver);
            Task.Delay(2000).Wait();

            // fill in the delivery order form 
            orderformactionObject.EnterFirstNameDelivery(driver, firstname_delivery);
            orderformactionObject.EnterLastNameDelivery(driver, lastname_delivery);
            orderformactionObject.SelectAddressTypeDelivery(driver);
            orderformactionObject.SelectAddressTypeDelivery(driver);
            orderformactionObject.EnterStreetAddressDelivery(driver, staddress_delivery);  // enter the address for delivery order 
            orderformactionObject.EnterAptfloorDelivery(driver, staddress_delivery);
            orderformactionObject.SelectCityTownDelivery(driver);
            orderformactionObject.EnterPhoneDelivery(driver, phone_delivery);
            orderformactionObject.OrderGeneralInstruction(driver, instruction_delivery);
            if (CardMessage == "Pre-Defined")
            {
                orderformactionObject.PredefinedCardMsg(driver);
            }
            else
            {
                orderformactionObject.CardMessageInstruction(driver, cardmsg_delivery);
            }

            // here get the OrderForm Page console error log and write it to text file 
            sw.WriteLine("");
            sw.WriteLine("##########  Delivery Order Form Page Console Error Log   #######");
            GetPageErrorLog();
            sw.WriteLine("##########   END   #########");
            sw.WriteLine("");
            sw.Flush(); // end of page console log 

            orderformactionObject.ClickContinuebtn(driver);
            Task.Delay(5000).Wait();

            // close the delivery div which ask for delivery address confirmation
            orderformactionObject.DeliveryShippmentDiv_verifyaddress(driver);
            orderformactionObject.DeliveryDiv_continuebtn(driver);
            Task.Delay(3000).Wait();
            // logic to check the promotioanl product option
            if (PromotionalProduct == "No")
            {
                fruitcartactionObject.PromoDiv_Continuebtn(driver);
                if (RewardRedemption == "Yes")
                {
                    fruitcartactionObject.Reward_ClickApply(driver);
                }
                else
                {
                    fruitcartactionObject.CloseRewardDiv(driver);
                }
            }
            else
            {
                fruitcartactionObject.SelectPromotionalProduct(driver, PromotionalProduct);
                fruitcartactionObject.PromoDiv_Continuebtn(driver);
                if (RewardRedemption == "Yes")
                {
                    fruitcartactionObject.Reward_ClickApply(driver);
                }
                else
                {
                    fruitcartactionObject.CloseRewardDiv(driver);
                }
            }

            Task.Delay(1500).Wait();
            // Continue shopping if value is YES or else place an order  
            if (strContinueShopping == "Yes")
            {
                fruitcartactionObject.ClickContinueShopping(driver);
                ContinueShoppingflag = 1;
                ContinueShoppingindex++;
                ContinueShoppingactionObject.ClickShopForNewRecipient(driver);
            }
            else
            {
                // call the function which will Apply Coupon Code for all cases 
                var_continueshopindex = ApplyCouponCode(ContinueShoppingindex, ContinueShoppingflag, Instance);

                // check the price validation against the Delta order
                if (OrderType == "Delta")
                {
                    Boolean flagprice = fruitcartactionObject.CartPriceValidate_DeltaDeliveryPickup(driver);
                    if (flagprice == false)  // quit the driver incase Price check fails for delta order 
                    {
                        driver.Quit();
                        // write status into the Excel 
                        WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, "OrderTotal greater than 3$");
                        return;
                    }
                }

                ScrollUpBrowserWin(driver);
                fruitcartactionObject.ClickCheckOutbtn(driver);
                Task.Delay(4000).Wait();

                // If Instance is USA, then select card type   
                if (Instance == "US")
                {
                    PaymentMethodactionObject.SelectCardType(driver);
                }
                Task.Delay(2000).Wait();

                // enter payment information
                if (PaymentMethod == "Credit Card")
                {
                    if (OrderType == "Delta")
                    {
                        PaymentMethodactionObject.EnterCardno(driver, "5366310668741002");
                        PaymentMethodactionObject.EnterCCno(driver, "434");
                        PaymentMethodactionObject.SelectMonthExpiryDelta(driver);
                        PaymentMethodactionObject.SelectYearExpiryDelta(driver);
                    }
                    else
                    {
                        PaymentMethodactionObject.EnterCardno(driver, creditcardnumber);
                        PaymentMethodactionObject.EnterCCno(driver, creditcardcvvno);
                        PaymentMethodactionObject.SelectMonthExpiry(driver);
                        PaymentMethodactionObject.SelectYearExpiry(driver);
                    }
                    PaymentMethodactionObject.Enterfname(driver, fnamebilling);
                    PaymentMethodactionObject.EnterLname(driver, lnamebilling);
                    PaymentMethodactionObject.EnterAddress(driver, address1billing);
                    PaymentMethodactionObject.EnterZipCode(driver, PostalZip);
                    if (CustomerType == "NewUser" || CustomerType == "Customer")
                    {
                        // do nothing as data automatically populated for phoneno and email
                    }
                    else
                    {
                        PaymentMethodactionObject.EnterPhone(driver, phonebilling);
                        PaymentMethodactionObject.EnterEmail(driver, emailbilling);
                    }
                    Task.Delay(1000).Wait();
                    // here you need to click ORDER now button

                    // here get the AddOn Page console error log and write it to text file 
                    sw.WriteLine("");
                    sw.WriteLine("##########  Delivery order - PaymentMethod Page Console Error Log   #######");
                    GetPageErrorLog();
                    sw.WriteLine("##########   END   #########");
                    sw.WriteLine("");
                    sw.Flush(); // end of page console log 

                    PaymentMethodactionObject.ClickbtnSubmitMyOrder(driver);
                    Task.Delay(9000).Wait();

                    // get the order ID from confirmation page
                    string[] tempStringArr_orderID = GetOrderIDConfirmationPage(var_continueshopindex);
                    string result_orderId = string.Join("|", tempStringArr_orderID);
                    // write the order ID into the Excel 
                    WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, result_orderId);
                }
                else if (PaymentMethod == "PayPal")
                {
                    // do nothing
                }
            }
        }

        // Desktop -- Delivery order method 
        private void Desktop_DeliveryOrderFunction(IWebDriver driver, string strContinueShopping, int strExcelColumnWriteindex, int str_i)
        {
           int var_continueshopindex, var_teststore;
           Task.Delay(2000).Wait();
           desktop_smartdivObject.SelectDeliveryOrder(driver);
           Task.Delay(2000).Wait();
           // here handle the logic of checking and selecting test-store 
           int excelcount = excelStoresAddress.Count();
           // check if the selected is a specific test store or any test store
           if (StoreId == "any")
           {
              var_teststore = desktop_smartdivObject.SelectAnyValidTestStore(driver, excelStoresAddress, excelcount);
              // teststorevar = des.SelectAnyValidTestStore(driver, excelStoresAddress, excelcount);
           }
           else
           { 
              string str_storeaddress = ReadTestStoreIdAddress();
              var_teststore = desktop_smartdivObject.SelectSpecifiedTestStore(driver, str_storeaddress);
           }
            // place order if test store is available 
            if (var_teststore == 1)
            {
                desktop_smartdivObject.ClickContinueBtn(driver);
                Task.Delay(2000).Wait();
                // Upgrade Arrangement page -- Click Continue button 
                desktop_arrgupgradeObject.ClickContinueBtn(driver);
                Task.Delay(2000).Wait();
                // Order form Page -- enter pickup information 
                desktop_orderformObject.Delivery_FirstName(driver, firstname);
                desktop_orderformObject.Delivery_LastName(driver, lastname);
                desktop_orderformObject.Delivery_SelectAddressType(driver);
                desktop_orderformObject.Deilvery_EnterStreertAddress(driver, staddress_delivery);
                desktop_orderformObject.Delivery_EnterHomePhone(driver, phone_delivery);
                desktop_orderformObject.EnterInstruction(driver, instructionpickup);
                desktop_orderformObject.EnterCardMsg(driver, cardmsgpickup);
                desktop_orderformObject.ClickAddToCart(driver);
                Task.Delay(5000).Wait();
                desktop_orderformObject.Div_ConfirmDeliveryAddress(driver);
                desktop_orderformObject.DivDelSuggAddress_Submitbtn(driver);
                Task.Delay(5000).Wait();

                // FruitCart page --- enter information
                desktop_fruitcartObject.PromoDiv_ClickNoThankYou(driver);
                Task.Delay(1500).Wait();

                if (strContinueShopping == "Yes")
                {
                    desktop_fruitcartObject.ClickContinueShopping(driver);
                    Task.Delay(1500).Wait();
                    ContinueShoppingflag = 1;
                    ContinueShoppingindex++;
                    desktop_fruitarrgsObject.ClickShopForNewRecipient(driver);
                }
                else
                {
                    // call the function which will Apply Coupon Code for all cases 
                    var_continueshopindex = Desktop_ApplyCouponCode(ContinueShoppingindex, ContinueShoppingflag, Instance);

                    // check the price validation against the Delta order
                    if (OrderType == "Delta")
                    {
                        bool flagprice = desktop_fruitcartObject.CartPriceValidate_DeltaDeliveryPickup(driver);
                        if (flagprice == false)  // quit the driver incase Price check fails for delta order 
                        {
                            driver.Quit();
                            // write status into the Excel 
                            WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, "OrderTotal greater than 3$");
                            return;
                        }
                    }

                    Task.Delay(2000).Wait();
                    desktop_fruitcartObject.EnterFirstName(driver, fnamebilling);
                    desktop_fruitcartObject.EnterLastName(driver, lnamebilling);
                    desktop_fruitcartObject.EnterAddress(driver, address1billing);
                    desktop_fruitcartObject.EnterZipCode(driver, PostalZip);
                    desktop_fruitcartObject.EnterCellPhone(driver, phonebilling);
                    desktop_fruitcartObject.EnterEmail(driver, emailbilling);
                    // FruitCart page --- CreditCard Information
                    if (OrderType == "Delta")
                    {
                        desktop_fruitcartObject.EnterCreditCardNoDelta(driver, "5366310668741002");
                        desktop_fruitcartObject.CardMonthYearDelta(driver);
                        desktop_fruitcartObject.EnterCardCVVDelta(driver, "434");
                    }
                    else
                    {
                        desktop_fruitcartObject.EnterCreditCardNo(driver, "5424180279791765");
                        desktop_fruitcartObject.CardMonthYear(driver);
                        desktop_fruitcartObject.EnterCardCVV(driver, "123");
                    }
                    //click on Submit order btn 
                    desktop_fruitcartObject.ClickSubmitOrderBtn(driver);
                    Task.Delay(8000).Wait();

                    // get the order ID's after placing order
                    string[] tempStringArr_orderID = Desktop_GetOrderIDConfirmationPage(var_continueshopindex);
                    string result_orderId = string.Join("|", tempStringArr_orderID);
                    // write the order ID into the Excel 
                    WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, result_orderId);
                }
            }
            else // quit driver instance incase of no test store available
            {
                driver.Quit();
            }
        }

        // this function will perform Shipment order based upon the third paramter value of this function
        private void ShipmentOrderFunction(IWebDriver driver, string strContinueShopping, int strExcelColumnWriteindex, int str_i)
        {
            int var_continueshopindex;

            smartdivactionObject.ShipmentOrder(driver);
            Task.Delay(1500).Wait();
            // set OrderType value for arrgtestObject as shipment
            //  arrgtestObject.OrderType = OrderVariant;
            // arrgtestObject[str_i].OrderType = OrderVariant;

            smartdivactionObject.Continuebtn(driver);
            Task.Delay(1500).Wait();

            String currentURL = driver.Url;
            if (currentURL.Contains("ServingStore.aspx"))  // it means serving store page is diplayed 
            {
                // call the function to read all the test stores listed in excel 
                int excelcount = excelStoresAddress.Count();

                // pass the array string that contains all the test stores in excel
                int teststorevar = servingstoreactionObject.SelectAnyValidTestStore(driver, excelStoresAddress, excelcount);   // this will check if test store is available on serving page or not 

                if (teststorevar == 1) // place order if test store is available 
                {
                    servingstoreactionObject.ClickContinuebtn(driver);
                    Task.Delay(2000).Wait();
                }
                else // no test store is avaiable, so quit the driver Instance
                {
                    driver.Quit();
                    return;
                }
            }

            // here you need to handle the logic to add upgrade and addon 
            arrgaddonactionObject.ClickContinue(driver);

            Task.Delay(2000).Wait();
            // fill in the delivery order form 
            orderformactionObject.EnterFirstNameDelivery(driver, firstname_delivery);
            orderformactionObject.EnterLastNameDelivery(driver, lastname_delivery);
            orderformactionObject.SelectAddressTypeDelivery(driver);
            orderformactionObject.SelectAddressTypeDelivery(driver);

            // here enter address if its shipment 
            orderformactionObject.EnterStreetAddressDelivery(driver, "PO Box 700501");

            orderformactionObject.SelectCityTownDelivery(driver);
            orderformactionObject.EnterPhoneDelivery(driver, phone_delivery);
            if (CardMessage == "Pre-Defined")
            {
                orderformactionObject.PredefinedCardMsg(driver);
            }
            else
            {
                orderformactionObject.CardMessageInstruction(driver, cardmsg_delivery);
            }

            orderformactionObject.ClickContinuebtn(driver);
            Task.Delay(3000).Wait();

            // verify the shipment address on the appeared Div
            orderformactionObject.DeliveryShippmentDiv_verifyaddress(driver);
            orderformactionObject.DeliveryDiv_continuebtn(driver);
            Task.Delay(5000).Wait();

            // logic to check the promotioanl product option
            if (PromotionalProduct == "No")
            {
                fruitcartactionObject.PromoDiv_Continuebtn(driver);
                if (RewardRedemption == "Yes")
                {
                    fruitcartactionObject.Reward_ClickApply(driver);
                }
                else
                {
                    fruitcartactionObject.CloseRewardDiv(driver);
                }
            }
            else
            {
                fruitcartactionObject.SelectPromotionalProduct(driver, PromotionalProduct);
                fruitcartactionObject.PromoDiv_Continuebtn(driver);
                if (RewardRedemption == "Yes")
                {
                    fruitcartactionObject.Reward_ClickApply(driver);
                }
                else
                {
                    fruitcartactionObject.CloseRewardDiv(driver);
                }
            }


            fruitcartactionObject.PromoDiv_Continuebtn(driver);
            Task.Delay(5000).Wait();
            // Continue shopping if value is YES or else place an order  
            if (strContinueShopping == "Yes")
            {
                fruitcartactionObject.ClickContinueShopping(driver);
                ContinueShoppingflag = 1;
                ContinueShoppingindex++;
                ContinueShoppingactionObject.ClickShopForNewRecipient(driver);
            }
            else
            {
                // call the function which will Apply Coupon Code for all cases 
                var_continueshopindex = ApplyCouponCode(ContinueShoppingindex, ContinueShoppingflag, Instance);

                // check the price validation against the Delta order
                if (OrderType == "Delta")
                {
                    Boolean flagprice = fruitcartactionObject.CartPriceValidate_DeltaShipment(driver);
                    if (flagprice == false)  // quit the driver incase Price check fails for delta order 
                    {
                        driver.Quit();
                        // write status into the Excel 
                        WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, "OrderTotal greater than 3$");
                        return;
                    }
                }

                // scroll up the window and click on CHECKOUT button 
                ScrollUpBrowserWin(driver);
                fruitcartactionObject.ClickCheckOutbtn(driver);
                Task.Delay(4000).Wait();

                // If Instance is USA, then select card type   
                if (Instance == "US")
                {
                    PaymentMethodactionObject.SelectCardType(driver);
                }
                Task.Delay(2000).Wait();

                // enter payment information
                if (PaymentMethod == "Credit Card")
                {
                    if (OrderType == "Delta")
                    {
                        PaymentMethodactionObject.EnterCardno(driver, "5366310668741002");
                        PaymentMethodactionObject.EnterCCno(driver, "434");
                        PaymentMethodactionObject.SelectMonthExpiryDelta(driver);
                        PaymentMethodactionObject.SelectYearExpiryDelta(driver);
                    }
                    else
                    {
                        PaymentMethodactionObject.EnterCardno(driver, creditcardnumber);
                        PaymentMethodactionObject.EnterCCno(driver, creditcardcvvno);
                        PaymentMethodactionObject.SelectMonthExpiry(driver);
                        PaymentMethodactionObject.SelectYearExpiry(driver);
                    }
                    PaymentMethodactionObject.Enterfname(driver, fnamebilling);
                    PaymentMethodactionObject.EnterLname(driver, lnamebilling);
                    PaymentMethodactionObject.EnterAddress(driver, address1billing);
                    PaymentMethodactionObject.EnterZipCode(driver, PostalZip);
                    if (CustomerType == "NewUser" || CustomerType == "Customer")
                    {
                        // do nothing as data automatically populated for phoneno and email
                    }
                    else
                    {
                        PaymentMethodactionObject.EnterPhone(driver, phonebilling);
                        PaymentMethodactionObject.EnterEmail(driver, emailbilling);
                    }
                    Task.Delay(1000).Wait();
                    // here you need to click ORDER now button
                    PaymentMethodactionObject.ClickbtnSubmitMyOrder(driver);
                    Task.Delay(9000).Wait();

                    // get the order ID from confirmation page
                    string[] tempStringArr_orderID = GetOrderIDConfirmationPage(var_continueshopindex);
                    string result_orderId = string.Join("|", tempStringArr_orderID);
                    // write the order ID into the Excel 
                    WriteOrderIdIntoExcel(excel_rows, strExcelColumnWriteindex, result_orderId);
                }
                else if (PaymentMethod == "PayPal")
                {
                    // do nothing
                }

            }
        }

        // this function will apply coupon code before clicking on CHECKOUT BUTTON on fruit cart page for all cases
        private int ApplyCouponCode(int strContinueShoppingIndex, int strContinueShoppingFlag, String strCountry)
        {
            if (strContinueShoppingFlag == 0)
            {
                if (strCountry == "US" && CouponCode != "None")
                {
                    fruitcartactionObject.FruitCartApplyCouponCode(Driver, "Save2825", 1);
                }
                if (strCountry == "CA" && CouponCode != "None")
                {
                    fruitcartactionObject.FruitCartApplyCouponCode(Driver, "Save2823", 1);
                }
                return 0; // return zero integer value if its a single order
            }
            #region -- mobile site -- ContinueShopping scenario 
            // handle the logic for continue shopping workflow
            if (strContinueShoppingFlag == 1)
            {
                for (int i = 1; i <= ContinueShoppingindex; i++)
                {
                    ScrollUpBrowserWin(Driver);
                    Task.Delay(5000).Wait();
                    Driver.FindElement(By.XPath("//*[@class='recipientContent'][@rindex=" + i + "]//*[contains(text(), 'View Details')]")).Click();
                    Task.Delay(1500).Wait();
                    if (strCountry == "US" && CouponCode != "None")
                    {
                        fruitcartactionObject.FruitCartApplyCouponCode(Driver, "Save2825", i);
                    }
                    if (strCountry == "CA" && CouponCode != "None")
                    {
                        fruitcartactionObject.FruitCartApplyCouponCode(Driver, "Save2823", i);
                    }
                    Task.Delay(1500).Wait();
                    ScrollUpBrowserWin(Driver);
                    fruitcartactionObject.ClickGoBackbtn(Driver);
                    Task.Delay(3000).Wait();
                }
                // reset the values for ContinueShoppingflag and ContinueShoppingindex
                ContinueShoppingflag = 0;
                int var_temp = ContinueShoppingindex; // put continue shopping index as integer value in a temp variable 
                ContinueShoppingindex = 1;
                return var_temp; // return the temp variable which indicates continue shopping index 
            }
            #endregion

            return 0; // return 0 as default value 
        }

        // this function will apply coupon code as well handles continue-shopping scenario
        private int Desktop_ApplyCouponCode(int strContinueShoppingIndex, int strContinueShoppingFlag, String strCountry)
        {
            if (strContinueShoppingFlag == 0)
            {
                if (strCountry == "US" && CouponCode != "None")
                {
                    desktop_fruitcartObject.ApplyCouponFruitCart(Driver, "Save2825", 0);
                }
                if (strCountry == "CA" && CouponCode != "None")
                {

                }
                return 0; // return zero integer value if its a single order
            }
            #region -- desktop site -- ContinueShopping scenario 
            // handle the logic for continue shopping workflow
            if (strContinueShoppingFlag == 1)
            {
                for (int i = 0; i <= ContinueShoppingindex; i++)
                {
                    ScrollUpBrowserWin(Driver);
                    Task.Delay(5000).Wait();
                    Driver.FindElement(By.XPath("//*[@class='recipientContent'][@rindex=" + i + "]//*[contains(@onclick, 'ShowOrderDetails')]")).Click();
                    Task.Delay(1500).Wait();
                    if (strCountry == "US" && CouponCode != "None")
                    {
                        desktop_fruitcartObject.ApplyCouponFruitCart(Driver, "Save2825", i);
                    }
                    if (strCountry == "CA" && CouponCode != "None")
                    {

                    }
                    Task.Delay(1500).Wait();
                    // do the rest of things here below 


                }
                // reset the values for ContinueShoppingflag and ContinueShoppingindex
                ContinueShoppingflag = 0;
                int var_temp = ContinueShoppingindex; // put continue shopping index as integer value in a temp variable 
                ContinueShoppingindex = 1;
                return var_temp; // return the temp variable which indicates continue shopping index 
            }
            #endregion

            return 0;
        }

        // get the order Id from the confirmation page for both ContinueShopping and non-ContinueShopping
        private string[] GetOrderIDConfirmationPage(int str_continueshopindex)
        {
            string[] orderIdSingle = new string[1];
            Task.Delay(2000).Wait();
            string currentURL = Driver.Url;
            // if order is placed, then put the order Id in the excel
            if (currentURL.Contains("Confirmation.aspx"))
            {
                if (str_continueshopindex == 0)
                {
                    orderIdSingle[0] = confirmationpageactionObject.GetOrderId(Driver).ToString();
                    return orderIdSingle;
                }
                else
                {
                    string[] orderIdMultiple = new string[str_continueshopindex];
                    for (int i = 1; i <= str_continueshopindex; i++)
                    {
                        int j = i + 1;
                        orderIdMultiple[i - 1] = Driver.FindElement(By.XPath("//*[@id='dvMain']/table[" + j + "]//*[@class='dInfo']//*[@class='fontBold']")).Text.ToString();
                    }
                    return orderIdMultiple;
                }
            }

            return orderIdSingle; // just return empty string if whole logic of this function fails 
        }

        // get the order Id from the confirmation page for both ContinueShopping and non-ContinueShopping
        private string[] Desktop_GetOrderIDConfirmationPage(int str_continueshopindex)
        {
            string[] orderIdSingle = new String[1];
            Task.Delay(3000).Wait();
            string currentURL = Driver.Url;
            // if order is placed, then put the order Id in the excel
            if (currentURL.Contains("Confirmation.aspx"))
            {
                // here get the Confirmation Page console error log and write it to text file 
                sw.WriteLine("");
                sw.WriteLine("##########  Confirmation Page Console Error Log   #######");
                GetPageErrorLog();
                sw.WriteLine("##########   END   #########");
                sw.WriteLine("");
                sw.Flush();   // end of page console log 

                if (str_continueshopindex == 0)
                {
                    orderIdSingle[0] = confirmationpageactionObject.GetOrderId(Driver).ToString();
                    return orderIdSingle;
                }
                else
                {
                    string[] orderIdMultiple = new string[str_continueshopindex];
                    for (int i = 1; i <= str_continueshopindex; i++)
                    {
                        int j = i + 1;
                        orderIdMultiple[i - 1] = Driver.FindElement(By.XPath("//*[@id='dvMain']/table[" + j + "]//*[@class='dInfo']//*[@class='fontBold']")).Text.ToString();
                    }
                    return orderIdMultiple;
                }
            }

            return orderIdSingle; // just return empty string if whole logic of this function fails 
        }

        // this function will write the order Id's into the excel file 
        private void WriteOrderIdIntoExcel(int strRow, int strCol, String strOrderID)
        {
            // write the order ID into the Excel file 
            ExceldataObject.WriteSheetData(1, strRow, strCol, strOrderID);
        }

        // this function will make the browser to scroll up
        private void ScrollUpBrowserWin(IWebDriver driver)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(250, 0)"); // if the element is on top.
        }

        // this function will make the browser to scroll down
        private void ScrollDownBrowserWin(IWebDriver driver)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(0, 250)"); // if the element is on bottom.
        }

        // read all the test stores mentioned in the excel sheet
        private void ReadTestStoresExcel()
        {
            int excelcount = excelStoresAddress.Count();
            excelStoresAddress[0] = ExceldataObject.ReadSheatData(3, 2, 2).ToString();
            excelStoresAddress[1] = ExceldataObject.ReadSheatData(3, 3, 2).ToString();
            excelStoresAddress[2] = ExceldataObject.ReadSheatData(3, 4, 2).ToString();
            excelStoresAddress[3] = ExceldataObject.ReadSheatData(3, 5, 2).ToString();
            excelStoresAddress[4] = ExceldataObject.ReadSheatData(3, 6, 2).ToString();
            excelStoresAddress[5] = ExceldataObject.ReadSheatData(3, 7, 2).ToString();
            excelStoresAddress[6] = ExceldataObject.ReadSheatData(3, 8, 2).ToString();
            excelStoresAddress[7] = ExceldataObject.ReadSheatData(3, 9, 2).ToString();

            if (TestEnvironment == "QA" || TestEnvironment == "Prod")
            {
                excelStoresAddress[8] = ExceldataObject.ReadSheatData(3, 10, 2).ToString();
            }
            else
            {
                // get old data -- needs to handled 
                excelStoresAddress[8] = ExceldataObject.ReadSheatData(3, 9, 2).ToString();
            }

            firstname = ExceldataObject.ReadSheatData(2, 2, 2).ToString();
            lastname = ExceldataObject.ReadSheatData(2, 3, 2).ToString();
            phone = ExceldataObject.ReadSheatData(2, 4, 2).ToString();
            instructionpickup = ExceldataObject.ReadSheatData(2, 5, 2).ToString();
            cardmsgpickup = ExceldataObject.ReadSheatData(2, 6, 2).ToString();
            creditcardnumber = ExceldataObject.ReadSheatData(2, 7, 2).ToString();
            creditcardcvvno = ExceldataObject.ReadSheatData(2, 8, 2).ToString();
            fnamebilling = ExceldataObject.ReadSheatData(2, 9, 2).ToString();
            lnamebilling = ExceldataObject.ReadSheatData(2, 10, 2).ToString();
            address1billing = ExceldataObject.ReadSheatData(2, 11, 2).ToString();
            zipcodebilling = PostalZip;
            phonebilling = ExceldataObject.ReadSheatData(2, 13, 2).ToString();
            emailbilling = ExceldataObject.ReadSheatData(2, 14, 2).ToString();

            firstname_delivery = ExceldataObject.ReadSheatData(2, 2, 2).ToString();
            lastname_delivery = ExceldataObject.ReadSheatData(2, 3, 2).ToString();
            staddress_delivery = ExceldataObject.ReadSheatData(2, 11, 2).ToString();
            aptflooraddress_delivery = ExceldataObject.ReadSheatData(2, 11, 2).ToString();
            phone_delivery = ExceldataObject.ReadSheatData(2, 4, 2).ToString();
            instruction_delivery = ExceldataObject.ReadSheatData(2, 5, 2).ToString();
            cardmsg_delivery = ExceldataObject.ReadSheatData(2, 6, 2).ToString();
            creditcardnumber = ExceldataObject.ReadSheatData(2, 7, 2).ToString();
            creditcardcvvno = ExceldataObject.ReadSheatData(2, 8, 2).ToString();
            fnamebilling = ExceldataObject.ReadSheatData(2, 9, 2).ToString();
            lnamebilling = ExceldataObject.ReadSheatData(2, 10, 2).ToString();
            address1billing = ExceldataObject.ReadSheatData(2, 11, 2).ToString();
            zipcodebilling = PostalZip;
            phonebilling = ExceldataObject.ReadSheatData(2, 13, 2).ToString();
            emailbilling = ExceldataObject.ReadSheatData(2, 14, 2).ToString();
        }

        // this function will make a user signup and login
        private void SignupAndLoginFunction(IWebDriver driver, String strUrl, String strCustomerType)
        {
            if (strCustomerType == "NewUser")
            {
                Task.Delay(2000).Wait();
                // create a new user with timestamp append to its name 
                String datatime = DateTime.Now.ToString("yyyyMMddHHmmss");
                String usersignupname = "JohnTest" + datatime + "@gmail.com";
                // navigate the browser
                driver.Navigate().GoToUrl(strUrl);
                Task.Delay(2000).Wait();
                headerpageactionObject.ClickLoginLink(driver);
                headerpageactionObject.ClickSignupLink(driver);

                // here a user profile will be created on signup page
                profilepageactionObject.EnterEmailAddress(driver);
                Task.Delay(1000).Wait();
                profilepageactionObject.EnterPassword(driver);
                profilepageactionObject.VerifyPassword(driver);
                profilepageactionObject.EnterFirstName(driver);
                Task.Delay(1000).Wait();
                profilepageactionObject.EnterLastName(driver);
                profilepageactionObject.EnterZipPostal(driver, PostalZip);
                Task.Delay(2000).Wait();
                profilepageactionObject.EnterCellPhone(driver);
                profilepageactionObject.SelectBirthday(driver);

                // here get the HomePage console error log and write it to text file 
                sw.WriteLine("");
                sw.WriteLine("##########  Register Page Console Error Log   #######");
                GetPageErrorLog();
                sw.WriteLine("##########   END   #########");
                sw.WriteLine("");
                sw.Flush();  // end of page console log  

                profilepageactionObject.ClickCreateAccbtn(driver);
                Task.Delay(2000).Wait();
                profilepageactionObject.ClickMyAccountDiv(driver);
                Task.Delay(3000).Wait();
            }
            else if (strCustomerType == "Customer")
            {
                driver.Navigate().GoToUrl(strUrl);
                Task.Delay(2000).Wait();
                headerpageactionObject.ClickLoginLink(driver);
                Task.Delay(2000).Wait();
                headerpageactionObject.DivLogin_EnterEmail(driver, "TestAutomationUser@gmail.com");
                headerpageactionObject.DivLogin_EnterPassword(driver, "Fighter@123");
                Task.Delay(500).Wait();
                headerpageactionObject.DivLogin_ClickLoginbtn(driver);
                Task.Delay(3000).Wait();
                mainpageactionObject.CloseRewardDiv(driver);
            }
            else if (strCustomerType == "Guest")
            {
                // do nothing 
            }
        }

        // this will store the store id's and addresses in 2-D array
        private string ReadTestStoreIdAddress()
        {
            string storeaddress = "";
            switch (StoreId)
            {
                case "2825":
                    storeaddress = ExceldataObject.ReadSheatData(3, 2, 2).ToString();
                    return storeaddress;
                case "2823":
                    storeaddress = ExceldataObject.ReadSheatData(3, 3, 2).ToString();
                    return storeaddress;
                case "2824":
                    storeaddress = ExceldataObject.ReadSheatData(3, 4, 2).ToString();
                    return storeaddress;
                case "2828":
                    storeaddress = ExceldataObject.ReadSheatData(3, 5, 2).ToString();
                    return storeaddress;
                case "2826":
                    storeaddress = ExceldataObject.ReadSheatData(3, 6, 2).ToString();
                    return storeaddress;
                case "2896":
                    storeaddress = ExceldataObject.ReadSheatData(3, 7, 2).ToString();
                    return storeaddress;
                case "2876":
                    storeaddress = ExceldataObject.ReadSheatData(3, 8, 2).ToString();
                    return storeaddress;
                case "2875":
                    storeaddress = ExceldataObject.ReadSheatData(3, 9, 2).ToString();
                    return storeaddress;
                case "QAProd-414":
                    storeaddress = ExceldataObject.ReadSheatData(3, 10, 2).ToString();
                    return storeaddress;
                default:
                    return "";
            }
        }

        // this will add upgrade and addon against the arrangement
        private void IncludeUpgradeAddonMethod(IWebDriver driver)
        {
            if (PersonalizeOrder == "Yes")
            {
                arrgaddonactionObject.SelectAnyAddon(driver);
                arrgaddonactionObject.SelectAnyUpgrade(driver);
                // here get the AddOn Page console error log and write it to text file 
                sw.WriteLine("");
                sw.WriteLine("##########  Addon Page Console Error Log   #######");
                GetPageErrorLog();
                sw.WriteLine("##########   END   #########");
                sw.WriteLine("");
                sw.Flush();  // end of page console log 
                arrgaddonactionObject.ClickContinue(driver);
            }
            else
            {
                // here get the AddOn Page console error log and write it to text file 
                sw.WriteLine("");
                sw.WriteLine("##########  Addon Page Console Error Log   #######");
                GetPageErrorLog();
                sw.WriteLine("##########   END   #########");
                sw.WriteLine("");
                sw.Flush();  // end of page console log 
                arrgaddonactionObject.ClickContinue(driver);
            }
        }

        // this will check the assertions on the fruit cart page
        private void FruitCartAssertionMethod(int var_i)
        {
            string CardMessageonpage = Driver.FindElement(By.XPath("//*[@class='rInfoDetail']//*[contains(text(),'this is test card message for test order, please ignore it')]")).Text.ToString();
            // string expectedCardMessage = arrgtestObject[var_i].CardMessage;
            // Assert.IsTrue(expectedCardMessage.Contains(CardMessageonpage));
        }

        // this method will return the required URL based upon the excel value of TestEnvironment variable 
        private void SetUrl()
        {
            if (Application == "Mobile" && Instance == "US")
            {
                if (TestEnvironment == "Live")
                {
                    MobileURL = "https://m.ediblearrangements.com/?showteststore=1";
                }
            }
            else if (Application == "Mobile" && (Instance == "CA" || Instance == "CA-FR"))
            {
                if (TestEnvironment == "Live")
                {
                    MobileURL = "https://m.ediblearrangements.ca/?showteststore=1";
                }
            }

            if (Application == "Desktop" && Instance == "US")
            {
                if (TestEnvironment == "Live")
                {
                    DesktopURL = "https://www.ediblearrangements.com/?showteststore=1";
                }
            }
            else if (Application == "Desktop" && (Instance == "CA" || Instance == "CA-FR"))
            {
                if (TestEnvironment == "Live")
                {
                    DesktopURL = "https://www.ediblearrangements.ca/?showteststore=1";
                }
            }
        }

        // this method will enter the billing information on the paymentmethod page
        private void EnterBillingInformation(string str_country, string str_ordertype, string str_testenvironment, string str_paymentmethod)
        {


        }

        // get respective page Error log 
        private void GetPageErrorLog()
        {
            // get all the Error logs of this page
            var entries = Driver.Manage().Logs.GetLog(LogType.Browser);
            foreach (var entry in entries)
            {
                // string text = entry.ToString().ToLower();
                //if (text.Contains("404") || text.Contains("500") || text.Contains("unhandled") || text.Contains("(Not Found)"))
                //{
                sw.WriteLine(entry.ToString());
                //}
            }
            sw.Flush();
        }

        // Desktop -- Signup and login method 
        private void Desktop_SignupAndLoginFunction(IWebDriver driver, String strUrl, String strCustomerType)
        {
            if (strCustomerType == "NewUser")
            {
                // here user should register 
            }
            else if (strCustomerType == "Customer")
            {
                // here user should login as a customer
            }
            else if (strCustomerType == "Guest")
            {
                // do nothing 
            }
        }

        // Desktop -- Shipment order 
        private void Desktop_ShipmentOrderFunction(IWebDriver driver, string strContinueShopping, int strExcelColumnWriteindex, int str_i)
        {


        }

    }
}


