using System.Linq;
using System.Threading.Tasks;
using Xunit;
using YounicornApp.Core.Entities;
using YounicornApp.Infrastructure.Data;
using YounicornApp.UnitTests;

namespace YounicornApp.IntegrationTests.Data
{
    //public class EfRepositoryAdd : BaseEfRepoTestFixture<ToDoItem>
    //{
    //    [Fact]
    //    public async Task AddsItemAndSetsId()
    //    {
    //        var context = GetDbContext();
    //        var repository = new EfRepository<ToDoItem>(context);
            
    //        var item = new ToDoItemBuilder().Build();

    //        await repository.AddAsync(item);

    //        var newItem = (await repository.ListAsync())
    //                        .FirstOrDefault();

    //        Assert.Equal(item, newItem);
    //        Assert.True(newItem?.Id > 0);
    //    }
    //}
}
