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
    public class CoralViewModel : ObservableObject
    {
        private Model.Coral coral;
        private bool isDetailsExpanded = false;

        public CoralViewModel(Model.Coral coral)
        {
            this.coral = coral;
        }

        public Model.Coral Coral
        {
            get => this.coral;
            set => SetProperty(ref this.coral, value);
        }

        public string DisplayedDetails
        {
            get
            {
                var details = Coral.Details;
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

        public ICommand OnMoreOrLessDetailsClicked => new RelayCommand(() =>
        {
            isDetailsExpanded = !isDetailsExpanded;
            OnPropertyChanged(nameof(DisplayedDetails));
            OnPropertyChanged(nameof(DetailsMoreOrLessText));
        });
    }

    public class CoralPageViewModel : ObservableObject
    {
        public ObservableCollection<CoralViewModel> CoralCollection { get; }

        public CoralPageViewModel()
        {
            var coralData = LoadCoralData();

            CoralCollection = new ObservableCollection<CoralViewModel>();

            foreach (var coral in coralData)
            {
                CoralCollection.Add(new CoralViewModel(coral));
            }
        }

        private ObservableCollection<Model.Coral> LoadCoralData()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using var stream = assembly.GetManifestResourceStream("Bubblin_Bios.Resources.Raw.Coral.json");
                if (stream == null)
                    return new ObservableCollection<Model.Coral>();

                using var reader = new StreamReader(stream);
                var jsonString = reader.ReadToEnd();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var coralList = JsonSerializer.Deserialize<ObservableCollection<Model.Coral>>(jsonString, options);

                return coralList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading coral data: {ex.Message}");
                return new ObservableCollection<Model.Coral>();
            }
        }
    }
}
