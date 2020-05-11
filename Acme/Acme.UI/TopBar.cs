namespace Acme.UI
{
    public class TopBar
    {
        private Li MyAccountIcon => ElementFactory.Create<Li>(Locator.ClassName("dropdown"));

        public void ClickMyAccountIcon()
        {
            MyAccountIcon.WaitAndClick();
        }
    }
}
