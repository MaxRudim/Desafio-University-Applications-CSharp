using Moq;
using university_applications.Services;
using System.Text.Json;

namespace university_applications.Test;

public class UniversityServiceTest
{

  [Fact]
  public async Task ShouldReturnUniversityByCountryAndName()
  {
    var mockClient = new Mock<HttpClient>();

    var universityService = new UniversityService(mockClient.Object);

    var result = await universityService.FindUniversity("middle", "turkey");

    result.Should().BeOfType<JsonElement>();
    result.ToString().Should().Contain("web_page");
    result.ToString().Should().Contain("country");
    result.ToString().Should().Contain("domain");
    result.ToString().Should().Contain("name");
  }

  [Fact]
  public async Task ShouldReturnAUniversityByCountry()
  {
    var mockClient = new Mock<HttpClient>();

    var universityService = new UniversityService(mockClient.Object);

    var result = await universityService.FindUniversity("turkey");

    result.Should().BeOfType<JsonElement>();
    result.ToString().Should().Contain("web_page");
    result.ToString().Should().Contain("country");
    result.ToString().Should().Contain("domain");
    result.ToString().Should().Contain("name");
  }
}

