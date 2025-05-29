using VitalPetsApp.Models;
using VitalPetsApp.Services;

namespace VitalPetsApp.Views
{
    public partial class NuevaMascotaPage : ContentPage
    {
        private readonly ApiService _apiService;

        public NuevaMascotaPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(NombreEntry.Text) || string.IsNullOrWhiteSpace(EspecieEntry.Text))
            {
                await DisplayAlert("Error", "Nombre y Especie son obligatorios.", "OK");
                return;
            }

            // Validar ID del usuario
            if (!int.TryParse(UsuarioIdEntry.Text, out int usuarioId))
            {
                await DisplayAlert("Error", "Debes ingresar un ID de usuario válido.", "OK");
                return;
            }

            // Crear el objeto Mascota
            var nuevaMascota = new Mascota
            {
                Nombre = NombreEntry.Text,
                Especie = EspecieEntry.Text,
                Raza = RazaEntry.Text,
                FechaNacimiento = FechaNacimientoPicker.Date,
                UsuarioId = usuarioId
            };

            // Intentar guardar usando el ApiService
            bool success = await _apiService.CrearMascotaAsync(nuevaMascota);

            if (success)
            {
                await DisplayAlert("Éxito", "Mascota registrada correctamente.", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar la mascota. Revisa los datos ingresados.", "OK");
            }
        }
    }
}
