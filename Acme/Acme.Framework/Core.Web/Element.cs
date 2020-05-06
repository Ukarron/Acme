using OpenQA.Selenium;

namespace Acme.UI
{
    public abstract class Element
    {
        internal Locator SearchWrapper;

        internal IWebElement Wrapper => DriverManager.Current.FindElement(SearchWrapper);        

        public void WaitAndClick()
        {
            DriverManager.Current.WaitForVisibilityOfElement(this);
            Wrapper.Click();
        }

        public string InnerText => Wrapper.Text;        
    }

    public class InputElement : Element
    {
        public void EnterText(string text)
        {
            Wrapper.SendKeys(text);
        }
    }
}
