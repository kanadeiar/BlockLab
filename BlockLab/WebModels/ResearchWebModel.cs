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
    public string AssistantSurName { get; set; }
    public string AssistantFirstName { get; set; }
    public string AssistantPatronymic { get; set; }
    public DateTime AssistantBirthday { get; set; }
    public string WorkShiftName { get; set; }
}