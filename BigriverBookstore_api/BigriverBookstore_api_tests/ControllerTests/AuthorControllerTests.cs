using Xunit;
using BigriverBookstore_api_tests.Helpers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BigriverBookstore_api_tests
{
    [Collection("WebHostCollection")]
    public class AuthorControllerTests : IClassFixture<TestFixture>
    {
        private readonly TestFixture _fixture;

        public AuthorControllerTests(TestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Can_Get_Authors()
        {
            // arrange
            var client = _fixture.Server.CreateClient();

            var httpMethod = new HttpMethod("GET");
            var route = $"/api/books";

            var request = new HttpRequestMessage(httpMethod, route);

            // act
            var response = await client.SendAsync(request);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task Can_Get_Author_By_Id()
        {
            // arrange
            var client = _fixture.Server.CreateClient();
            var bookId = 4;
            var httpMethod = new HttpMethod("GET");
            var route = $"/api/books/" + bookId.ToString();

            var request = new HttpRequestMessage(httpMethod, route);

            // act
            var response = await client.SendAsync(request);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
