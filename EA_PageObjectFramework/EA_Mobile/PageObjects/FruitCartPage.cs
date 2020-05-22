using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_PageObjectFramework.EA_Mobile.PageObjects
{
    class FruitCartPage
    {
        internal By DivContinebtn = By.XPath("//*[@id='divContinue']/a");
        internal By CouponPromotionfield = By.XPath("//*[contains(@id, 'txtCoupon')]");
        internal By ApplyCouponBtn = By.XPath("//*[@id='rptSale_ctl01_pnlCoupon']//*[contains(text(),'Apply')]");
        internal By CartTotal_fruitcartpage = By.XPath("//*[@class='w70 boldText']");
        internal By ContinueShoppingBtn = By.XPath("//*[@id='dvHead']//*[contains(text(), 'Continue Shopping')]");
        internal By CheckOutbtn = By.XPath("//*[@id='dvHead']//*[contains(text(), 'Checkout')]");
        internal By GoBackBtn = By.XPath("//*[@id='dvHead']//*[@class='divGoBackButton']");

        internal By PromotionalDiv = By.XPath("//*[@id='divFreeProducts']");
        internal By PromotionalDiv_Item = By.XPath("//*[@id='divFreeProducts']//*[@class='item']");
        internal By PromotionalDiv_ItemCheckbox = By.XPath("//*[@id='divFreeProducts']//*[@class='item']//*[@class='check checkbox']");
        internal By PromotionalDiv_Continuebtn = By.XPath("//*[@id='divContinue']//*[contains(text(), 'Continue')]");

        internal By Rewards_btn = By.XPath("//*[@class='bottom - buttons']//*[contains(text(), 'MY REWARDS')]");
        internal By RewardDiv_Closebtn = By.XPath("//*[@id='divSessionActive'][contains(text(), 'CLOSE')]");
        internal By RewardApply_btn = By.XPath("//*[@id='divMyRewards']//*[contains(text(), 'APPLY')]");
        internal By RewardApplyFailMsg = By.XPath("//*[@id='fCart']//*[contains(text(), 'Coupon is a reward and not applicable on some arrangements/products')]");

        internal By CartTotalPrice = By.XPath("//*[@class='footer']//*[@class='w70 boldText']");
    }
}
