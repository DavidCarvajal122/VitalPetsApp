using VitalPetsApp.Models;
using VitalPetsApp.Services;

namespace VitalPetsApp.Views
{
    public partial class MascotasPage : ContentPage
    {
        private readonly ApiService _apiService;

        public MascotasPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadMascotas();
        }

        private async void LoadMascotas()
        {
            var mascotas = await _apiService.GetMascotasAsync();
            MascotasListView.ItemsSource = mascotas;
        }

        private async void OnNuevaMascotaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevaMascotaPage());
        }
    }
}
