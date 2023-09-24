using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModels
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DbSet<ConverterMaster> _master { get; set; }
    }
}
