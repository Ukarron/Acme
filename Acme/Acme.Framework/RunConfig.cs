using Acme.UI;

namespace Acme.Test
{
    public class RunConfig
    {
        public static string LocalUrl = "http://wordpress.ua/";
        public static string RemoteUrl = "http://192.168.0.76/";
        public static bool RunLocally = true;

        public static void BrowserStart()
        {
            if (RunLocally)
            {
                DriverManager.Current = Driver.GetFor(BrowserType.Chrome);
                
            }
            else
            {
                DriverManager.Current = Driver.GetForRemout();
            }

            DriverManager.Current.MaximizeWindow();

            ChooseLocalOrRemoteBaseUrl();
        }

        public static string ChooseLocalOrRemoteBaseUrl()
        {
            if (RunLocally)
            {
                return LocalUrl;
            }
            else
            {
                return RemoteUrl;
            }
        }
    }
}
