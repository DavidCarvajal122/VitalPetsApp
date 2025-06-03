namespace VitalPetsApp;

public partial class Registro : ContentPage
{
    public Registro()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(newUserEntry.Text) ||
            string.IsNullOrWhiteSpace(newPasswordEntry.Text) ||
            string.IsNullOrWhiteSpace(confirmPasswordEntry.Text) ||
            string.IsNullOrWhiteSpace(phoneEntry.Text) ||
            string.IsNullOrWhiteSpace(emailEntry.Text))
        {
            await DisplayAlert("Error", "Por favor complete todos los campos", "OK");
            return;
        }

        if (newPasswordEntry.Text != confirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
            return;
        }

        await DisplayAlert("Registro Exitoso", "Usuario creado correctamente", "OK");


        await Navigation.PopAsync();
    }
}
