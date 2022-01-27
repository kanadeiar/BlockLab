namespace BlockLab.Services;

public class ResearchInfoPagiService : IResearchInfoPagiService
{
    private readonly BlockLabContext _context;
    private readonly UserManager<User> _userManager;
    public ResearchInfoPagiService(BlockLabContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<ResearchPagiWebModel> GetPagiFilterSortResearches(ResearchFilter filter)
    {
        IQueryable<Research> query = _context.Researches
            .Include(r => r.TypeResearch)
            .Include(r => r.ResearchObject)
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
            ResearchSortState.AssistantAsc => query.OrderBy(q => q.UserId),
            ResearchSortState.AssistantDesc => query.OrderByDescending(q => q.UserId),
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
            LabAssistantSurFP = r.UserId,
            WorkShiftName = r.WorkShift.Name,
        }).ToArrayAsync();
        foreach (var item in models)
        {
            var user = await _userManager.FindByIdAsync(item.LabAssistantSurFP);
            item.LabAssistantSurFP = $"{user.SurName} {user.FirstName[0]}.{user.Patronymic[0]}.";
        };
        return new ResearchPagiWebModel
        {
            Researches = models,
            Count = count,
        };
    }

}

