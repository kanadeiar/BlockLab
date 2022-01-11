using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlockLab.Domain.Entites.Base;

namespace BlockLab.Domain.Entites
{
    /// <summary> Вид исследования </summary>
    public class TypeResearch : Entity
    {
        /// <summary> Название </summary>
        [Required(ErrorMessage = "Название объекта исследования обязательно")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Название объекта исследования должно быть длинной от 2 до 300 символов")]
        public string Name { get; set; }
        /// <summary> Вид исследования </summary>
        public ItTypeResult TypeResult { get; set; }
        /// <summary> Метка удаления </summary>
        public bool IsDelete { get; set; }
        /// <summary> Результаты исследований </summary>
        public virtual IEnumerable<Research> Researches { get; set; } = new List<Research>();

        /// <summary> Тип </summary>
        public enum ItTypeResult
        {
            /// <summary> Простое исследование - цифра и текст </summary>
            Simple = 0,

            /// <summary> Контроль качества блоков </summary>
            BlockQualityResearch,

            /// <summary> Исследование шлама </summary>
            MudResearch,

            /// <summary> Исследование цемента </summary>
            CementReseatch,

            /// <summary> Исследование молото-вяжущего </summary>
            HammerBinderResearch,
        }
    }
}
