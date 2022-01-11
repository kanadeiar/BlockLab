namespace BlockLab.Dal.Data;

/// <summary> Лабораторная база данных </summary>
public class BlockLabContext : DbContext
{
    /// <summary> Лаборанты </summary>
    public DbSet<LabAssistant> LabAssistants { get; set; }
    /// <summary> Объекты исследований </summary>
    public DbSet<ResearchObject> ResearchObjects { get; set; }
    /// <summary> Виды исследований </summary>
    public DbSet<TypeResearch> TypeResearches { get; set; }
    /// <summary> Рабочий смены </summary>
    public DbSet<WorkShift> WorkShifts { get; set; }

    /// <summary> Результаты исследований </summary>
    public DbSet<Research> Researches { get; set; }
    /// <summary> Результаты исследований качества блоков </summary>
    public DbSet<BlockQualityResearch> BlockQualityResearches { get; set; }
    /// <summary> Результаты исследований цемента </summary>
    public DbSet<CementResearch> CementResearches { get; set; }
    /// <summary> Результаты исследований молото-вяжущего </summary>
    public DbSet<HammerBinderResearch> HammerBinderResearches { get; set; }
    /// <summary> Результаты исследований шлама </summary>
    public DbSet<MudResearch> MudResearches { get; set; }

    public BlockLabContext(DbContextOptions<BlockLabContext> options) : base(options)
    { }
}

