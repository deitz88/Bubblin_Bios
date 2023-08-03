namespace Bubblin_Bios.View;

public partial class TankPage : ContentPage
{
	public TankPage()
	{
		InitializeComponent();
        this.BindingContext = new ViewModel.TankPageViewModel();
    }
}
