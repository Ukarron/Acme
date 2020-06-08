namespace Acme.UI.InternetStore
{
    public class HomePage
    {
        private H1 Title => ElementFactory.Create<H1>(Locator.ClassName("entry-title"));

        public void Open()
        {
            DriverManager.Current.OpenUrl(UrlManager.InternetStoreHomePage());
        }

        public string GetTitle()
        {
            DriverManager.Current.WaitForVisibilityOfElement(Title);
            return Title.GetText();
        }
    }
}
