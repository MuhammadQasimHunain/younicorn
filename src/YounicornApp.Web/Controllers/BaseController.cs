using Microsoft.AspNetCore.Mvc;
using YounicornApp.Web.Filters;

namespace YounicornApp.Web.Controllers
{

    [ServiceFilter(typeof(ValidateModelAttribute))]
    public class BaseController : Controller
    {

    }
}