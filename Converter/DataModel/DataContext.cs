using Microsoft.EntityFrameworkCore;

namespace Converter.DataModel
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options) { }

        public DbSet<LengthConversion> LengthConversions { get; set; }
    }
}
