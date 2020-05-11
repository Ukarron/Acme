using System.Configuration;

namespace Acme.UI
{
    public class HomePage
    {
        private ATag Logo => ElementFactory.Create<ATag>(Locator.Xpath("//a[text()='Your Store']"));

        public void Open()
        {
            DriverManager.Current.OpenUrl(ConfigurationManager.AppSettings["RemoteUrl"]);
        }

        public string GetTitle()
        {
            return Logo.GetText();
        }
    }
}
