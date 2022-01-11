namespace BlockLab.Services;

public class ResearchInfoPagiService : IResearchInfoPagiService
{
    private readonly BlockLabContext _context;
    public ResearchInfoPagiService(BlockLabContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ResearchWebModel>> GetPagiFilterResearches()
    {
        var models = await _context.Researches.OrderByDescending(r => r.DateTime)
            .Include(r => r.TypeResearch)
            .Include(r => r.ResearchObject)
            .Include(r => r.LabAssistant)
            .Include(r => r.WorkShift).Select(r => new ResearchWebModel
            {
                Id = r.Id,
                DateTime = r.DateTime,
                Name = r.Name,
                Value = r.Value,
                Text = r.Text,
                IsNormal = r.IsNormal,
                Note = r.Note,
                TypeResearchName = r.TypeResearch.Name,
                ResearchObjectName = r.ResearchObject.Name,
                LabAssistantSurFP = $"{r.LabAssistant.SurName} {r.LabAssistant.FirstName[0]}.{r.LabAssistant.Patronymmic[0]}.",
                WorkShiftName = r.WorkShift.Name,
            }).ToArrayAsync();
        return models;
    }
}

