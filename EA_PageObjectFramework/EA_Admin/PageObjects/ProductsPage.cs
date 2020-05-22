using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Admin.PageObjects
{
    class ProductsPage
    {
        public By producttabButton = By.Id("ctl00_CPLeftMenu_ucLeftMenu_ItemProductGroup");
        public By ArrangementTab = By.Id("ctl00_ctl00_CPLeftMenu_UCleftMenu_ItemProducts");
        public By Add_arr = By.Id("ctl00_ctl00_CPBody_CBody_btnAdd");
        public By ArrEngNameTextField = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationName_rptTxtML_ctl00_txtML");
        public By ArrSpName = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationName_rptImgML_ctl01_imgML");
        public By ArrSpNameText = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationName_rptTxtML_ctl01_txtML");
        public By ArrFrName = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationName_rptImgML_ctl02_imgML");
        public By ArrFrNameText = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationName_rptTxtML_ctl02_txtML");
        public By SmallEngNameTextField = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationNameSmall_rptTxtML_ctl00_txtML");
        public By SmallSpName = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationNameSmall_rptImgML_ctl01_imgML");
        public By SmallSpNameText = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationNameSmall_rptTxtML_ctl01_txtML");
        public By SmallFrName = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationNameSmall_rptImgML_ctl02_imgML");
        public By SmallFrNameText = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationNameSmall_rptTxtML_ctl02_txtML");
        public By DescriptionEngTextField = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationDescriptionLarge_rptTxtML_ctl00_txtML");
        public By DescriptionSp = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationDescriptionLarge_rptImgML_ctl01_imgML");
        public By DescriptionSpText = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationDescriptionLarge_rptTxtML_ctl01_txtML");
        public By DescriptionFr = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationDescriptionLarge_rptImgML_ctl02_imgML");
        public By DescriptionFrText = By.Id("ctl00_ctl00_CPBody_CBody_txtProductInformationDescriptionLarge_rptTxtML_ctl02_txtML");
        public By ProductType = By.Id("ctl00_ctl00_CPBody_CBody_ddlProductInformationType");
    }
}
