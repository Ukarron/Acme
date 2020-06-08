namespace Acme.UI.Admin
{
    public class PersonalMenu : Element
    {
        private AElement PersonalMenuRootElement => ElementFactory.Create<AElement>(Locator.Css("[id='wp-admin-bar-my-account'] > [class='ab-item']"));
        private Span Username => ElementFactory.Create<Span>(Locator.Css("[id='wp-admin-bar-user-actions'] [class='display-name']"));

        public PersonalMenu Expand()
        {
            PersonalMenuRootElement.WaitAndMouseOver();
            return this;
        }

        public string GetUsername()
        {
            return Username.GetText();
        }
    }
}
