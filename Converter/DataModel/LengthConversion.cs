using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Converter.DataModel
{
    public class LengthConversion
    {
        [Key]
        public int Id { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal ImperialUnit { get; set; }
    }
}
