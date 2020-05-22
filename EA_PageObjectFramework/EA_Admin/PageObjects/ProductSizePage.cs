using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Admin.PageObjects
{
    class ProductSizePage
    {
        public By SeaachProd = By.Id("ctl00_ctl00_CPBody_CBody_txtSearch");
        public By SelectArr = By.Id("ctl00_ctl00_CPBody_CBody_lstvw_ctrl0_Td3");
        public By SelectSizenprice = By.Id("ctl00_ctl00_CPBody_CBody_lnkbtnSizesAndPrices");
        public By Gobutton = By.Id("ImgSearch");
        public By Producodefield = By.Id("ctl00_ctl00_CPBody_CBody_txtSizeAndPrizesCatalogCode");
        public By Sizedropdown = By.Id("ctl00_ctl00_CPBody_CBody_ddlSize");
        public By PriceField = By.Id("ctl00_ctl00_CPBody_CBody_txtSizePrice");
        public By Sequencefield = By.Id("ctl00_ctl00_CPBody_CBody_txtSizeSequence");
        public By ContainerBox = By.Id("ctl00_ctl00_CPBody_CBody_rptContainer_ctl01_trContainer");
        public By SelectArrButton = By.Id("ctl00_ctl00_CPBody_CBody_btnProductInformationCategoriesAssociate");
        public By Radiobutton = By.Id("ctl00_ctl00_CPBody_CBody_rptSelectedContainer_ctl01_rdbtnSelectedContainer");
        public By Addbutton = By.Id("ctl00_ctl00_CPBody_CBody_btnSizeAndPriceAdd");
        public By UpdateButton = By.Id("ctl00_ctl00_CPBody_CBody_btnUpdate");
        public By MyTable = By.ClassName("trRepeater");
        public By arrangementUpdatedMessage = By.Id("dvAddedSuccesfully");
        public By HomeButton = By.XPath("//*[@id='MenuLeftPanel']/tbody/tr[1]/td/a/img");
        public By SuccessDialog = By.XPath("//*[@id='tblStatus']/tbody/tr[2]/td/center/input");

        public By StoreTab = By.Id("ctl00_CPLeftMenu_ucLeftMenu_ItemStoreGroup");
        public By StoreSearchField = By.Id("ctl00_ctl00_CPBody_CBody_txtSearch");
        public By GoStoreButton = By.Id("ctl00_ctl00_CPBody_CBody_btnGo_Store");
        public By SelectSearchedStore = By.Id("ctl00_ctl00_CPBody_CBody_lstvw_ctrl0_trLocation");
        public By PrdoBetaTab = By.Id("ctl00_ctl00_CPLeftMenu_UCleftMenu_liStoreProductsBeta");
        public By SearchBoxfield = By.Id("ctl00_ctl00_ctl00_CPBody_CBody_PCBody_txtSearchProducts");
        public By DeliveryCheckBox = By.XPath("//*[@id='ctl00_ctl00_ctl00_CPBody_CBody_PCBody_rptCn_ctl01_ckDl']");
        public By PickupCheckBox = By.XPath("//*[@id='ctl00_ctl00_ctl00_CPBody_CBody_PCBody_rptCn_ctl01_ckPk']");
        public By SaveBoxButton = By.XPath("//*[@id='btndummysave']");
        public By SaveBoxpopupcancelButton = By.Id("btnCloseDiv");
        public By ContainerArr = By.XPath("//*[@id='trArr']");
        public By ContainerArrSearchfield = By.Id("ctl00_ctl00_ctl00_CPBody_CBody_PCBody_txtSearchProducts");
        public By Clickherearr = By.XPath("//*[@id='lnk_SearchCatlogNumber']");
        public By PlusButton = By.Id("ctl00_ctl00_ctl00_CPBody_CBody_PCBody_rptAr_ctl31_btnPlus");
        public By ArranagementUPdateddialogBoxokButotn = By.XPath("//*[@id='dvAddedSuccesfully']/div[2]/div/input");

        public By Nochangetosavealert = By.Id("NoChangetoSaveAlert");
        public By NOchangeOk = By.XPath("//*[@id='NoChangetoSaveAlert']/div[2]/div[3]/input");
    }
}
