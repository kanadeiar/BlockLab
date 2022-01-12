using System.ComponentModel.DataAnnotations.Schema;

namespace BlockLab.Domain.Entites
{
    /// <summary> Молото-вяжущее исследование </summary>
    [Table("HammerBinderResearch")]
    public class HammerBinderResearch : Research
    {
        /// <summary> Остаток на сите 0_2 </summary>
        public double Sieve0_2 { get; set; }
        /// <summary> Поверхность </summary>
        public double Surface { get; set; }
        /// <summary> Производительность </summary>
        public double Perfomance { get; set; }
        /// <summary> Активность </summary>
        public double Activity { get; set; }
    }
}
