using Acme.UI;

namespace Acme.Test
{
    public class RunConfig
    {
        //http://wordpress.ua/wp-login.php?loggedout=true

        public static string LocalUrl = "http://wordpress.ua/";
        public static string RemoteUrl = "http://192.168.0.76/";
        public static bool RunRemotely = false;

        public static void ChooseEnvironment()
        {
            if (RunRemotely)
            {
                DriverManager.Current = Driver.GetForRemout();                
            }
            else
            {
                DriverManager.Current = Driver.GetFor(BrowserType.Chrome);
            }

            DriverManager.Current.MaximizeWindow();
        }
    }
}
