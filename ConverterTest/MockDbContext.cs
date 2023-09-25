using Converter.DataModel;
using DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;

public class MockDbContext
{
    public Mock<DataContext> Context { get; private set; }

    public MockDbContext()
    {
        // Create a new instance of the DbContextOptionsBuilder.
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        // Use an in-memory database for testing.
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        // Create a mock DbContext.
        Context = new Mock<DataContext>(optionsBuilder.Options);
    }

    // Use this method to set up DbSet<TEntity> mocks for your entities.
    public Mock<DbSet<TEntity>> CreateDbSetMock<TEntity>(IQueryable<TEntity> data) where TEntity : class
    {
        var dbSetMock = new Mock<DbSet<TEntity>>();

        dbSetMock.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(data.Provider);
        dbSetMock.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(data.Expression);
        dbSetMock.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
        dbSetMock.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        Context.Setup(c => c.Set<TEntity>()).Returns(dbSetMock.Object);

        return dbSetMock;
    }
}
