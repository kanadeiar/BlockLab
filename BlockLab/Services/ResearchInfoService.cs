namespace BlockLab.Services;

public class ResearchInfoService : IResearchInfoService
{
    private readonly BlockLabContext _context;
    public ResearchInfoService(BlockLabContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ResearchWebModel>> GetTop10Researches()
    {
        var models = new List<ResearchWebModel>();
        foreach (var r in await _context.Researches
                     .OrderByDescending(r => r.DateTime).Take(10)
                     .Include(r => r.TypeResearch)
                     .Include(r => r.ResearchObject)
                     .Include(r => r.LabAssistant)
                     .Include(r => r.WorkShift)
                     .ToArrayAsync())
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

    public async Task<ResearchWebModel> GetResearch(int id)
    {
        var r = await _context.Researches
            .Include(r => r.TypeResearch)
            .Include(r => r.ResearchObject)
            .Include(r => r.LabAssistant)
            .Include(r => r.WorkShift)
            .FirstOrDefaultAsync(r => r.Id == id);
        ResearchWebModel? model = null;
        if (r is BlockQualityResearch q)
        {
            model = new BlockQualityResearchWebModel
            {
                Format = q.Format,
                Trademark = q.Trademark,
                Weight = q.Weight,
                SizeX = q.SizeX,
                SizeY = q.SizeY,
                SizeZ = q.SizeZ,
                RawDensity = q.RawDensity,
                Coefficient = q.Coefficient,
                RawWeight = q.RawWeight,
                DriedWeight = q.DriedWeight,
                Humidity = q.Humidity,
                Load = q.Load,
                Strength = q.Strength,
                DriedDensity = q.DriedDensity,
            };
        }
        if (r is CementResearch c)
        {
            model = new CementResearchWebModel
            {
                Party = c.Party,
                PassportVc = c.PassportVc,
                PassportNsh = c.PassportNsh,
                PassportKsh = c.PassportKsh,
                ActualVc = c.ActualVc,
                ActualNsh = c.ActualNsh,
                ActualKsh = c.ActualKsh,
                FromName = c.FromName,
            };
        }
        if (r is HammerBinderResearch h)
        {
            model = new HammerBinderResearchWebModel
            {
                Sieve0_2 = h.Sieve0_2,
                Sufrace = h.Surface,
                Perfomance = h.Perfomance,
                Activiry = h.Activity,
            };
        }
        if (r is MudResearch m)
        {
            model = new MudResearchWebModel
            {
                Density = m.Density,
                Surface = m.Surface,
                Sieve0_8 = m.Sieve0_8,
                Sieve0_09 = m.Sieve0_09,
                Sieve0_045 = m.Sieve0_045,
                Gypsum = m.Gypsum,
                Humidity = m.Humidity,
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
        model.LabAssistantSurFP =
            $"{r.LabAssistant.SurName} {r.LabAssistant.FirstName[0]}.{r.LabAssistant.Patronymmic[0]}.";
        model.AssistantSurName = r.LabAssistant.SurName;
        model.AssistantFirstName = r.LabAssistant.FirstName;
        model.AssistantPatronymic = r.LabAssistant.Patronymmic;
        model.AssistantBirthday = r.LabAssistant.Birthday;
        model.WorkShiftName = r.WorkShift.Name;
        return model;
    }
}

