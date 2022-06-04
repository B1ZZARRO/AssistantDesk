using RestSharp;

namespace Assistant
{
    class ServiceBuilder
    {
        private static string rootUrl = "https://api.aimybox.com";
        private static RestClient _restClient;

        public static RestClient GetInstance()
        {
            if (_restClient == null)
            {
                _restClient = new RestClient(rootUrl);
            }

            return _restClient;
        }
    }
}