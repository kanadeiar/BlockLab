namespace BlockLab.WebModels;

public class CementResearchWebModel : ResearchWebModel
{
    public string Party { get; set; }
    public double PassportVc { get; set; }
    public double PassportNsh { get; set; }
    public double PassportKsh { get; set; }
    public double ActualVc { get; set; }
    public double ActualNsh { get; set; }
    public double ActualKsh { get; set; }
    public string FromName { get; set; }
}