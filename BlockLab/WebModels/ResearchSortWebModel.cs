using BlockLab.Domain.Models;

namespace BlockLab.WebModels
{
    /// <summary> Вебмодель сортировки </summary>
    public class ResearchSortWebModel
    {
        public ResearchSortState Date { get; set; } = ResearchSortState.DateAsc;
        public ResearchSortState Name { get; set; } = ResearchSortState.NameAsc;
        public ResearchSortState Type { get; set; } = ResearchSortState.TypeAsc;
        public ResearchSortState Value { get; set; } = ResearchSortState.ValueAsc;
        public ResearchSortState Normal { get; set; } = ResearchSortState.NormalAsc;
        public ResearchSortState Assistant { get; set; } = ResearchSortState.AssistantAsc;
        /// <summary> Текущий статус сортировки, устанавливаемый следующим </summary>
        public ResearchSortState Current { get; set; }
        /// <summary> Прошлый статус сортировки, уже установленный </summary>
        public ResearchSortState Previous { get; set; }
        /// <summary> Сотрировка по убыванию </summary>
        public bool Up { get; set; } = true;

        public ResearchSortWebModel(ResearchSortState order)
        {
            if (order == ResearchSortState.DateDesc || order == ResearchSortState.NameDesc || order == ResearchSortState.TypeDesc 
                || order == ResearchSortState.ValueDesc || order == ResearchSortState.NormalDesc || order == ResearchSortState.AssistantDesc) 
                Up = false;
            Previous = order;
            switch (order)
            {
                case ResearchSortState.DateDesc: Current = Date = ResearchSortState.DateAsc;
                    break;
                case ResearchSortState.NameAsc: Current = Name = ResearchSortState.NameDesc;
                    break;
                case ResearchSortState.NameDesc: Current = Name = ResearchSortState.NameAsc;
                    break;
                case ResearchSortState.TypeAsc: Current = Type = ResearchSortState.TypeDesc;
                    break;
                case ResearchSortState.TypeDesc: Current = Type = ResearchSortState.TypeAsc;
                    break;
                case ResearchSortState.ValueAsc: Current = Value = ResearchSortState.ValueDesc;
                    break;
                case ResearchSortState.ValueDesc: Current = Value = ResearchSortState.ValueAsc;
                    break;
                case ResearchSortState.NormalAsc: Current = Normal = ResearchSortState.NormalDesc;
                    break;
                case ResearchSortState.NormalDesc: Current = Normal = ResearchSortState.NormalAsc;
                    break;
                case ResearchSortState.AssistantAsc: Current = Assistant = ResearchSortState.AssistantDesc;
                    break;
                case ResearchSortState.AssistantDesc: Current = Assistant = ResearchSortState.AssistantAsc;
                    break;
                default: Current = Name = ResearchSortState.NameDesc;
                    break;
            }
        }
    }
}
