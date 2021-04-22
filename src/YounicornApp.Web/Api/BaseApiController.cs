using Microsoft.AspNetCore.Mvc;

namespace YounicornApp.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
