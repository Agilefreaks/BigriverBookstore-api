using Xunit;
using BigriverBookstore_api.Models;
using BigriverBookstore_api_tests.Helpers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JsonApiDotNetCore.Serialization;


namespace BigriverBookstore_api_tests
{
    [Collection("WebHostCollection")]
    public class BookServiceTests : IClassFixture<TestFixture>
    {
        private readonly TestFixture _fixture;

        public BookServiceTests(TestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Can_Get_Books()
        {
            // arrange
            var client = _fixture.Server.CreateClient();

            var httpMethod = new HttpMethod("GET");
            var route = $"/api/books";

            var request = new HttpRequestMessage(httpMethod, route);

            // act
            var response = await client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            var deserializedBody = _fixture.Server.GetService<IJsonApiDeSerializer>()
                .DeserializeList<Book>(responseBody);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(deserializedBody);
            Assert.NotEmpty(deserializedBody);
            Assert.Equal(5, deserializedBody.Count);
        }


        [Fact]
        public async Task Can_Get_Books_By_Id()
        {
            // arrange
            var client = _fixture.Server.CreateClient();
            var bookId = 4;
            var httpMethod = new HttpMethod("GET");
            var route = $"/api/books/" + bookId.ToString();

            var request = new HttpRequestMessage(httpMethod, route);

            // act
            var response = await client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            var deserializedBody = _fixture.Server.GetService<IJsonApiDeSerializer>()
                .Deserialize<Book>(responseBody);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(deserializedBody);
            Assert.Equal(bookId, deserializedBody.Id);
        }
    }
}
