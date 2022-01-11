namespace BlockLab.Services;

public class ResearchInfoPagiService : IResearchInfoPagiService
{
    private readonly BlockLabContext _context;
    public ResearchInfoPagiService(BlockLabContext context)
    {
        _context = context;
    }

    public async Task<ResearchPagiWebModel> GetPagiFilterSortResearches(ResearchFilter filter)
    {
        IQueryable<Research> query = _context.Researches
            .Include(r => r.TypeResearch)
            .Include(r => r.ResearchObject)
            .Include(r => r.LabAssistant)
            .Include(r => r.WorkShift)
            .Where(r => !r.IsDelete);
        if (filter?.Name is { } name)
            query = query.Where(q => q.Name.Contains(name));
        if (filter?.TypeId is { } typeResearchId)
            query = query.Where(q => q.TypeResearchId == typeResearchId);
        if (filter?.IsNormal is { } isNormal)
            query = query.Where(q => q.IsNormal == isNormal);
        if (filter?.ObjId is { } researchObjId)
            query = query.Where(q => q.ResearchObjectId == researchObjId);
        query = filter.Order switch
        {
            ResearchSortState.DateAsc => query.OrderBy(q => q.DateTime),
            ResearchSortState.DateDesc => query.OrderByDescending(q => q.DateTime),
            ResearchSortState.NameAsc => query.OrderBy(q => q.Name),
            ResearchSortState.NameDesc => query.OrderByDescending(q => q.Name),
            ResearchSortState.TypeAsc => query.OrderBy(q => q.TypeResearch.Name),
            ResearchSortState.TypeDesc => query.OrderByDescending(q => q.TypeResearch.Name),
            ResearchSortState.ValueAsc => query.OrderBy(q => q.Value),
            ResearchSortState.ValueDesc => query.OrderByDescending(q => q.Value),
            ResearchSortState.NormalAsc => query.OrderBy(q => q.IsNormal),
            ResearchSortState.NormalDesc => query.OrderByDescending(q => q.IsNormal),
            ResearchSortState.AssistantAsc => query.OrderBy(q => q.LabAssistant),
            ResearchSortState.AssistantDesc => query.OrderByDescending(q => q.LabAssistant),
            _ => query.OrderByDescending(q => q.DateTime),
        };
        var count = await query.CountAsync();
        if (filter is { PageSize: > 0 and var pageSize, Page: > 0 and var page })
        {
            query = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
        var models = await query.Select(r => new ResearchWebModel
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
        return new ResearchPagiWebModel
        {
            Researches = models,
            Count = count,
        };
    }

}

