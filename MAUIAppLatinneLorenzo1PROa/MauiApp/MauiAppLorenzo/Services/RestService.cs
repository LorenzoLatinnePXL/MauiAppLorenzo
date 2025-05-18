using Azure;
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
    public static class RestService
    {
        private static readonly HttpClient _httpclient = new HttpClient();
        private const string REST_URL = "https://j1qm04fb-7109.euw.devtunnels.ms";

        public static async Task<bool> Login(string username, string password)
        {
            LoginRequest request = new LoginRequest
            {
                Username = username,
                Password = password
            };

            string json = JsonSerializer.Serialize(request);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpclient.PostAsync(REST_URL + "/User/Login", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Could not login.", ex);
            }
        }

        public static async Task<bool> Register(string username, string email, string password)
        {
            RegisterRequest registerRequest = new RegisterRequest
            {
                Username = username,
                Email = email,
                Password = password
            };

            string json = JsonSerializer.Serialize(registerRequest);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpclient.PostAsync(REST_URL + "/User/Create-Account", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Could not register.", ex);
            }
        }

        public static async Task<List<Pokemon>> GetAllPokemonsAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpclient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=151");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    PokemonListResponse result = JsonSerializer.Deserialize<PokemonListResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    List<Pokemon> mapped = result.Results.Select(p => new Pokemon
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
