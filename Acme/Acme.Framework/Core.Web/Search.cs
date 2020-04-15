using OpenQA.Selenium;

namespace Acme.UI
{
    public sealed class Search
    {
        internal readonly By Wrapper;

        private Search(By wrapper)
        {
            Wrapper = wrapper;
        }

        public static Search Id(string id)
        {
            var search = By.Id(id);
            return new Search(search);
        }

        public static Search Name(string name)
        {
            var search = By.Name(name);
            return new Search(search);
        }

        public static Search Css(string css)
        {
            var search = By.CssSelector(css);
            return new Search(search);
        }
    }
}
