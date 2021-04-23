using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Microsoft.Extensions.Logging;
using log4net;

namespace gettacar
{

    public class Tests
    {
        IWebDriver driver;
        public string homeURL;
        string result;

        [SetUp]
        public void Setup()
        {
            SetDrive setdriver = new SetDrive();
            driver = setdriver.GetDriver("Chrome");
            homeURL = "https://www.gettacar.com/";
           
        }
        protected static readonly ILog log = LogManager.GetLogger(typeof(Tests));
        public void LoggingTests()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [Test(Description = "Navigate to WebPage and Find Car Price")]
        public void Test1()
        {
            driver.Navigate().GoToUrl(homeURL);
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver,System.TimeSpan.FromSeconds(190));
            
            // Click on Choose your Car
            wait.Until(
            driver => driver.FindElement(By.XPath("//*[@id='section-hero']/div/div[1]/div[2]/div/span/a[1]"))).Click();
            // Click on Body Type
            Thread.Sleep(1000);
            IWebElement BodyType = driver.FindElement(By.XPath("//*[@id='catalog-container']/div[2]/div[1]/div/div[2]/div[1]/span/h5"));
            driver.SwitchTo().ActiveElement();
            BodyType.Click();

            // Click on PickUp
            //wait.Until(
            //driver => driver.FindElement(By.XPath("//*[@id='catalog-container']/div[2]/div[1]/div/div[2]/div[2]/div/div[6]/div[2]/a"))).Click();
            Thread.Sleep(1000);
            IWebElement PickUp = driver.FindElement(By.XPath("//*[@id='catalog-container']/div[2]/div[1]/div/div[2]/div[2]/div/div[6]/div[2]/a"));
            driver.SwitchTo().ActiveElement();
            
            PickUp.Click();
            // Clic First Car
            //wait.Until(
            //driver => driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div[1]/div[1]/div/img[4]"))).Click();
            Thread.Sleep(5000);
            IWebElement FirstCar = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div[1]/div[1]/div/img[4]"));
            driver.SwitchTo().ActiveElement();
            
            FirstCar.Click();
            // Get Price
            Thread.Sleep(3000);
            IWebElement price = driver.FindElement(By.XPath("//*[@id='root']/div/div[3]/div[1]/div[2]/article/div[1]/div[2]/span"));
            driver.SwitchTo().ActiveElement();
            string Price = price.Text;
            char[] delimiterChars = { '$', ' ', ',', '.', ':', '\t' };
            string[] RowPrice = Price.Split(delimiterChars);
            string ToalPrice = RowPrice[1] + RowPrice[2];
            int PriceNum = 0;
            Int32.TryParse(ToalPrice, out PriceNum);
            //string result = "";
            if (PriceNum > 20000)
            {
                result = "High";
            }
            if (PriceNum == 20000)
            {
                result = "Equal";
            }
            if (PriceNum < 20000)
            {
                result = "Low";
            }
            log.DebugFormat("Find Price is {0}", result);
            Assert.Pass("Find Price is {0}", result);
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}