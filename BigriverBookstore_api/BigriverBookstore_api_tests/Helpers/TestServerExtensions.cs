using Microsoft.AspNetCore.TestHost;

namespace BigriverBookstore_api_tests.Helpers
{
    public static class TestServerExtensions
    {
        public static T GetService<T>(this TestServer server)
        {
            return (T)server.Host.Services.GetService(typeof(T));
        }
    }
}