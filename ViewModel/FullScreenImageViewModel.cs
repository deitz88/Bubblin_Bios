using CommunityToolkit.Mvvm.ComponentModel;

namespace Bubblin_Bios.ViewModel
{
    public class FullScreenImageViewModel : ObservableObject
    {
        private string _imageUrl;

        public FullScreenImageViewModel(string imageUrl)
        {
            _imageUrl = imageUrl;
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }
    }
}
