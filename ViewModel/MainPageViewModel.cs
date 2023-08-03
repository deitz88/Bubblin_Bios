using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Bubblin_Bios.View;

namespace Bubblin_Bios.ViewModel
{
    public class FishViewModel : ObservableObject
    {

        // public ICommand OnImageClickedCommand { get; private set; }


        public FishViewModel(Model.Fish fish) // Removed navigation parameter as it's no longer needed
        {
            this.fish = fish;
            // OnImageClickedCommand = new Command<string>(async (imageUrl) => await OnImageClicked(navigation, imageUrl));
        }

        /*
        private async Task OnImageClicked(INavigation navigation, string imageUrl)
        {
            await navigation.PushAsync(new FullScreenImagePage(imageUrl));
        }
        */

        private Model.Fish fish;
        private bool isDietExpanded = false;
        private bool isDetailsExpanded = false;

        public Model.Fish Fish
        {
            get => this.fish;
            set => SetProperty(ref this.fish, value);
        }

        public string DisplayedDiet
        {
            get
            {
                var diet = Fish.Diet;
                return isDietExpanded ? diet : diet.Length > 100 ? diet.Substring(0, 100) : diet;
            }
        }

        public string DietMoreOrLessText
        {
            get
            {
                return isDietExpanded ? "...less" : "...more";
            }
        }

        public string DisplayedDetails
        {
            get
            {
                var details = Fish.Details;
                return isDetailsExpanded ? details : details.Length > 100 ? details.Substring(0, 100) : details;
            }
        }

        public string DetailsMoreOrLessText
        {
            get
            {
                return isDetailsExpanded ? "...less" : "...more";
            }
        }

        public ICommand OnMoreOrLessDietClicked => new RelayCommand(() =>
        {
            isDietExpanded = !isDietExpanded;
            OnPropertyChanged(nameof(DisplayedDiet));
            OnPropertyChanged(nameof(DietMoreOrLessText));
        });

        public ICommand OnMoreOrLessDetailsClicked => new RelayCommand(() =>
        {
            isDetailsExpanded = !isDetailsExpanded;
            OnPropertyChanged(nameof(DisplayedDetails));
            OnPropertyChanged(nameof(DetailsMoreOrLessText));
        });
    }

    public class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<FishViewModel> FishCollection { get; }

        //public MainPageViewModel(INavigation navigation) // Removed navigation parameter as it's no longer needed
        public MainPageViewModel() 
        {
            var fishData = LoadFishData();

            FishCollection = new ObservableCollection<FishViewModel>();

            foreach (var fish in fishData)
            {
                // FishViewModel constructor no longer needs navigation parameter
                //FishCollection.Add(new FishViewModel(fish, navigation));

                FishCollection.Add(new FishViewModel(fish));
            }
        }

        private ObservableCollection<Model.Fish> LoadFishData()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using var stream = assembly.GetManifestResourceStream("Bubblin_Bios.Resources.Raw.Fish.json");
                if (stream == null)
                    return new ObservableCollection<Model.Fish>();

                using var reader = new StreamReader(stream);
                var jsonString = reader.ReadToEnd();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var fishList = JsonSerializer.Deserialize<ObservableCollection<Model.Fish>>(jsonString, options);

                return fishList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading fish data: {ex.Message}");
                return new ObservableCollection<Model.Fish>();
            }
        }

    }
}
