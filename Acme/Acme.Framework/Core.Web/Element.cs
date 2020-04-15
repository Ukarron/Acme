using OpenQA.Selenium;

namespace Acme.UI
{
    public abstract class Element
    {
        internal Search SearchWrapper;

        internal IWebElement Wrapper => DriverManager.Current.FindElement(SearchWrapper);

        public string InnerText => Wrapper.Text;

        public void Click()
        {
            Wrapper.Click();
        }

    }

    public class AElement : Element
    {
    }

    public class InputElement : Element
    {
        public void EnterText(string text)
        {
            Wrapper.SendKeys(text);
        }
    }
}
