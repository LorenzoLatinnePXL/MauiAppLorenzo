using MauiAppLorenzo.Services;

namespace MauiAppLorenzo;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(usernameEntry.Text) ||
            string.IsNullOrWhiteSpace(emailEntry.Text) ||
            string.IsNullOrWhiteSpace(passwordEntry.Text) ||
            string.IsNullOrWhiteSpace(confirmPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        if (passwordEntry.Text != confirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        RegisterButton.IsEnabled = false;
        loadingIndicator.IsVisible = true;
        loadingIndicator.IsRunning = true;

        try
        {
            bool success = await RestService.Register(
                usernameEntry.Text.Trim(),
                emailEntry.Text.Trim(),
                passwordEntry.Text);

            if (success)
            {
                await DisplayAlert("Success", "Account created! Please login.", "OK");
                await Shell.Current.GoToAsync("///LoginScreen");
            }
            else
            {
                await DisplayAlert("Failed", "Could not create account. Try again.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
        finally
        {
            loadingIndicator.IsRunning = false;
            loadingIndicator.IsVisible = false;
            RegisterButton.IsEnabled = true;
        }
    }

    private async void BackToLoginButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginScreen");
    }
}