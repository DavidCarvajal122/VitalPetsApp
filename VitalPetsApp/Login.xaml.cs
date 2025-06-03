using VitalPetsApp.Views;

namespace VitalPetsApp;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string user = usernameEntry.Text;
        string pass = passwordEntry.Text;

        
        if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass))
        {
            await DisplayAlert("Bienvenido", $"Hola {user}", "OK");
            await Navigation.PushAsync(new NuevaMascotaPage());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña inválidos", "OK");
        }
    }

    private async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Registro());
    }

}