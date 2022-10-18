using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace university_applications.Test;

public class UniversityIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
{
  private readonly HttpClient _client;

  public UniversityIntegrationTest(TestingWebAppFactory<Program> factory)
    => _client = factory.CreateClient();

  [Theory]
  [InlineData("Brazil", "federal")]
  [InlineData("Brazil", "acre")]

  public async Task ShouldFindAUniversityByCountryAndName(string country, string name)
  {
    var response = await _client.GetAsync($"university/{name}/{country}");

    response.StatusCode.Should().Be(HttpStatusCode.OK);

    var result = await response.Content.ReadFromJsonAsync<object>();

    result.Should().BeOfType<JsonElement>();
  }

  [Theory]
  [InlineData("Brazil")]
  [InlineData("Turkey")]
  public async Task ShouldFindAUniversityByCountry(string country)
  {
    var response = await _client.GetAsync($"/university/{country}");

    response.StatusCode.Should().Be(HttpStatusCode.OK);

    var result = await response.Content.ReadFromJsonAsync<object>();
    
    result.Should().BeOfType<JsonElement>();
  }
}