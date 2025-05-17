using ClassLib.Business.Entities;
using MauiAppLorenzo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Exception = System.Exception;

namespace MauiAppLorenzo.Services
{
    public class RestService
    {
        private static readonly HttpClient _httpclient = new HttpClient();

        public RestService()
        {

        }

        public static async Task<List<Pokemon>> GetAllPokemonsAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpclient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=151");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<PokemonListResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    var mapped = result?.Results.Select(p => new Pokemon
                    {
                        Name = p.Name,
                        Id = ExtractIdFromUrl(p.Url)
                    }).ToList();

                    return mapped ?? new List<Pokemon>();
                }
                else
                {
                    throw new HttpRequestException($"Could not fetch pokemons: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with RestService: {ex.Message}");
                return new List<Pokemon>();
            }
        }

        private static string ExtractIdFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return "";
            return url.TrimEnd('/').Split('/').Last();
        }
    }
}
