using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.Web.Endpoints.ToDoItems
{
    public class GetProviderById : BaseAsyncEndpoint<int, ProviderResponse>
    {
        private readonly IProviderService _service;

        public GetProviderById(IProviderService service)
        {
            _service = service;
        }

        [HttpGet("/Provider/{id:int}")]
        [SwaggerOperation(
            Summary = "Gets a single Provider",
            Description = "Gets a single Provider by Id",
            OperationId = "Provider.GetById",
            Tags = new[] { "ProviderEndpoints" })
        ]
        public override async Task<ActionResult<ProviderResponse>> HandleAsync(int id)
        {
            var item = await _service.GetProviderById(id);

            var response = new ProviderResponse
            {
               Id = item.Id,
               Ispname = item.Ispname,
               Displayname = item.Displayname,
               Isprating = item.Isprating
            };
            return Ok(response);
        }
    }
}
