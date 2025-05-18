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

    private async void loginButton_Clicked(object sender, EventArgs e)
    {
        loginButton.IsEnabled = false;
        loginButton.IsVisible = false;
        registerButton.IsEnabled = false;
        registerButton.IsVisible = false;
        loadingIndicator.IsVisible = true;
        loadingIndicator.IsRunning = true;

        var loginRequest = new
        {
            Username = usernameEntry.Text,
            Password = passwordEntry.Text
        };

        try
        {
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
        catch (Exception ex)
        {
            await DisplayAlert("Something went wrong.", "Please try again later.", "Continue");
        }
        finally
        {
            loadingIndicator.IsRunning = false;
            loadingIndicator.IsVisible = false;
            loginButton.IsEnabled = true;
            loginButton.IsVisible = true;
            registerButton.IsEnabled = true;
            registerButton.IsVisible = true;
        }
    }


    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///RegisterPage");
    }
}