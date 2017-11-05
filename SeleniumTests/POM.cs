using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestBrowsers
{
    public class POM
    {
        By but1 = By.Id("but1");
        By but2 = By.Id("but2");
        By but3 = By.Id("but3");
        By but4 = By.Id("but4");
        By but5 = By.Id("but5");
        By but6 = By.Id("but6");
        By but7 = By.Id("but7");
        By but8 = By.Id("but8");
        By but9 = By.Id("but9");
        By but0 = By.Id("but0");
        By butPlus = By.Id("butPlus");
        By butMinus = By.Id("butMinus");
        By butMult = By.Id("butMult");
        By butDiv = By.Id("butDiv");
        By butEqual = By.Id("butEqual");
        By resField = By.Id("resField");

        IWebDriver driver;
        public POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElement(string s)
        {
            IWebElement flag = null;
            switch (s)
            {
                case "but1":
                    flag = driver.FindElement(but1);
                    break;
                case "but2":
                    flag = driver.FindElement(but2);
                    break;
                case "but3":
                    flag = driver.FindElement(but3);
                    break;
                case "but4":
                    flag = driver.FindElement(but4);
                    break;
                case "but5":
                    flag = driver.FindElement(but5);
                    break;
                case "but6":
                    flag = driver.FindElement(but6);
                    break;
                case "but7":
                    flag = driver.FindElement(but7);
                    break;
                case "but8":
                    flag = driver.FindElement(but8);
                    break;
                case "but9":
                    flag = driver.FindElement(but9);
                    break;
                case "but0":
                    flag = driver.FindElement(but0);
                    break;
                case "butPlus":
                    flag = driver.FindElement(butPlus);
                    break;
                case "butMinus":
                    flag = driver.FindElement(butMinus);
                    break;
                case "butMult":
                    flag = driver.FindElement(butMult);
                    break;
                case "butDiv":
                    flag = driver.FindElement(butDiv);
                    break;
                case "butEqual":
                    flag = driver.FindElement(butEqual);
                    break;
                case "resField":
                    flag = driver.FindElement(resField);
                    break;
                default:
                    break;
            }
            return flag;
        }
    }
}