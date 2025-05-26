using Java.Util;

namespace VitalPetsApp;

public partial class MascotaRegistro : ContentPage
{
	public MascotaRegistro()
	{
		InitializeComponent();
	}
    // PetFormPage.xaml.cs
    public static List<Pet> Pets = new List<Pet>();

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        Pet newPet = new Pet
        {
            Name = nameEntry.Text,
            Species = speciesEntry.Text,
            Breed = breedEntry.Text,
            BirthDate = birthDatePicker.Date
        };

        Pets.Add(newPet);
        await DisplayAlert("Guardado", "Mascota registrada", "OK");
    }

    private async void OnViewPetsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PetListPage());
    }

}