using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Result>> GetAllCharactersExcludingAlreadyBooked()
        {
            var client = _http.CreateClient("rick");

            CharacterModel modelAll;
            List<Result> allConverted;
            List<Result> booked;

            modelAll = await client.GetFromJsonAsync<CharacterModel>("character");
            allConverted = modelAll.results.ToList();
            booked = await _context.Notebooks.Include(x => x.Character).Select(x => x.Character).ToListAsync();

            var result = allConverted.Where(p => !booked.Any(p2 => p2.id == p.id)).ToList();

            return result;
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

        public async Task<CharacterModel> GoToPage(string pageNumber)
        {
            CharacterModel model;
            var client = _http.CreateClient("rick");

            try
            {
                model = await client.GetFromJsonAsync<CharacterModel>(pageNumber);
            }
            catch (Exception ex)
            {
                throw;
            }

            return model;
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