using BookCllient.Models;
using System.Text.Json;

namespace BookCllient.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public BookService()
        //{

        //}
        
        //public async Task<IEnumerable<Book>> GetBooks()
        //{
        //    //var response = await _httpClient.GetAsync($"books");

        //    string url = $"https://localhost:7288/api/books";
        //    var response = await _httpClient.GetAsync($"https://localhost:7288/api/books");

        //    response.EnsureSuccessStatusCode();

        //    var responseStream = await response.Content.ReadAsStreamAsync();
        //    var responseObject = await JsonSerializer.DeserializeAsync<List<Book>>(responseStream);

        //    return responseObject ?? new List<Book>();
        //}
    }
}
