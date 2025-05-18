using MauiAppLorenzo.Services;
using Newtonsoft.Json;
using System.Text;

namespace MauiAppLorenzo;

public partial class LoginScreen : ContentPage
{
    public LoginScreen()
    {
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        var loginRequest = new
        {
            Username = usernameEntry.Text,
            Password = passwordEntry.Text
        };

        bool validLogin = await RestService.Login(loginRequest.Username, loginRequest.Password);

        if (validLogin)
        {
            await DisplayAlert("Logged in!", "Catch 'em all!", "Continue");
            await Shell.Current.GoToAsync("///MainPage");
        }
        else
        {
            await DisplayAlert("Failed to login.", "Invalid username and/or password.", "Continue");
        }
            passwordEntry.Text = "";
    }


    private void RegisterButton_Clicked(object sender, EventArgs e)
    {

    }
}