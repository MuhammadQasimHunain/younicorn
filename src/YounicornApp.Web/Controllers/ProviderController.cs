using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;
using YounicornApp.Web.ApiModels;

namespace YounicornApp.Web.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderService _service;
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(IProviderService service, ILogger<ProviderController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: ProviderController
        public ActionResult Index()
        {           
            return View();
        }

        public async Task<IActionResult> GetProviders()
        {
            var items = (await _service.GetItemsAsync())
                              .Select(ProviderItemDTO.FromProviderItem)
                              .ToList();
            return Json(new { data = items });
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if(id <= 0) return View();
           
            return View(ProviderItemDTO.FromProviderItem(await _service.GetProviderById(id)));
        }

        [HttpPost]
        public async Task<JsonResult> Save(ProviderItemDTO providerDto)
        {
            if (ModelState.IsValid)
            {
                var provider = ProviderItemDTO.ToProviderItem(providerDto);
                provider.LogoUrl = providerDto.LogoFile != null ? UploadFile(providerDto.LogoFile) : providerDto.LogoUrl;

                if (provider.Id > 0)
                {
                    await _service.UpdateProvider(provider);
                }
                else
                {
                    await _service.CreateProvider(provider);  
                }

                return Json(new { status = true });                
            }
            return Json(null);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return View();

            return View(ProviderItemDTO.FromProviderItem(await _service.GetProviderById(id)));
        }

        // POST: ProviderController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _service.DeleteProviderAsync(id);
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }

        [HttpPost]
        public string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return string.Empty;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\img\\provider",
                        Path.GetFileName(file.FileName));

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }

            return file.FileName;
        }
    }
}
