using RestSharp;

namespace Assistant
{
    class ServiceBuilderUser
    {
        private static string rootUrl = "http://gopher-server.xyz:49166/api/Main";
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