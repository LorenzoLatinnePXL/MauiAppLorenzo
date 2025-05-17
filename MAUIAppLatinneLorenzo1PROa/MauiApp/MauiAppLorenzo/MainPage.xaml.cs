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
            Pokemons.Clear();

            var pokemons = await RestService.GetAllPokemonsAsync();

            foreach (var pokemon in pokemons)
            {
                Pokemons.Add(pokemon);
            }
        }

        private void OnPokemonTapped(object sender, EventArgs e)
        {
            if (sender is VisualElement visualElement && visualElement.BindingContext is Pokemon tappedPokemon)
            {
                
            }
        }
    }

}
