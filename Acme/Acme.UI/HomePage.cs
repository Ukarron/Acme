namespace Acme.UI
{
    public class HomePage
    {
        private InputElement InputField => ElementFactory.Create<InputElement>(Search.Name("q"));

        private InputElement SearchInGoogleInput => ElementFactory.Create<InputElement>(Search.Css("[class='tfB0Bf'] [name='btnK']"));

        public void EnterSearchText(string text)
        {
            InputField.EnterText(text);
        }

        public void ClickSearchInGoogleInput()
        {
            SearchInGoogleInput.Click();
        }
    }
}
