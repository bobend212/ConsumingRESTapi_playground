using BlazorApp1.Models;
using static System.Net.WebRequestMethods;

namespace BlazorApp1.Data
{
    public class RickAndMortyService
    {
        private readonly IHttpClientFactory _http;
        private readonly DataContext _context;

        public RickAndMortyService(IHttpClientFactory http, DataContext context)
        {
            _http = http;
            _context = context;
        }

        public async Task<CharacterModel> GetAllCharacters()
        {
            CharacterModel model;
            var client = _http.CreateClient("rick");

            try
            {
                model = await client.GetFromJsonAsync<CharacterModel>("character");
            }
            catch (Exception ex)
            {
                throw;
            }

            return model;
        }

        public async Task<Result> GetSingleCharacter(int id)
        {
            Result result;
            var client = _http.CreateClient("rick");

            try
            {
                result = await client.GetFromJsonAsync<Result>($"character/{id}");
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public async Task<Notebook> PostNotebook(Notebook model)
        {
            try
            {
                _context.Notebooks.Add(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex);
                throw;
            }

            return model;
        }
    }
}