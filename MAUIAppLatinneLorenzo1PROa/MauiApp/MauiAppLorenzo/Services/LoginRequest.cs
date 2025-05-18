using System.Text.Json.Serialization;

namespace MauiAppLorenzo.Services
{
    internal class LoginRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}