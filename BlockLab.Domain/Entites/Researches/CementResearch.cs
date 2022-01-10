using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlockLab.Domain.Entites
{
    /// <summary> Результаты исследования цемента </summary>
    [Table("CementResearch")]
    public class CementResearch : Research
    {
        /// <summary> Номер партии </summary>
        [Required(ErrorMessage = "Название номера партии обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название номера партии должно быть длинной от 2 до 100 символов")]
        public string Party { get; set; }

        /// <summary> Паспорт В/ц </summary>
        public double PassportVc { get; set; }

        /// <summary> Паспорт н/сх </summary>
        public double PassportNsh { get; set; }

        /// <summary> Паспорт к/сх </summary>
        public double PassportKsh { get; set; }

        /// <summary> Фактическое в/ц </summary>
        public double ActualVc { get; set; }

        /// <summary> Фактическое Н/сх </summary>
        public double ActualNsh { get; set; }

        /// <summary> Фактическое К/сх </summary>
        public double ActualKsh { get; set; }

        /// <summary> Откуда </summary>
        [Required(ErrorMessage = "Значение откуда привезен цементи обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Значение откуда привезен цемент должно быть длинной от 2 до 100 символов")]
        public string? FromName { get; set; }
    }
}
