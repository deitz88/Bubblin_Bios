using Bubblin_Bios.View;
using Bubblin_Bios.ViewModel;

namespace Bubblin_Bios.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        //public void OnImageTapped(object sender, EventArgs e)
        //{
        //    if (sender is Image image && image.Source is UriImageSource uriImageSource)
        //    {
        //        Navigation.PushAsync(new FullScreenImagePage(uriImageSource.Uri.ToString()));
        //    }
        //}

    }

}
