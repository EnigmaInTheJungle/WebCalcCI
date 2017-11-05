using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace TestBrowsers
{
    [TestFixture(typeof(EdgeDriver))]
    public class NUnitTets<TPage> where TPage : IWebDriver, new()
    {
        POM obj;
        static IWebDriver driver = null;
        [OneTimeSetUp]
        public void DriverPath()
        {
            driver = new TPage();
            obj = new POM(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }

        [SetUp]
        public void TestUp()
        {
            driver.Navigate().GoToUrl("file:///"+ GetApplicationPath("CalcJS.html"));
        }


        static string GetApplicationPath(string applicationName)
        {
            var tmpDirName = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(tmpDirName)));
            string result = Path.Combine(solutionFolder, applicationName);
            return result;
        }

        [Test]
        [TestCase("but1")]
        [TestCase("but2")]
        [TestCase("but3")]
        [TestCase("but4")]
        [TestCase("but5")]
        [TestCase("but6")]
        [TestCase("but7")]
        [TestCase("but8")]
        [TestCase("but9")]
        [TestCase("but0")]
        [TestCase("butMinus")]
        [TestCase("butPlus")]
        [TestCase("butMult")]
        [TestCase("butDiv")]
        [TestCase("butEqual")]
        [TestCase("resField")]
        public void TestExistingElements(string elementId)
        {
            IWebElement el = obj.FindElement(elementId);
            NUnit.Framework.Assert.AreEqual(true, el.Displayed);
        }

        [Test]
        [TestCase("but1", "1")]
        [TestCase("but2", "2")]
        [TestCase("but3", "3")]
        [TestCase("but4", "4")]
        [TestCase("but5", "5")]
        [TestCase("but6", "6")]
        [TestCase("but7", "7")]
        [TestCase("but8", "8")]
        [TestCase("but9", "9")]
        [TestCase("but0", "0")]
        public void TestSimpleCheck(string elementId, string res)
        {
            obj.FindElement(elementId).Click();
            string num = obj.FindElement("resField").GetAttribute("value");
            NUnit.Framework.Assert.AreEqual(res, num);
        }

        [Test]
        [TestCase(new string[] { "but1", "but2", "but3" }, "123")]
        [TestCase(new string[] { "but4", "but5", "but6" }, "456")]
        [TestCase(new string[] { "but7", "but8", "but9" }, "789")]
        [TestCase(new string[] { "but3", "but0", "but6" }, "306")]
        public void TestComplexCheck(string[] butts, string res)
        {
            foreach (string str in butts)
            {
                obj.FindElement(str).Click();
            }
            string num = obj.FindElement("resField").GetAttribute("value");
            NUnit.Framework.Assert.AreEqual(res, num);
        }

        [Test]
        [TestCase("but1", "but2", "butPlus", "3")]
        [TestCase("but3", "but4", "butMinus", "-1")]
        [TestCase("but5", "but6", "butMult", "30")]
        [TestCase("but9", "but3", "butDiv", "3")]
        [TestCase("but7", "but0", "butDiv", "Infinity")]
        public void TestRealJob(string x, string y, string op, string res)
        {
            obj.FindElement(x).Click();
            obj.FindElement(op).Click();
            obj.FindElement(y).Click();
            obj.FindElement("butEqual").Click();
            string calc = obj.FindElement("resField").GetAttribute("value");
            NUnit.Framework.Assert.AreEqual(res, calc);
        }

    }
}