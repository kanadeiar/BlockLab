using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlockLab.Domain.Entites.Base;

namespace BlockLab.Domain.Entites
{
    /// <summary> Лаборант </summary>
    public class LabAssistant : Entity
    {
        /// <summary> Фамилия </summary>
        [Required(ErrorMessage = "Фамилия лаборанта обязательна")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Фамилия лаборанта должна быть длинной от 2 до 60 символов")]
        public string SurName { get; set; }
        /// <summary> Имя </summary>
        [Required(ErrorMessage = "Имя лаборанта обязательна")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Имя лаборанта должна быть длинной от 2 до 60 символов")]
        public string FirstName { get; set; }
        /// <summary> Отчество </summary>
        [Required(ErrorMessage = "Отчество лаборанта обязательна")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Отчество лаборанта должна быть длинной от 2 до 60 символов")]
        public string Patronymmic { get; set; }
        /// <summary> Дата рождения лаборанта </summary>
        public DateTime Birthday { get; set; } = DateTime.Today.AddYears(-18);
        /// <summary> Лаборант неактивный </summary>
        public bool IsInactive { get; set; }
        /// <summary> Результаты исследований </summary>
        public virtual IEnumerable<Research> Researches { get; set; } = new List<Research>();
    }
}
