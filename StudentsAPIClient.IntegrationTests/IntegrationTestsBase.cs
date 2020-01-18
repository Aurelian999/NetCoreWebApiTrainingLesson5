using System;
using System.Net.Http;
using Xunit;

namespace StudentsAPIClient.IntegrationTests
{
    public class IntegrationTestsBase : IClassFixture<StudentsApiClientWebApplicationFactory<Startup>>
    {
        protected readonly StudentsApiClientWebApplicationFactory<Startup> factory;
        protected readonly HttpClient client;

        public IntegrationTestsBase(StudentsApiClientWebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44355/");
            client.DefaultRequestHeaders.Add("api-version", "2.0");
            client.DefaultRequestHeaders.Add("x-api-key", "123456");
            this.factory = factory;
        }

    }
}
