namespace MauiAppLorenzo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Sprint 4 – MAUI Android App:

            // MAUI UI / XAML:

            // [MAUI - 01]
            // TODO: Add ListView to display User records in XAML.

            // [MAUI - 02]
            // TODO: Use ListView.ItemTemplate and DataTemplate for dynamic record layout.

            // [MAUI - 03]
            // TODO: Bind Artist model properties to XAML using data binding.

            // [MAUI-04]
            // TODO: Add button in UI to trigger data fetch and populate ListView.

            //  RestService:

            // [MAUI-05] 
            //TODO: Create RestService class using HttpClient to call Web API.

            // [MAUI-06] 
            //TODO: Set up REST_URL constant with dev tunnel URL.

            // [MAUI-07] 
            //TODO: Use HttpClient.GetAsync() in RestService to retrieve data (async).

            // JSON Handling

            // [MAUI-08]
            // TODO: Use JsonConvert.SerializeObject in API Controller and DeserializeObject<T> in RestService.

            // Bonus Features (Optional)

            // [MAUI-09]
            // TODO: Display image or video per record in ListView using DataTemplate.

            // [MAUI - 10]
            // TODO: Add audio playback when clicking a record.
        }
    }
}
