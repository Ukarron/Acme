using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Acme.UI
{
    public sealed class Driver
    {
        private readonly IWebDriver _driverWrapper;
        private readonly WebDriverWait _wait;
        private const double Default_Wait_Time = 60;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private Driver(IWebDriver driver)
        {
            _driverWrapper = driver;
            _wait = new WebDriverWait(_driverWrapper, TimeSpan.FromSeconds(Default_Wait_Time));
        }

        public static Driver GetFor(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new Driver(new ChromeDriver());

                case BrowserType.InternetExplorer:
                    return new Driver(new InternetExplorerDriver());

                case BrowserType.Firefox:
                    return new Driver(new FirefoxDriver());

                default:
                    throw new Exception("There is no such browser.");
            }
        }

        public static Driver GetForRemout()
        {
            FirefoxOptions options = new FirefoxOptions();
            var url = new Uri("http://192.168.0.76:4444/wd/hub");
            var driver = new Driver(new RemoteWebDriver(url, options));
            return driver;
        }

        public string Url
        {
            get => _driverWrapper.Url;
            set => _driverWrapper.Url = value;
        }

        internal IWebElement FindElement(Locator search)
        {
            var element = _driverWrapper.FindElement(search.ElementLocator);
            return element;
        }

        /// <summary> An expectation for checking that an element is either invisible or not present on the DOM. </summary>
        //public void WaitForInvisibilityOfElement(Element element)
        //{
        //    //Logger.Trace($"Waiting for invisibility of '{element}' element...");
        //    //Thread.Sleep(NegativeWaitDelayInMs);
        //    //_wait.Until(WaitConditions.InvisibilityOfElement(element.Locator.Wrapper, element.Parent));
        //}

        internal static Func<IWebDriver, bool> InvisibilityOfElement(By locator)
        {
            Logger.Trace($"Waiting for invisibility of '{locator}' element...");

            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        internal static Func<IWebDriver, bool> VisibilityOfElement(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public void WaitForInvisibilityOfElement(Element locator)
        {
            Thread.Sleep(500);
            _wait.Until(InvisibilityOfElement(locator.SearchWrapper.ElementLocator));            
        }

        public void WaitForVisibilityOfElement(Element locator)
        {
            Thread.Sleep(500);
            _wait.Until(VisibilityOfElement(locator.SearchWrapper.ElementLocator));
        }

        public string GetTitle()
        {
            return _driverWrapper.Title;
        }

        public void MaximizeWindow()
        {
            _driverWrapper.Manage().Window.Maximize();
        }

        public void Quit()
        {
            _driverWrapper.Quit();
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        InternetExplorer
    }
}
