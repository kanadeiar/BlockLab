using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlockLab.Domain.Entites.Base;

namespace BlockLab.Domain.Entites
{
    /// <summary> Объект исследования </summary>
    public class ResearchObject : Entity
    {
        /// <summary> Название </summary>
        [Required(ErrorMessage = "Название объекта исследования обязательно")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Название объекта исследования должно быть длинной от 2 до 300 символов")]
        public string Name { get; set; }
        /// <summary> Метка удаления </summary>
        public bool IsDelete { get; set; }
        /// <summary> Результаты исследований </summary>
        public virtual IEnumerable<Research> Researches { get; set; } = new List<Research>();
    }
}
