using Bubblin_Bios;

namespace Bubblin_Bios;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
    protected override void OnStart()
    {
        Resources.Add("ImageConverter", new ImageConverter());
    }
}

