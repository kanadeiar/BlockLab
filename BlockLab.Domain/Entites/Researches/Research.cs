using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlockLab.Domain.Entites.Base;

namespace BlockLab.Domain.Entites
{
    /// <summary> Результат исследования </summary>
    public class Research : Entity
    {
        /// <summary> Дата и время </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;
        /// <summary> Название </summary>
        [Required(ErrorMessage = "Название исследования обязательно")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Название исследования должно быть длинной от 2 до 300 символов")]
        public string Name { get; set; }
        /// <summary> Главное значение - результат </summary>
        public double Value { get; set; }
        /// <summary> Текст результата исследования </summary>
        [Required(ErrorMessage = "Текстовый результат исследования обязателен")]
        [MaxLength(300, ErrorMessage = "Текст результата исследования не должен превышать 300 символов")]
        public string Text { get; set; }
        /// <summary> Результат - норма </summary>
        public bool IsNormal { get; set; }
        /// <summary> Примечание </summary>
        [MaxLength(300, ErrorMessage = "Примечание результата исследования не должен превышать 300 символов")]
        public string? Note { get; set; }

        /// <summary> Вид исследования </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Должен быть выбран вид исследования")]
        public int TypeResearchId { get; set; }
        [ForeignKey(nameof(TypeResearchId))]
        public TypeResearch TypeResearch { get; set; }
        /// <summary> Объект исследования </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Должен быть выбран объект исследования")]
        public int ResearchObjectId { get; set; }
        [ForeignKey(nameof(ResearchObjectId))]
        public ResearchObject ResearchObject { get; set; }

        /// <summary> Пользователь </summary>
        public string? UserId { get; set; }

        /// <summary> Рабочая смена </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Должена быть выбрана рабочая смена")]
        public int WorkShiftId { get; set; }
        [ForeignKey(nameof(WorkShiftId))]
        public WorkShift WorkShift { get; set; }
        /// <summary> Метка удаления </summary>
        public bool IsDelete { get; set; }
    }
}
