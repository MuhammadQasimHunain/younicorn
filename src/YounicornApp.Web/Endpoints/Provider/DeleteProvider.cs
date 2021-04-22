using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Web.Endpoints.ToDoItems
{
    public class DeleteProvider : BaseAsyncEndpoint<int, ProviderResponse>
    {
        private readonly IProviderService _service;

        public DeleteProvider(IProviderService service)
        {
            _service = service;
        }

        [HttpDelete("/Provier/{id:int}")]
        [SwaggerOperation(
            Summary = "Deletes a Provier",
            Description = "Deletes a Provier",
            OperationId = "Provier.Delete",
            Tags = new[] { "ProvierEndpoints" })
        ]
        public override async Task<ActionResult<ProviderResponse>> HandleAsync(int id)
        {
            var itemToDelete = await _service.GetProviderById(id);
            if (itemToDelete == null) return NotFound();

            await _service.DeleteProviderAsync(itemToDelete.Id);

            return NoContent();
        }
    }
}
