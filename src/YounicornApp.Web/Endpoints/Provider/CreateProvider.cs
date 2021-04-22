using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Web.Endpoints.ToDoItems
{
    public class CreateProvider : BaseAsyncEndpoint<NewProviderRequest, ProviderResponse>
    {
        private readonly IProviderService _service;

        public CreateProvider(IProviderService service)
        {
            _service = service;
        }

        [HttpPost("/ToDoItems")]
        [SwaggerOperation(
            Summary = "Creates a new Provider",
            Description = "Creates a new Provider",
            OperationId = "ProviderItem.Create",
            Tags = new[] { "ToDoItemEndpoints" })
        ]
        public override async Task<ActionResult<ProviderResponse>> HandleAsync(NewProviderRequest request)
        {
            var item = new Provider
            {
                Ispname = request.Ispname,
                Displayname = request.Displayname,
                Isprating = request.Isprating
            };

            var createdItem = await _service.CreateProvider(item);

            return Ok(createdItem);
        }
    }
}
