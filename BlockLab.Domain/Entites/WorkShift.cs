using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BlockLab.Domain.Entites.Base;

namespace BlockLab.Domain.Entites
{
    /// <summary> Рабочая смена </summary>
    public class WorkShift : Entity
    {
        /// <summary> Название </summary>
        [Required(ErrorMessage = "Название рабочей смены обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название рабочей смены должно быть длинной от 2 до 100 символов")]
        public string Name { get; set; }
        /// <summary> Метка удаления </summary>
        public bool IsDelete { get; set; }
        /// <summary> Результаты исследований </summary>
        public virtual IEnumerable<Research> Researches { get; set; } = new List<Research>();
    }
}
