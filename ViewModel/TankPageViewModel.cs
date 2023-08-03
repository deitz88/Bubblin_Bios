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
    public class FilterViewModel : ObservableObject
    {
        private Model.Filter filter;

        public FilterViewModel(Model.Filter filter)
        {
            this.filter = filter;
        }

        public Model.Filter Filter
        {
            get => this.filter;
            set => SetProperty(ref this.filter, value);
        }
    }

    public class TankViewModel : ObservableObject
    {
        private Model.Tank tank;
        private bool isDetailsExpanded = false;

        public TankViewModel(Model.Tank tank)
        {
            this.tank = tank;
            Filters = new ObservableCollection<FilterViewModel>();

            foreach (var filter in tank.Filter)
            {
                Filters.Add(new FilterViewModel(filter));
            }
        }

        public Model.Tank Tank
        {
            get => this.tank;
            set => SetProperty(ref this.tank, value);
        }

        public ObservableCollection<FilterViewModel> Filters { get; }

        public string DisplayedDetails
        {
            get
            {
                var details = Tank.Details;
                return isDetailsExpanded ? details : details.Length > 500 ? details.Substring(0, 100) : details;
            }
        }

        public string DetailsMoreOrLessText
        {
            get
            {
                if (Tank.Details.Length > 300)
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

    public class TankPageViewModel : ObservableObject
    {
        public ObservableCollection<TankViewModel> TankCollection { get; }

        public TankPageViewModel()
        {
            var tankData = LoadTankData();

            TankCollection = new ObservableCollection<TankViewModel>();

            foreach (var tank in tankData)
            {
                TankCollection.Add(new TankViewModel(tank));
            }
        }

        private ObservableCollection<Model.Tank> LoadTankData()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using var stream = assembly.GetManifestResourceStream("Bubblin_Bios.Resources.Raw.Tank.json");
                if (stream == null)
                    return new ObservableCollection<Model.Tank>();

                using var reader = new StreamReader(stream);
                var jsonString = reader.ReadToEnd();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var tankList = JsonSerializer.Deserialize<ObservableCollection<Model.Tank>>(jsonString, options);

                return tankList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tank data: {ex.Message}");
                return new ObservableCollection<Model.Tank>();
            }
        }
    }
}
