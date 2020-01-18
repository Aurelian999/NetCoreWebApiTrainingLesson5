using StudentsAPIClient.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace StudentsAPIClient.IntegrationTests
{
    public class StudentsStatisticsControllerTests : IntegrationTestsBase
    {

        public StudentsStatisticsControllerTests(StudentsApiClientWebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        async Task Test()
        {
            var response = await client.GetAsync("clientapi/studentsstatistics");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        async Task TestStudentsCount()
        {
            var response = await client.GetAsync("clientapi/studentsstatistics");
            using var responseStream = await response.Content.ReadAsStreamAsync();

            List<StudentStatistics> studentStatistics = await JsonSerializer.DeserializeAsync<List<StudentStatistics>>(responseStream);
            
            Assert.Equal(5, studentStatistics.Count);
            Assert.Equal(3, studentStatistics.Where(s => s.Commits > 0).Count());
        }

    }
}
