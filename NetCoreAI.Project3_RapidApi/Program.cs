using NetCoreAI.Project3_RapidApi.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;



var client = new HttpClient();
List<ApiSeriesViewModels> apiSeriesViewModels = new List<ApiSeriesViewModels>();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
    Headers =
    {
        { "x-rapidapi-key", "ac1730617amsh8915e9f2060f935p1f8fa0jsne2271912d3ed" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    apiSeriesViewModels = JsonConvert.DeserializeObject<List<ApiSeriesViewModels>>(body);
    foreach (var series in apiSeriesViewModels)
    {
        Console.WriteLine(series.rank + "-" + series.title + "-Film Puanı: " + series.rating + "-Yapım Yılı: " + series.year);
    }
}

Console.ReadLine();