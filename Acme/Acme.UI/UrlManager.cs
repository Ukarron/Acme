namespace Acme.UI
{
    public static class UrlManager
    {
        public static string InternetStoreHomePage()
        {
            return "http://wordpress.ua";
        }

        public static string LoginPage(string baseUrl)
        {
            return $"{baseUrl}/wp-login.php?loggedout=true";
        }
    }
}
