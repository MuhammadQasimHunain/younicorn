using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using YounicornApp.Infrastructure.Data;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.IntegrationTests.Data
{
    public abstract class BaseEfRepoTestFixture<T>
    {
        protected AppDbContext _dbContext;

        protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("younicornapp")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected AppDbContext GetDbContext()
        {
            var options = CreateNewContextOptions();
            var mockDispatcher = new Mock<IDomainEventDispatcher>();

            return new AppDbContext(options, mockDispatcher.Object);
        }
    }
}
