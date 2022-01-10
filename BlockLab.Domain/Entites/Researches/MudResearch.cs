using System.ComponentModel.DataAnnotations.Schema;

namespace BlockLab.Domain.Entites
{
    /// <summary> Результат исследования шлама </summary>
    [Table("BlockQualityReearches")]
    public class MudResearch : Research
    {
        /// <summary> Плотность </summary>
        public double Density { get; set; }
        /// <summary> Поверхность </summary>
        public double Surface { get; set; }
        /// <summary> Сито 0_8 </summary>
        public double Sieve0_8 { get; set; }
        /// <summary> Сито 0_09 </summary>
        public double Sieve0_09 { get; set; }
        /// <summary> Сито 0_045 </summary>
        public double Sieve0_045 { get; set; }
        /// <summary> Содержание гипса </summary>
        public double Gypsum { get; set; }
        /// <summary> Влажность </summary>
        public double Humidity { get; set; }
    }
}
