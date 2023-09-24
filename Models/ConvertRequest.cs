using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Converter.Enums;
 
namespace Converter.Model
{
    public class ConvertRequest
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public ConvertionType type { get; set; }
        public decimal value { get; set; }
    }
}