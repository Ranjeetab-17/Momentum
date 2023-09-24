using System.ComponentModel.DataAnnotations;

namespace Converter.DataModel
{
    public class LengthConversion
    {
        [Key]
        public int Id { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }

        public decimal ImperialUnit { get; set; }
    }
}
