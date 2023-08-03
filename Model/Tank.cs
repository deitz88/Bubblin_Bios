namespace Bubblin_Bios.Model;

public class Tank
{
    public string Name { get; set; }
    public string Size { get; set; }
    public string Lighting { get; set; }
    public List<Filter> Filter { get; set; }
    public string Decor { get; set; }
    public string Temperature { get; set; }
    public string Details { get; set; }
}

public class Filter
{
    public string Name { get; set; }
    public string FlowRate { get; set; }
    public string Filtration { get; set; }
}
