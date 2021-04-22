using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.Web.ApiModels;

namespace YounicornApp.Web.Controllers
{
    public class IspOfferController : Controller
    {
        private readonly IIspOfferService _service;
        private readonly ILogger<IspOfferController> _logger;

        public IspOfferController(IIspOfferService service, ILogger<IspOfferController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: IspOfferController
        public ActionResult Index(int id)
        {
            ViewBag.ProviderId = id;            
            return View();
        }


        public async Task<IActionResult> GetOffers(int providerId)
        {
            var items = (await _service.GetItemsByProviderIdAsync(providerId))
                              .Select(IspOfferItemDTO.FromIspOfferItem)
                              .ToList();
            return Json(new { data = items });
        }

        public async Task<IActionResult> GetAllOffers()
        {
            var items = (await _service.GetItemsAsync())
                              .Select(IspOfferItemDTO.FromIspOfferItem)
                              .ToList();
            return Json(new { data = items });
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id, int pId)
        {
            if (id <= 0) return View(new IspOfferItemDTO { Ispid = pId });

            return View(IspOfferItemDTO.FromIspOfferItem(await _service.GetOfferById(id)));
        }

        [HttpPost]
        public async Task<JsonResult> Save(IspOffer offer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (offer.Id > 0)
                    {
                        await _service.UpdateOffer(offer);
                    }
                    else
                    {
                        await _service.CreateOffer(offer);
                    }

                    return Json(new { status = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
           
            return Json(null);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return View();

            return View(IspOfferItemDTO.FromIspOfferItem(await _service.GetOfferById(id)));
        }

        // POST: ProviderController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _service.DeleteOfferAsync(id);
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
