using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Interfaces;
using YounicornApp.Web.ApiModels;

namespace YounicornApp.Web.Controllers
{
    public class UserActionsController : Controller
    {
        private readonly IUserHistoryService _userHistoryService;
        public UserActionsController(IUserHistoryService userHistoryService)
        {
            _userHistoryService = userHistoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUserActions() 
        {
            try
            {
                var result = await _userHistoryService.GetUserHistories();
                var userHistories = result.userHistories;
                var ispDetail = result.ispDetail;
                var ispOffers = result.ispOffers;
                var data = from hist in userHistories
                           join ispD in ispDetail on hist.IspId equals ispD.Id
                           join ispO in ispOffers on hist.IspOfferId equals ispO.Id
                           select new UserActionDTO
                           { 
                               ActionId = hist.Id,
                               IspId = hist.IspId,
                               IspOfferId = hist.IspOfferId,
                               UserAddress = hist.UserAddress,
                               EnquiryId = hist.EnquiryId,
                               ActionType = hist.ActionType,
                               ActionDetails = hist.ActionDetails,
                               ActionDatetime = hist.ActionDatetime,
                               ISPDetail = ispD.Displayname,
                               ISPOfferDetail = ispO.Displayname,
                               SessionId = hist.SessionId
                           };
                return Json(new { data = data.ToList() });
            }
            catch (Exception exp)
            {
                return Json(exp.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserActionDetail(int id)
        {
            if (id <= 0) return View();
            var result = await _userHistoryService.GetUserHistory(id);
            string ispDisplayName = (await _userHistoryService.GetISP(int.Parse(result.IspId.Value.ToString()))).Value;
            string ispOfferName = (await _userHistoryService.GetISPOffers(int.Parse(result.IspOfferId.Value.ToString()))).Value;
            return View(UserActionDTO.FromUserHistory(result, ispDisplayName, ispOfferName));
        }

        [HttpGet]
        public async Task<IActionResult> GetISPAsync()
        {
            try
            {
                var result = await _userHistoryService.GetISP();
                return Json(result);
            }
            catch (Exception exp)
            {
                return Json(exp.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetActionType()
        {
            try
            {
                var result = await _userHistoryService.GetActionType();
                return Json(result);
            }
            catch (Exception exp)
            {
                return Json(exp.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetISPOfferAsync()
        {
            try
            {
                var result = await _userHistoryService.GetISPOffers();
                return Json(result);
            }
            catch (Exception exp)
            {
                return Json(exp.Message);
            }
        }
    }
}
