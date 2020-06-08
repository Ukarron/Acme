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

        public string GetText()
        {
            DriverManager.Current.WaitForVisibilityOfElement(this);
            var text = Wrapper.Text;
            return text;
        }
    }

    public class AElement : Element
    {
        public void WaitAndMouseOver()
        {
            DriverManager.Current.WaitForVisibilityOfElement(this);
            DriverManager.Current.MouseOver(this);
        }
    }

    public class InputElement : Element
    {
        public void EnterText(string text)
        {
            DriverManager.Current.WaitForVisibilityOfElement(this);
            Wrapper.SendKeys(text);
        }
    }

    public class Span : Element
    {        
    }

    public class H1 : Element
    {
    }
}
