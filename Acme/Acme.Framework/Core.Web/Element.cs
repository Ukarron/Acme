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
    }

    public class InputElement : Element
    {
        public void EnterText(string text)
        {
            Wrapper.SendKeys(text);
        }
    }

    public class ATag : Element
    {
        public string GetText()
        {
            var innerText = Wrapper.Text;
            return innerText;
        }
    }
}
