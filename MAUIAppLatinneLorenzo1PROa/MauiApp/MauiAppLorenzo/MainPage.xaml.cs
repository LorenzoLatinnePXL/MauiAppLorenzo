namespace MauiAppLorenzo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            int totalPokemons = 151;
            List<int> pokemonIds = new List<int>();

            for (int i = 0; i < totalPokemons; i++)
            {
                pokemonIds.Add(i + 1);   
            }
            PokemonListView.ItemsSource = pokemonIds;
        }
    }

}
