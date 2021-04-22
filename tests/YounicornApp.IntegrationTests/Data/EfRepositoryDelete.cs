using System;
using System.Threading.Tasks;
using Xunit;
using YounicornApp.Core.Entities;
using YounicornApp.Infrastructure.Data;
using YounicornApp.UnitTests;

namespace YounicornApp.IntegrationTests.Data
{
    //public class EfRepositoryDelete : BaseEfRepoTestFixture<ToDoItem>
    //{
    //    [Fact]
    //    public async Task DeletesItemAfterAddingIt()
    //    {
    //        // add an item
    //        var context = GetDbContext();
    //        var repository = new EfRepository<ToDoItem>(context);
    //        var initialTitle = Guid.NewGuid().ToString();
    //        var item = new ToDoItemBuilder().Title(initialTitle).Build();
    //        await repository.AddAsync(item);

    //        // delete the item
    //        await repository.DeleteAsync(item);

    //        // verify it's no longer there
    //        Assert.DoesNotContain(await repository.ListAsync(),
    //            i => i.Title == initialTitle);
    //    }
    //}
}
