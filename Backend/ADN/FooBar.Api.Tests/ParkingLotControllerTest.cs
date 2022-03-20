using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FooBar.Application.Person.Queries;
using Xunit;

namespace FooBar.Api.Tests
{
    public class ParkingLotControllerTest
    {
        IntegrationTestBuilder _builder;
        HttpClient _client = default!;

        public ParkingLotControllerTest()
        {
            _builder = new IntegrationTestBuilder();
            _client = _builder.CreateClient();
        }

        [Fact]
        public async Task PostPersonSuccess()
        {
            var postContent = new FooBar.Application.Person.Commands.ParkingLotCreateCommand
            (
               1, "abc-999", DateTime.Now, 2000
            );
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(postContent), System.Text.Encoding.UTF8, "text/json");
            var c = await _client.PostAsync("api/Parking", content);
            c.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, c.StatusCode);
        }


        [Fact]
        public async Task GetParkingLotFailure()
        {
            var c = await _client.GetAsync($"api/Parking/{Guid.NewGuid()}");
            c.EnsureSuccessStatusCode();
            var response = await c.Content.ReadAsStringAsync();
            Assert.Throws<System.Text.Json.JsonException>(() =>
                System.Text.Json.JsonSerializer.Deserialize<ParkingLotDto>(response));
        }

        [Fact]
        public async Task GetParkingLotBadRequestFailure()
        {
            var c = await _client.GetAsync($"api/Parking/foobar");
            Assert.Throws<System.Net.Http.HttpRequestException>(() => c.EnsureSuccessStatusCode());
        }
    }
}
