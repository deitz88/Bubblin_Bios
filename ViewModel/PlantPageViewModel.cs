using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Bubblin_Bios.ViewModel
{
    public class PlantViewModel : ObservableObject
    {
        private Model.Plant plant;
        private bool isDetailsExpanded = false;

        public PlantViewModel(Model.Plant plant)
        {
            this.plant = plant;
        }

        public Model.Plant Plant
        {
            get => this.plant;
            set => SetProperty(ref this.plant, value);
        }

        public string DisplayedDetails
        {
            get
            {
                var details = Plant.Details;
                return isDetailsExpanded ? details : details.Length > 500 ? details.Substring(0, 100) : details;
            }
        }

        public string DetailsMoreOrLessText
        {
            get
            {
                if(Plant.Details.Length > 300)
                {
                    return isDetailsExpanded ? "...less" : "...more";
                }
                else
                {
                    return null;
                }
            }
        }

        public ICommand OnMoreOrLessDetailsClicked => new RelayCommand(() =>
        {
            isDetailsExpanded = !isDetailsExpanded;
            OnPropertyChanged(nameof(DisplayedDetails));
            OnPropertyChanged(nameof(DetailsMoreOrLessText));
        });
    }

    public class PlantPageViewModel : ObservableObject
    {
        public ObservableCollection<PlantViewModel> PlantCollection { get; }

        public PlantPageViewModel()
        {
            var plantData = LoadPlantData();

            PlantCollection = new ObservableCollection<PlantViewModel>();

            foreach (var plant in plantData)
            {
                PlantCollection.Add(new PlantViewModel(plant));
            }
        }

        private ObservableCollection<Model.Plant> LoadPlantData()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using var stream = assembly.GetManifestResourceStream("Bubblin_Bios.Resources.Raw.Plant.json");
                if (stream == null)
                    return new ObservableCollection<Model.Plant>();

                using var reader = new StreamReader(stream);
                var jsonString = reader.ReadToEnd();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var plantList = JsonSerializer.Deserialize<ObservableCollection<Model.Plant>>(jsonString, options);

                return plantList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading plant data: {ex.Message}");
                return new ObservableCollection<Model.Plant>();
            }
        }

    }
}
