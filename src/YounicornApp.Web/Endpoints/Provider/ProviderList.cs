using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Web.Endpoints.ToDoItems
{
    public class ProviderList : BaseAsyncEndpoint<List<ProviderResponse>>
    {
        private readonly IProviderService _service;

        public ProviderList(IProviderService service)
        {
            _service = service;
        }

        [HttpGet("/ProviderList")]
        [SwaggerOperation(
            Summary = "Gets a list of all Provider",
            Description = "Gets a list of all Provider",
            OperationId = "Provider.List",
            Tags = new[] { "ProviderEndpoints" })
        ]
        public override async Task<ActionResult<List<ProviderResponse>>> HandleAsync()
        {
            var items = (await _service.GetItemsAsync())
                .Select(item => new ProviderResponse
                {
                    Id = item.Id,
                    Ispname = item.Ispname,
                    Displayname = item.Displayname,
                    Isprating = item.Isprating,
                });

            return Ok(items);
        }
    }
}
