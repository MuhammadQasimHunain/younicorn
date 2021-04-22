using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Web.Endpoints.ToDoItems
{
    public class UpdateProvider : BaseAsyncEndpoint<UpdateProviderRequest, ProviderResponse>
    {
        private readonly IProviderService _service;

        public UpdateProvider(IProviderService service)
        {
            _service = service;
        }

        [HttpPut("/Provider")]
        [SwaggerOperation(
            Summary = "Updates a Provider",
            Description = "Updates a Provider with a longer description",
            OperationId = "Provider.Update",
            Tags = new[] { "ProviderEndpoints" })
        ]
        public override async Task<ActionResult<ProviderResponse>> HandleAsync(UpdateProviderRequest request)
        {
            var existingItem = await _service.GetProviderById(request.Ispid);

            existingItem.Ispname = request.Ispname;
            existingItem.Displayname = request.Displayname;
            existingItem.Isprating = request.Isprating;

            await _service.UpdateProvider(existingItem);

            var response = new ProviderResponse
            {
                Id = existingItem.Id,
                Ispname = existingItem.Ispname,
                Displayname = existingItem.Displayname,
                Isprating = existingItem.Isprating
            };
            return Ok(response);
        }
    }
}
