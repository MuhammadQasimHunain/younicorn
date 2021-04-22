using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Interfaces;
using YounicornApp.Web.ApiModels;

namespace YounicornApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAccountService _service;

        public UserController(ILogger<UserController> logger, IAccountService service)
        {
            _logger = logger;
            _service = service;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ValidateCredentials(string userName, string password)
        {
            try
            {
                var user = await _service.ValidateCredentials(userName, password);
                var vm = UserItemDTO.FromUserItem(user);
                return new OkObjectResult(vm);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured: {Message}", e.Message);
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
