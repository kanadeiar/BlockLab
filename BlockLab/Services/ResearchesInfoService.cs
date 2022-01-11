using BlockLab.WebModels;

namespace BlockLab.Services;

public class ResearchesInfoService : IResearchesInfoService
{
    private readonly BlockLabContext _context;

    public ResearchesInfoService(BlockLabContext context)
    {
        _context = context;
    }

    public IEnumerable<ResearchWebModel> GetTop10Researches()
    {
        var models = new List<ResearchWebModel>();
        foreach (var r in _context.Researches.OrderByDescending(r => r.DateTime).Take(10)
                     .Include(r => r.TypeResearch)
                     .Include(r => r.ResearchObject)
                     .Include(r => r.LabAssistant)
                     .Include(r => r.WorkShift))
        {
            ResearchWebModel? model = null;
            if (r is BlockQualityResearch e)
            {
                model = new BlockQualityResearchWebModel
                {
                    Format = e.Format,
                    Trademark = e.Trademark,
                };
            }
            if (r is CementResearch c)
            {
                model = new CementResearchWebModel
                {
                    FromName = c.FromName,
                };
            }
            model ??= new ResearchWebModel();
            model.Id = r.Id;
            model.DateTime = r.DateTime;
            model.Name = r.Name;
            model.Value = r.Value;
            model.Text = r.Text;
            model.IsNormal = r.IsNormal;
            model.Note = r.Note;
            model.TypeResearchName = r.TypeResearch.Name;
            model.ResearchObjectName = r.ResearchObject.Name;
            model.LabAssistantSurFP = $"{r.LabAssistant.SurName} {r.LabAssistant.FirstName[0]}.{r.LabAssistant.Patronymmic[0]}.";
            model.WorkShiftName = r.WorkShift.Name;
            models.Add(model);
        }

        return models;
    }


}

