using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CinematicLibrary.ApiClient
{
    public class MovieApiClient<T>
    {
        private readonly HttpClient client;
        private readonly string MOVIE_API_URL = "https://flixster.p.rapidapi.com/movies/get-upcoming";
        private readonly string API_KEY= "0b6b6b43d2msh5ca1d24e0b4982dp1490c5jsn1e9aaa1f86c8";

        public MovieApiClient()
        {
            client = new();

        }

        public MovieApiClient(IConfiguration configuration) : this()
        {
            MOVIE_API_URL = "https://flixster.p.rapidapi.com/movies/get-upcoming";
            API_KEY = "0b6b6b43d2msh5ca1d24e0b4982dp1490c5jsn1e9aaa1f86c8";
        }

        public async Task<List<T>> GetMovies()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(MOVIE_API_URL),
                Headers =
            {
                { "X-RapidAPI-Key", API_KEY },
                { "X-RapidAPI-Host", "flixster.p.rapidapi.com" },
            },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return CreateMoviesFromJson(body);
        }

        public List<T> CreateMoviesFromJson(string json)
        {
            var res = JsonConvert.DeserializeObject<Response<T>>(json);
            return res?.data?.upcoming!;
        }
    }
}
