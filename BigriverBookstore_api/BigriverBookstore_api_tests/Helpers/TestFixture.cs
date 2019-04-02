using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc;
using BigriverBookstore_api;

namespace BigriverBookstore_api_tests.Helpers
{
    public class TestFixture : IDisposable
    {
        public TestServer Server { get; private set; }

        public TestFixture()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>();
            Server = new TestServer(builder);
        }

        public void Dispose()
        {
            Server.Dispose();
        }
    }
}