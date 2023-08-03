using System.Text.Json.Serialization;
using Bubblin_Bios.ViewModel;

namespace Bubblin_Bios.Model;

public class Fish
{
    public string Name { get; set; }
    public string ScientificName { get; set; }
    public string Size { get; set; }
    public string Diet { get; set; }
    public string Location { get; set; }
    public string Details { get; set; }
    public string Image { get; set; }
    public ImageSource ImageSource
    {
        get
        {
            return ImageSource.FromResource(Image, typeof(MainPageViewModel).Assembly);
        }
    }
}
