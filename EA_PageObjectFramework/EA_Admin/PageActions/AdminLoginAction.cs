using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Admin.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;


namespace EA_PageObjectFramework.EA_Admin.PageActions
{
    public class AdminLoginAction
    {
        IWebDriver IEdriver = new InternetExplorerDriver();
        LoginPage admObject = new LoginPage();
        ProductsPage prod_page = new ProductsPage();
       // static ExcelConfig Excel = new ExcelConfig();
        Common CommonFunction = new Common();
        ProductSizePage prod_size = new ProductSizePage();

        #region -- admin login
        public void AdminLogin()
        {
            //*********Author Atif Nawaz*********
            try
            {
                // insert url
                IEdriver.Manage().Window.Maximize();
                var URL = "https://admin.qadesktopus.local";
                IEdriver.Navigate().GoToUrl(URL);

                System.Threading.Thread.Sleep(1000);
                //Username
                var U_name = "admin";
                var User_Name = IEdriver.FindElement(admObject.Admin_username);
                User_Name.Clear();
                System.Threading.Thread.Sleep(1000);
                CommonFunction.SetText(User_Name, U_name);

                System.Threading.Thread.Sleep(1000);
                //Password
                var PW = "Admin@1234";
                System.Threading.Thread.Sleep(1000);
                IWebElement admPass = IEdriver.FindElement(admObject.Admin_Password);
                // System.Threading.Thread.Sleep(2000);
                admPass.Clear();
                System.Threading.Thread.Sleep(2000);
                admPass.Clear();
                CommonFunction.SetText(admPass, PW);

                System.Threading.Thread.Sleep(1000);

                //Add Pin Code
                var lab_pin = IEdriver.FindElement(admObject.Admin_LabelCode);
                string strPin = lab_pin.Text.ToString();

                // Adding the pin code string values
                var Substring0 = strPin.Substring(0, 1);
                var Substring1 = strPin.Substring(1, 1);
                var Substring2 = strPin.Substring(2, 1);
                var Substring3 = strPin.Substring(3, 1);

                int result = int.Parse(Substring0) + int.Parse(Substring1) + int.Parse(Substring2) + int.Parse(Substring3);
                var str_result = result.ToString();
                var str_result_length = str_result.Length;

                //Condition on if string is above 10 and below 10
                if (str_result_length == 2)
                {
                    var resultsubstring1 = str_result.Substring(0, 1);
                    var resultsubstring2 = str_result.Substring(1, 1);
                    int resultTotal = int.Parse(resultsubstring1) + int.Parse(resultsubstring2);
                    var stringdoublevalue = resultTotal.ToString() + resultTotal.ToString();
                    var pincodefield = IEdriver.FindElement(admObject.Admin_PinCode);
                    pincodefield.Clear();
                    System.Threading.Thread.Sleep(1000);
                    CommonFunction.SetText(pincodefield, stringdoublevalue);
                    System.Threading.Thread.Sleep(1000);

                }
                else
                {
                    var Singledigit = str_result + str_result;
                    var pincodefield = IEdriver.FindElement(admObject.Admin_PinCode);
                    pincodefield.Clear();
                    System.Threading.Thread.Sleep(1000);
                    pincodefield.SendKeys(Singledigit);
                    System.Threading.Thread.Sleep(1000);

                }
                //login button of admin page
                var Login_Button = IEdriver.FindElement(admObject.Admin_LoginButton);
                Login_Button.Click();
                System.Threading.Thread.Sleep(2000);
            }

            catch (Exception e)
            {
                Console.WriteLine("Admin login function exception: " + e);
            }
        }
        #endregion

        public void Arrangements()
        {
            try
            {
                //Click on Product tab
                var ProductTab = IEdriver.FindElement(prod_page.producttabButton);
                ProductTab.Click();
                System.Threading.Thread.Sleep(1000);
                //Click on Arrangement tab
                var ArrangementTabButton = IEdriver.FindElement(prod_page.ArrangementTab);
                ArrangementTabButton.Click();
                System.Threading.Thread.Sleep(1000);
                var SearchField = IEdriver.FindElement(prod_size.SeaachProd);
                CommonFunction.SetText(SearchField, "1047");
                System.Threading.Thread.Sleep(1000);
                //click on Go Button
                var SearchGoButton = IEdriver.FindElement(prod_size.Gobutton);
                SearchGoButton.Click();
                System.Threading.Thread.Sleep(1000);
                //Select an arrangement
                var ProductSelection = IEdriver.FindElement(prod_size.SelectArr);
                ProductSelection.Click();
                System.Threading.Thread.Sleep(1000);
                //Click on Size an price tab button
                var SizeTab = IEdriver.FindElement(prod_size.SelectSizenprice);
                SizeTab.Click();
                System.Threading.Thread.Sleep(2000);
                //Set value in product code field
                CommonFunction.SetText(IEdriver.FindElement(prod_size.Producodefield), "Wow Edible");
                System.Threading.Thread.Sleep(1000);
                // select from size drop down
                SelectElement ProductInfo = new SelectElement(IEdriver.FindElement(prod_size.Sizedropdown));
                ProductInfo.SelectByIndex(1);
                System.Threading.Thread.Sleep(1000);
                // Set value in Price text field
                CommonFunction.SetText(IEdriver.FindElement(prod_size.PriceField), "100");
                System.Threading.Thread.Sleep(1000);
                //set value in Sequence text field
                CommonFunction.SetText(IEdriver.FindElement(prod_size.Sequencefield), "1");
                System.Threading.Thread.Sleep(1000);
                //Select value from container
                var containervalue = IEdriver.FindElement(prod_size.ContainerBox);
                System.Threading.Thread.Sleep(1000);
                containervalue.Click();
                System.Threading.Thread.Sleep(2000);
                //Click on ">" button
                var ARRButton = IEdriver.FindElement(prod_size.SelectArrButton);
                ARRButton.Click();
                System.Threading.Thread.Sleep(4000);
                //Select radio button
                var rabioButtonContainer = IEdriver.FindElement(prod_size.Radiobutton);
                rabioButtonContainer.Click();
                System.Threading.Thread.Sleep(1000);
                //Click on add button
                var add_button = IEdriver.FindElement(prod_size.Addbutton);
                add_button.Click();
                System.Threading.Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Admin Arrangement function exception" + ex);
            }//end of catch block

            try
            {

                if (IEdriver.SwitchTo().Alert().Text.ToString() == "This size has already been added. Please select different size.")
                {
                    System.Threading.Thread.Sleep(1000);
                    var deleteAlert = IEdriver.SwitchTo().Alert();
                    deleteAlert.Accept();
                    System.Threading.Thread.Sleep(3000);
                    var TableData = IEdriver.FindElements(prod_size.MyTable);
                    System.Threading.Thread.Sleep(1000);
                    var totalcount = TableData.Count();
                    System.Threading.Thread.Sleep(1000);
                    for (int i = 0; i <= totalcount; i++)
                    {
                        for (int j = 0; j <= totalcount; j++)
                        {
                            if (i != 0 || j != 0)
                            {
                                System.Threading.Thread.Sleep(1000);
                                var TableRow = IEdriver.FindElement(By.Id("ctl00_ctl00_CPBody_CBody_rptAddedSizeAndPrice_ctl" + i + j + "_trRepeater"));
                                System.Threading.Thread.Sleep(1000);
                                var tablerowstext = TableRow.Text.ToString();
                                System.Threading.Thread.Sleep(1000);
                                // ... Get small size from string.
                                if (tablerowstext.Contains("Small"))
                                {
                                    System.Threading.Thread.Sleep(1000);
                                    var DeleteRow = IEdriver.FindElement(By.Id("ctl00_ctl00_CPBody_CBody_rptAddedSizeAndPrice_ctl" + i + j + "_imgbtnDelete"));
                                    DeleteRow.Click();
                                    System.Threading.Thread.Sleep(3000);
                                    var D_alert = IEdriver.SwitchTo().Alert();
                                    D_alert.Accept();
                                    System.Threading.Thread.Sleep(3000);
                                    var add_button2 = IEdriver.FindElement(prod_size.Addbutton);
                                    add_button2.Click();
                                    System.Threading.Thread.Sleep(3000);
                                    var update_button = IEdriver.FindElement(prod_size.UpdateButton);
                                    update_button.Click();
                                    System.Threading.Thread.Sleep(10000);
                                    break;

                                }// end of nested If condition block   
                            }//end of && condition block               
                        }//ebd of nested for loop
                        break;
                    }// end of for loop block

                }// End of if condition block
                else
                {
                    Console.WriteLine("Please verify the text manually.");
                }


            }// End of Try block
            catch (Exception ex)
            {
                //Click on update button
                var update_button = IEdriver.FindElement(prod_size.UpdateButton);
                System.Threading.Thread.Sleep(1000);
                update_button.Click();
                System.Threading.Thread.Sleep(5000);
            }//end of catch block
            
            System.Threading.Thread.Sleep(10000);
            var arrsuccessMessage = IEdriver.FindElement(prod_size.arrangementUpdatedMessage).Text.ToString();
            System.Threading.Thread.Sleep(5000);
            if (arrsuccessMessage == "Arrangement Updated Successfully.")
            {
                Console.WriteLine("Arrangement Updated Successfully.");
                System.Threading.Thread.Sleep(10000);
                var H_Button = IEdriver.FindElement(prod_size.HomeButton);
                H_Button.Click();
                System.Threading.Thread.Sleep(1000);
            }

        }//End of Arrangements function

        public void ArrangementAvailabilityStore()
        {
            try
            {
                //Click on Store tab
                var Store_tab = IEdriver.FindElement(prod_size.StoreTab);
                Store_tab.Click();
                System.Threading.Thread.Sleep(2000);
                //Search store from search field
                var SearchTextField = IEdriver.FindElement(prod_size.StoreSearchField);
                SearchTextField.SendKeys("414");
                System.Threading.Thread.Sleep(1000);
                //click on Go button
                var G_button = IEdriver.FindElement(prod_size.GoStoreButton);
                G_button.Click();
                System.Threading.Thread.Sleep(3000);
                //Select searched store
                var clickstore = IEdriver.FindElement(prod_size.SelectSearchedStore);
                clickstore.Click();
                System.Threading.Thread.Sleep(1000);
                //select PProduct Beta tab
                var prod_Beta = IEdriver.FindElement(prod_size.PrdoBetaTab);
                prod_Beta.Click();
                System.Threading.Thread.Sleep(1000);
                //Enter boxes to search boxes
                var ContainerProdBeta = IEdriver.FindElement(prod_size.SearchBoxfield);
                ContainerProdBeta.SendKeys("12 box");
                System.Threading.Thread.Sleep(2000);
                //Check delivery checkbox
                var Del_checkbox = IEdriver.FindElement(prod_size.DeliveryCheckBox);
                //Check Pickup check box
                var pickup_checkbox = IEdriver.FindElement(prod_size.PickupCheckBox);

                if (!Del_checkbox.Selected)
                {
                    Del_checkbox.Click();
                }
                if (!pickup_checkbox.Selected)
                {
                    pickup_checkbox.Click();
                }
                // Click on save container button
                var savecontainer = IEdriver.FindElement(prod_size.SaveBoxButton);
                savecontainer.Click();
                // if condition to check the alert box wheater it is unachanged dialog or chnaged dialog
                System.Threading.Thread.Sleep(2000);
                if (IEdriver.FindElement(prod_size.Nochangetosavealert).Displayed)
                {
                    var no_ok = IEdriver.FindElement(prod_size.NOchangeOk);
                    no_ok.Click();
                }
                else
                {
                    System.Threading.Thread.Sleep(6000);
                    var PopupOk = IEdriver.FindElement(prod_size.SaveBoxpopupcancelButton);
                    PopupOk.Click();

                }


                //click on arrangement tab right side to associate created small size
                System.Threading.Thread.Sleep(2000);
                var containerArrangementtab = IEdriver.FindElement(prod_size.ContainerArr);
                containerArrangementtab.Click();
                //Arrangement search field
                System.Threading.Thread.Sleep(6000);
                var Cont_arr_searc_field = IEdriver.FindElement(prod_size.ContainerArrSearchfield);
                Cont_arr_searc_field.SendKeys("1047");
                System.Threading.Thread.Sleep(2000);
                //click here link 
                var Click_here = IEdriver.FindElement(prod_size.Clickherearr);
                Click_here.Click();
                System.Threading.Thread.Sleep(3000);
                //var productBetaArr = IEdriver.FindElements(By.ClassName("name"));
                //var productBetaArr_count = productBetaArr.Count;
                //plus button to expand sizes of arrangement
                var Expand_size_PlusButton = IEdriver.FindElement(prod_size.PlusButton);
                Expand_size_PlusButton.Click();
                System.Threading.Thread.Sleep(4000);
                // loops to check the and find the associated size with an arrnagement
                for (int i = 0; i <= 6; i++)
                {
                    for (int j = 0; j <= 6; j++)
                    {

                        var ProductBetaSize = IEdriver.FindElement(By.Id("ctl00_ctl00_ctl00_CPBody_CBody_PCBody_rptAr_ctl31_rptSz_ctl" + i + j + "_trSz"));
                        System.Threading.Thread.Sleep(1000);
                        var ProductBetaSize_text = ProductBetaSize.Text.ToString();

                        if (ProductBetaSize_text.Contains("Small"))
                        {
                            var Product_Tab_Del_checkbox = IEdriver.FindElement(By.Id("ctl00_ctl00_ctl00_CPBody_CBody_PCBody_rptAr_ctl31_rptSz_ctl" + i + j + "_ckDl"));
                            var Product_Tab_pickup_checkbox = IEdriver.FindElement(By.Id("ctl00_ctl00_ctl00_CPBody_CBody_PCBody_rptAr_ctl31_rptSz_ctl" + i + j + "_ckPk"));
                            var Product_Tab_Shipment_checkbox = IEdriver.FindElement(By.Id("ctl00_ctl00_ctl00_CPBody_CBody_PCBody_rptAr_ctl31_rptSz_ctl" + i + j + "_ckShp"));

                            if (!Product_Tab_Del_checkbox.Selected)
                            {
                                Product_Tab_Del_checkbox.Click();
                            }
                            if (!Product_Tab_pickup_checkbox.Selected)
                            {
                                Product_Tab_pickup_checkbox.Click();
                            }
                            if (!Product_Tab_Shipment_checkbox.Selected)
                            {
                                Product_Tab_Shipment_checkbox.Click();

                            }


                        }

                    }//end of nested for loop
                    break;
                }//end of external for loop
                System.Threading.Thread.Sleep(2000);
                var Save_Arr_size_CheckboxChecked = IEdriver.FindElement(prod_size.SaveBoxButton);
                Save_Arr_size_CheckboxChecked.Click();
                //click on dialog box
                System.Threading.Thread.Sleep(8000);
                var dialog_ok = IEdriver.FindElement(prod_size.ArranagementUPdateddialogBoxokButotn);
                dialog_ok.Click();
                System.Threading.Thread.Sleep(2000);
                //Quit the IE driver
                IEdriver.Quit();
            }
            catch (Exception ex)
            {

                Console.WriteLine("ArrangementAvailabilityStore exception : " + ex);
            }
        }
    }
}
