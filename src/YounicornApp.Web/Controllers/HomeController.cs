using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Interfaces;
using YounicornApp.Web.ApiModels;
using YounicornApp.Web.Filters;

namespace YounicornApp.Web.Controllers
{

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIspOfferService _service;
        private readonly ISignUpService _signUpService;
        private readonly IProviderService _providerService;

        public HomeController(ILogger<HomeController> logger, IIspOfferService service, ISignUpService signUpService, IProviderService providerService)
        {
            _logger = logger;
            _service = service;
            _signUpService = signUpService;
            _providerService = providerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult ProviderInfo()
        {
            return View();
        }
        public IActionResult Plan()
        {
            return View();
        }

        public async Task<IActionResult> Compare(string id)
        {
            ViewBag.address = id;
            var items = (await _service.GetItemsAsync())
                              .Select(IspOfferItemDTO.FromIspOfferItem)
                              .ToList();
            ViewBag.totalItems = items.Count();
            return View(items);

        }


        public async Task<IActionResult> SearchResult(string search, string id)
        {

            ViewBag.address = id;
            var items = (await _service.GetItemsAsync()).Where(u => u.Offername.Contains(search))
                            .Select(IspOfferItemDTO.FromIspOfferItem)
                            .ToList();
            ViewBag.totalItems = items.Count();
            return View("Compare", items);
        }

        [HttpGet]
        public async Task<IActionResult> MoreInfo(int id)
        {
            if (id <= 0) return View();

            return View(IspOfferItemDTO.FromIspOfferItem(await _service.GetOfferById(id)));
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignUp(int id)
        {
            if (id <= 0) return View(IspOfferItemDTO.FromIspOfferItem());

            return View(IspOfferItemDTO.FromIspOfferItem(await _service.GetOfferById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSignUp(string firstName, string lastName, string email, string phone, int offerId)
        {
            try
            {
                string OfferPlanName = string.Empty;
                string providerName = string.Empty;
                long ispId = 0;
                var data = new SignUpItemDTO()
                {
                    Firstname = firstName,
                    Lastname = lastName,
                    Email = email,
                    Phone = phone,
                    IspOfferId = offerId,
                };
                var signUpDetails = await _signUpService.UserSignUp(SignUpItemDTO.ToSignUpDetailsItem(data));

                if (offerId > 0)
                {
                    IspOfferItemDTO offer = IspOfferItemDTO.FromIspOfferItem(await _service.GetOfferById(offerId));
                    OfferPlanName = offer.Displayname;
                    providerName = ProviderItemDTO.FromProviderItem(await _providerService.GetProviderById(offer.Ispid)).Displayname;
                }

                //  return new OkObjectResult(SignUpItemDTO.FromSignUpItem(signUpDetails));
                return new OkObjectResult(new { offerName = OfferPlanName, providerName });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured: {Message}", e.Message);
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
