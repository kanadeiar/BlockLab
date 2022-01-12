namespace BlockLab.WebModels;

public class BlockQualityResearchWebModel : ResearchWebModel
{
    public string Format { get; set; }
    public string Trademark { get; set; }
    public double Weight { get; set; }
    public double SizeX { get; set; }
    public double SizeY { get; set; }
    public double SizeZ { get; set; }
    public double RawDensity { get; set; }
    public double Coefficient { get; set; }
    public double RawWeight { get; set; }
    public double DriedWeight { get; set; }
    public double Humidity { get; set; }
    public double Load { get; set; }
    public double Strength { get; set; }
    public double DriedDensity { get; set; }
}