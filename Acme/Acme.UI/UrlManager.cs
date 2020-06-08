using Acme.Test;

namespace Acme.UI
{
    public static class UrlManager
    {
        public static string DashboardPage(string baseUrl)
        {
            return $"{baseUrl}/wp-admin/";
        }

        public static string InternetStoreHomePage()
        {
            return RunConfig.ChooseLocalOrRemoteBaseUrl();
        }

        public static string LoginPage(string baseUrl)
        {
            return $"{baseUrl}/wp-login.php?loggedout=true";
        }        
    }
}
