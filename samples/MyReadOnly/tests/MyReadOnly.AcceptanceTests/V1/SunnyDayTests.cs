namespace MyReadOnly.AcceptanceTests.V1
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using MyReadOnly.WebApi;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using Xunit;

    public sealed class SunnyDayTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SunnyDayTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

    }
}