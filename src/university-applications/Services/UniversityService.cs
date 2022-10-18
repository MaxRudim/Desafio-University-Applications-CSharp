namespace university_applications.Services
{
  public class UniversityService : IUniversityService
  {
    private readonly HttpClient _client;
    public UniversityService(HttpClient httpClient)
    {
      _client = httpClient;
    }
  
    public async Task<object> FindUniversity(string name, string country)
    {
      var response = await _client.GetAsync($"http://universities.hipolabs.com/search?name={name}&country={country}");

      if (!response.IsSuccessStatusCode)
      {
        return null!;
      }

      var result = await response.Content.ReadFromJsonAsync<object>();

      if (result!.ToString() == "[]") return null!;

      else return result;
    }

    public async Task<object> FindUniversity(string country)
    {
      var response = await _client.GetAsync($"http://universities.hipolabs.com/search?country={country}");

      if (!response.IsSuccessStatusCode)
      {
        return null!;
      }

      var result = await response.Content.ReadFromJsonAsync<object>();

      if (result!.ToString() == "[]") return null!;
      
      else return result;
    }
  }
}
