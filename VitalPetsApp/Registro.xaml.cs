namespace VitalPetsApp;

public partial class Registro : ContentPage
{
    public Registro()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (newPasswordEntry.Text != confirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Las contrase�as no coinciden", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(newUserEntry.Text) || string.IsNullOrWhiteSpace(newPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Campos vac�os", "OK");
            return;
        }

        await DisplayAlert("Registro Exitoso", "Usuario creado correctamente", "OK");
        await Navigation.PopAsync(); // Regresa al Login
    }
}