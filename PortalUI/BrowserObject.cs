using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace PortalUI
{
    public class BrowserObject
    {
        public static IWebDriver Driver;
        public WebDriverWait wait;
        //IWebDriver Driver = new FirefoxDriver();


        public BrowserObject(string browserName)
        {
            BrowserTypeSet(browserName);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        }
        
        public void BrowserClose()
        {
            Driver.Dispose();
        }

        public void BrowserTypeSet(string n)
        {
            switch (n.ToLower().Trim(' '))
            {
                case "firefox":
                case "ff":
                    var options = new FirefoxOptions();
                    options.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    Driver = new FirefoxDriver(options);
                    break;
                case "chrome":
                case "googlechrome":
                case "gc":
                    Driver = new ChromeDriver();
                    break;
                case "ie":
                case "internetexplorer":
                    Driver = new InternetExplorerDriver();
                    break;
            }
        }

        public void Browse(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public bool ElementExist(string elementPath, string elementName)
        {
            Thread.Sleep(1000);
            bool result = true;
            IWebElement webElement = WebElementGenerator(elementPath, elementName);
            if (webElement == null)
            {
                result = false;
            }
            return result;
        }


        public bool ElementSetValue(string elementPath, string elementName, string elementValue)
        {
            bool result = true;
            IWebElement webElement = WebElementGenerator(elementPath, elementName);
            if (webElement != null)
            {
                webElement.SendKeys(elementValue);
            }
            else
            {
                result = false;
            }
            return result;
        }


        public string ElementGetText(string elementPath, string elementName)
        {
            string result = null;
            IWebElement webElement = WebElementGenerator(elementPath, elementName);
            if (webElement != null)
            {
                result = webElement.Text;
            }
            return result;
        }



        public bool PressButton(string elementPath, string elementName)
        {
            bool result = true;
            IWebElement webElement = WebElementGenerator(elementPath, elementName);
            if (webElement != null)
            {
                webElement.Click();
            }
            else
            {
                result = false;
            }
            
            return result;
        }

        public bool BrowserWait(int msec)
        {
            bool result = true;

            Thread.Sleep(msec);

            return result;
        }

        public bool BrowserMaximize()
        {
            bool result = true;

            Driver.Manage().Window.Maximize();

            return result;
        }





        private IWebElement WebElementGenerator(string elementPath, string elementName)
        {
            IWebElement webElement = null;
            try
            {
                switch (elementPath.ToLower())
                {
                    case "id":
                        webElement = Driver.FindElement(By.Id(elementName));
                        break;
                    case "cssselector":
                        webElement = Driver.FindElement(By.CssSelector(elementName));
                        break;
                    case "classname":
                        webElement = Driver.FindElement(By.ClassName(elementName));
                        break;
                    case "linkedtext":
                        webElement = Driver.FindElement(By.LinkText(elementName));
                        break;
                    case "name":
                        webElement = Driver.FindElement(By.Name(elementName));
                        break;
                    case "tagname":
                        webElement = Driver.FindElement(By.TagName(elementName));
                        break;
                    case "xpath":
                        webElement = Driver.FindElement(By.XPath(elementName));
                        break;
                }
            }
            catch
            {
                webElement = null;
            }
            return webElement;
        }
    }
}
