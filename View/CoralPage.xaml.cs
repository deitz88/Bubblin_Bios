using Bubblin_Bios.ViewModel;

namespace Bubblin_Bios.View;

public partial class CoralPage : ContentPage
{
	public CoralPage()
	{
		InitializeComponent();
        this.BindingContext = new CoralPageViewModel();
    }
}
