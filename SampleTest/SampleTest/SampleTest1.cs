using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleTest
{
    [TestClass]
    public class SampleTest1
    {
        public static IWebDriver driver;

        [TestMethod]
        public void PHPNetTest()
        {
            ChromeOptions options = new ChromeOptions();
            var proxy = new Proxy();
            proxy.Kind = ProxyKind.Manual;
            options.Proxy = proxy;
            driver = new ChromeDriver();

            //Validate URL
            driver.Navigate().GoToUrl("http://www.php.net");
            IWebElement searchInput = driver.FindElement(By.XPath(".//input[@type='search']"));
            searchInput.SendKeys("eval" + Keys.Enter);
            Assert.AreEqual("http://php.net/manual/en/function.eval.php", driver.Url);

            //Validate Cautions 
            var div_Cautions = driver.FindElements(By.XPath(".//div[@class='caution']"));
            Assert.IsTrue(div_Cautions.Count >= 1);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
