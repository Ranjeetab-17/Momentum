using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModels
{
    public class ConverterMaster
    {
        [Key]
        public int Id { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public decimal imperial { get; set; }
    }
}
