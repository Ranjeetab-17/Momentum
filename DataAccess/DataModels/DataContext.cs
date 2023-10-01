using Converter.DataModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataModels
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<LengthConversion> LengthConversions { get; set; }
    }
}
