using BlockLab.Domain.Models;

namespace BlockLab.WebModels
{
    public class ResearchFilterSortPagiWebModel
    {
        public ResearchFilter Filter { get; set; }
        public ResearchSortWebModel Sort { get; set; }
        public PagiWebModel Pagi { get; set; } 
        public IEnumerable<ResearchWebModel> Researches { get; set; }
    }
}
