namespace BlockLab.WebModels;

public class ResearchWebModel
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public string Text { get; set; }
    public bool IsNormal { get; set; }
    public string? Note { get; set; }
    public string TypeResearchName { get; set; }
    public string ResearchObjectName { get; set; }
    public string LabAssistantSurFP { get; set; }
    public string WorkShiftName { get; set; }
}
public class BlockQualityResearchWebModel : ResearchWebModel
{
    public string Format { get; set; }
    public string Trademark { get; set; }
}
public class CementResearchWebModel : ResearchWebModel
{
    public string FromName { get; set; }
}

