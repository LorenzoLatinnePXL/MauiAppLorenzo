using Newtonsoft.Json;
using System.Text;

namespace MauiAppLorenzo;

public partial class LoginScreen : ContentPage
{
    private readonly HttpClient _httpclient;

    public LoginScreen()
    {
        _httpclient = new HttpClient();
        _httpclient.BaseAddress = new Uri("https://j1qm04fb-7109.euw.devtunnels.ms/");
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        var loginRequest = new
        {
            Username = usernameEntry.Text,
            Password = passwordEntry.Text
        };

        var json = JsonConvert.SerializeObject(loginRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpclient.PostAsync("User/Login", content);
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Logged in!", "Catch 'em all!", "Continue");
                await Shell.Current.GoToAsync("///MainPage");
            }
            else
            {
                usernameEntry.Text = "Failed to log in.";
            }
        }
        catch (Exception ex)
        {
            usernameEntry.Text = "Login error: " + ex.Message;
        }
        passwordEntry.Text = "";
    }


    private void RegisterButton_Clicked(object sender, EventArgs e)
    {

    }
}