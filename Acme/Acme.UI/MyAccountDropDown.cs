namespace Acme.UI
{
    public class MyAccountDropDown
    {
        private AElement LoginOption => ElementFactory.Create<AElement>(Locator.Xpath("//a[text()='Login']"));

        public void ClickLogin()
        {
            LoginOption.WaitAndClick();
        }
    }
}
