using System.Collections.ObjectModel;

namespace MauiAppLorenzo
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpclient;
        public ObservableCollection<int> PokemonIds { get; set; } = new ObservableCollection<int>();

        public MainPage()
        {
            _httpclient = new HttpClient();
            _httpclient.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
            InitializeComponent();
            BindingContext = this;
        }

        private void fetchPokemons_Clicked(object sender, EventArgs e)
        {
            PokemonIds.Clear();

            for (int i = 1; i <= 151; i++)
            {
                PokemonIds.Add(i);
            }
        }
    }

}
