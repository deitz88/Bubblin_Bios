using Bubblin_Bios.ViewModel;

namespace Bubblin_Bios.View
{
    public partial class FullScreenImagePage : ContentPage
    {
        public FullScreenImagePage(string imageUrl)
        {
            InitializeComponent();
            BindingContext = new FullScreenImageViewModel(imageUrl);
        }
    }
}
