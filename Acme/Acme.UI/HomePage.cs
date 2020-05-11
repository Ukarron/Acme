namespace Acme.UI
{
    public class HomePage
    {
        private ATag Logo => ElementFactory.Create<ATag>(Locator.Xpath("//a[text()='Your Store']"));
        
        public string GetTitle()
        {
            return Logo.GetText();
        }
    }
}
