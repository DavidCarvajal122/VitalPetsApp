namespace VitalPetsApp;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
	}
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); 
    }

}