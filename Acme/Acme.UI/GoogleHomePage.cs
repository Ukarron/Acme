namespace Acme.UI
{
    public class GoogleHomePage
    {
        private InputElement InputField => ElementFactory.Create<InputElement>(Locator.Name("q"));

        private InputElement SearchInGoogleInput => ElementFactory.Create<InputElement>(Locator.Css("[class='tfB0Bf'] [name='btnK']"));

        public string TitleText => DriverManager.Current.GetTitle();

        public void EnterSearchText(string text)
        {
            InputField.EnterText(text);
        }

        public void ClickSearchInGoogleInput()
        {
            SearchInGoogleInput.WaitAndClick();
        }
    }
}
