using OpenQA.Selenium;

namespace Acme.UI
{
    public sealed class Locator
    {
        internal readonly By ElementLocator;

        private Locator(By wrapper)
        {
            ElementLocator = wrapper;
        }

        public static Locator Id(string id)
        {
            var search = By.Id(id);
            return new Locator(search);
        }

        public static Locator Name(string name)
        {
            var search = By.Name(name);
            return new Locator(search);
        }

        public static Locator Css(string css)
        {
            var search = By.CssSelector(css);
            return new Locator(search);
        }

        public static Locator Xpath(string xPath)
        {
            var search = By.XPath(xPath);
            return new Locator(search);
        }
    }
}
