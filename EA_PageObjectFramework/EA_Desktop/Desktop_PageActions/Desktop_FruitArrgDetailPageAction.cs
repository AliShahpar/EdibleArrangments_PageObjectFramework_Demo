using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA_PageObjectFramework.EA_Desktop.Desktop_PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace EA_PageObjectFramework.EA_Desktop.Desktop_PageActions
{
    class Desktop_FruitArrgDetailPageAction
    {
        private Desktop_FruitArrgDetailPage fruitarrgdetail = new Desktop_FruitArrgDetailPage();

        // this method will select arrangement size
        public void SelectArrangementSize(IWebDriver driver)
        {
          driver.FindElement(fruitarrgdetail.ArrangementSize).Click();
        }

        // this method will select the Quantity
        public void SelectArrangementQuantity(IWebDriver driver)
        {
          SelectElement quantity = new SelectElement(driver.FindElement(fruitarrgdetail.QuantityList));
          quantity.SelectByValue("3");
        }

        // this method would select Arrangement Quantity 
        public void SelectArrQuantity_Shipment(IWebDriver driver)
        {
          SelectElement quantity = new SelectElement(driver.FindElement(fruitarrgdetail.QuantityList));
          quantity.SelectByValue("2");
        }

        // this method will click on Continue btn-image
        public void ClickContinueBtn(IWebDriver driver)
        {
          driver.FindElement(fruitarrgdetail.Continuebtn).Click();
        }

        // this would check if the Arrg small size is available and then return true or false
        public void CheckArrgSmallSize(IWebDriver driver)
        {
            /*
            Point t = driver.FindElement(By.XPath("//*[@class='LinksPanel']//*[contains(text(), 'Corporate')]")).Location;
            int x = t.X; int y = t.Y;
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string ImgName = "ScreenCap_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".png";
            string ImgFilePath = @"G:\" + ImgName + ".png";
            ss.SaveAsFile(@"G:\"+ ImgName + ".png");
            // ss.SaveAsFile(@"G:\Image1.png", ScreenshotImageFormat.Png);
            Image newImage = Image.FromFile(ImgFilePath);
            Graphics gfx = Graphics.FromImage(newImage);
            Image sniper = Image.FromFile(@"G:\sniper2.png");
            gfx.DrawImage(sniper, t);
            newImage.Save(@"G:\TestSniperImages\" + "ScreenCap_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".png" );
            gfx = null;

            FileInfo file = new FileInfo(ImgFilePath);
            if (file.Exists)
            {
                // file.Delete();
            }
            */

            Point t = driver.FindElement(fruitarrgdetail.SmallSize).Location;
            int x = t.X; int y = t.Y;
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string ImgName = "ScreenCap_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".png";
            string ImgFilePath = @"G:\" + ImgName + ".png";
            ss.SaveAsFile(@"G:\"+ ImgName + ".png");
            // ss.SaveAsFile(@"G:\Image1.png", ScreenshotImageFormat.Png);
            Image newImage = Image.FromFile(ImgFilePath);
            Graphics gfx = Graphics.FromImage(newImage);
            Image sniper = Image.FromFile(@"G:\sniper.png");
            gfx.DrawImage(sniper, t);
            newImage.Save(@"G:\TestSniperImages\" + "ScreenCap_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".png" );  

            FileInfo file = new FileInfo(ImgFilePath);
            if (file.Exists)
            {
                // file.Delete();
            }


            try
            {
                // click on small size of Arrangement 1047
                driver.FindElement(fruitarrgdetail.SmallSize).Click();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("1047 arragement small size not available on dekstop site" + e);
                try { driver.FindElement(fruitarrgdetail.ArrangementSize).Click(); }
                catch { }
            }

        }

    }
}
