namespace VitalPetsApp;

public partial class ListaMascotas : ContentPage
{
	public ListaMascotas()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        petCollectionView.ItemsSource = PetFormPage.Pets;
    }

}