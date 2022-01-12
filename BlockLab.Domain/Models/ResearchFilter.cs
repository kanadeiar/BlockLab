namespace BlockLab.Domain.Models
{
    /// <summary> Фильтр по результатам исследований </summary>
    public class ResearchFilter
    {
        public string? Name { get; set; }
        public int? TypeId { get; set; }
        public bool? IsNormal { get; set; }
        public int? ObjId { get; set; }
        public ResearchSortState Order { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
