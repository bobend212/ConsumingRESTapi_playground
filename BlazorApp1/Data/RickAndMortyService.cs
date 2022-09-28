using BlazorApp1.Models;
using RestSharp;

namespace BlazorApp1.Data
{
    public class RickAndMortyService
    {
        private readonly RestClient _client;
        private const string baseUrl = "https://rickandmortyapi.com/api/";

        public RickAndMortyService()
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<List<Result>> GetAllCharactersExcludingAlreadyBooked()
        {
            //var client = _http.CreateClient("rick");

            //CharacterModel modelAll;
            //List<Result> allConverted;
            //List<Result> booked;

            //modelAll = await client.GetFromJsonAsync<CharacterModel>("character");
            //allConverted = modelAll.results.ToList();
            //booked = await _context.Notebooks.Include(x => x.Character).Select(x => x.Character).ToListAsync();

            //var result = allConverted.Where(p => !booked.Any(p2 => p2.id == p.id)).ToList();

            return null;
        }

        public async Task<CharacterModel> GetAllCharacters()
        {
            CharacterModel model;

            try
            {
                model = await _client.GetJsonAsync<CharacterModel>("character");
            }
            catch (Exception ex)
            {
                throw;
            }

            return model;
        }

        public async Task<CharacterModel> SearchCharacter(string nameString)
        {
            CharacterModel model;

            try
            {
                var request = new RestRequest("character").AddParameter("name", nameString);
                model = await _client.GetAsync<CharacterModel>(request);
            }
            catch (Exception ex)
            {
                throw;
            }

            return model;
        }

        public async Task<Result> GetSingleCharacter(int id)
        {
            //Result result;
            //var client = _http.CreateClient("rick");

            //try
            //{
            //    result = await client.GetFromJsonAsync<Result>($"character/{id}");
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}

            return null;
        }

        public async Task<CharacterModel> GoToPage(string pageNumber)
        {
            //CharacterModel model;
            //var client = _http.CreateClient("rick");

            //try
            //{
            //    model = await client.GetFromJsonAsync<CharacterModel>(pageNumber);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}

            return null;
        }
    }
}