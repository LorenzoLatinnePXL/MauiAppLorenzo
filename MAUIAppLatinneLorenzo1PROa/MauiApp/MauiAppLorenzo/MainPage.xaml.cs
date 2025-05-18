using ClassLib.Business.Entities;
using MauiAppLorenzo.Services;
using System.Collections.ObjectModel;

namespace MauiAppLorenzo
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Pokemon> Pokemons { get; set; } = new ObservableCollection<Pokemon>();

        public MainPage()
        {

            InitializeComponent();
            BindingContext = this;
        }

        private async void fetchPokemons_Clicked(object sender, EventArgs e)
        {
            fetchPokemons.IsEnabled = false;
            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;

            try
            {
                Pokemons.Clear();

                var pokemons = await RestService.GetAllPokemonsAsync();

                foreach (var pokemon in pokemons)
                {
                    Pokemons.Add(pokemon);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to fetch pokemons: {ex.Message}", "OK");
            }
            finally
            {
                loadingIndicator.IsRunning = false;
                loadingIndicator.IsVisible = false;
                fetchPokemons.IsEnabled = true;
            }
        }

        private void OnPokemonTapped(object sender, EventArgs e)
        {
            if (sender is VisualElement visualElement && visualElement.BindingContext is Pokemon tappedPokemon)
            {

            }
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");
            if (confirm)
            {
                await Shell.Current.GoToAsync("//LoginScreen");
            }
        }
    }
}
