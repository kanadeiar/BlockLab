namespace BlockLab.WebModels;

public class ResearchPagiWebModel
{
    public IEnumerable<ResearchWebModel> Researches { get; set; }
    public int Count { get; set; }
    public void Deconstruct(out IEnumerable<ResearchWebModel> researches, out int count)
    {
        researches = Researches;
        count = Count;
    }
}

