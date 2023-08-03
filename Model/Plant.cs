using System.Text.Json.Serialization;

namespace Bubblin_Bios.Model;

public class Plant
{
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
    public string Size { get; set; }
    public string Location { get; set; }
    public string Details { get; set; }
    public string Image { get; set; }
}
