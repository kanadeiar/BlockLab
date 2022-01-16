using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlockLab.Domain.Entites
{
    /// <summary> Результат исследования качества блоков </summary>
    [Table("BlockQualityReearches")]
    public class BlockQualityResearch : Research
    {
        /// <summary> Формат блока </summary>
        [Required(ErrorMessage = "Название формата блока обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название формата блока должно быть длинной от 2 до 100 символов")]
        public string Format { get; set; }

        /// <summary> Марка блока </summary>
        [Required(ErrorMessage = "Название марки блока обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название марки блока должно быть длинной от 2 до 100 символов")]
        public string Trademark { get; set; }
        /// <summary> Вес </summary>
        public double Weight { get; set; }
        /// <summary> Размер X </summary>
        public double SizeX { get; set; }
        /// <summary> Размер Y </summary>
        public double SizeY { get; set; }
        /// <summary> Размер Z </summary>
        public double SizeZ { get; set; }
        /// <summary> Плотность сырая </summary>
        public double RawDensity { get; set; }
        /// <summary> Коэффициент </summary>
        public double Coefficient { get; set; }
        /// <summary> Масса сырая </summary>
        public double RawWeight { get; set; }
        /// <summary> Масса сушеная </summary>
        public double DriedWeight { get; set; }
        /// <summary> Влажность </summary>
        public double Humidity { get; set; }
        /// <summary> Нагрузка </summary>
        public double Load { get; set; }
        /// <summary> Прочность </summary>
        public double Strength { get; set; }
        /// <summary> Плотность сушеная </summary>
        public double DriedDensity { get; set; }
    }
}
