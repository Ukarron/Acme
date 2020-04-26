using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace Acme.UI
{
    public sealed class Driver
    {
        private readonly IWebDriver _wrapper;

        private readonly WebDriverWait _wait;

        private Driver(IWebDriver driver)
        {
            _wrapper = driver;
            _wait = new WebDriverWait(_wrapper, TimeSpan.FromSeconds(10));
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
            get => _wrapper.Url;
            set => _wrapper.Url = value;
        }

        internal IWebElement FindElement(Search search)
        {
            var element = _wrapper.FindElement(search.Wrapper);
            return element;
        }

        public void MaximizeWindow()
        {
            _wrapper.Manage().Window.Maximize();
        }

        public void Quit()
        {
            _wrapper.Quit();
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        InternetExplorer
    }
}
