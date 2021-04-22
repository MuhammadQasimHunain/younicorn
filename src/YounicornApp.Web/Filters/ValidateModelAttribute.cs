using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Interfaces;
using YounicornApp.Core.Services;
using YounicornApp.Web.ApiModels;
using static YounicornApp.SharedKernel.Common.Enums;

namespace YounicornApp.Web.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly IUserHistoryService _userHistoryService;
        private readonly IIspOfferService _ispOfferService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ValidateModelAttribute(IUserHistoryService userHistoryService, IHttpContextAccessor httpContextAccessor, IIspOfferService ispOfferService)
        {

            _userHistoryService = userHistoryService;
            _httpContextAccessor = httpContextAccessor;
            _ispOfferService = ispOfferService;

        }
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{


        //}

        public override async Task OnActionExecutionAsync(ActionExecutingContext context,
                                          ActionExecutionDelegate next)
        {

            const string SessionKeyName = "_Name";

            int ispOfferId = 0;
            long ispId = 0;
            string address = string.Empty;
            var ActionType = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var ActionTypeResult = ActionType == "Contact" ? LoggingActionType.ContactUsRedirect :
                ActionType == "ProviderInfo" ? LoggingActionType.ProviderInfoRedirect : ActionType == "Compare" ?
                LoggingActionType.ComparePlans : ActionType == "About" ? LoggingActionType.AboutUsRedirect :
                ActionType == "SignUp" ? LoggingActionType.SignupRedirect : ActionType == "MoreInfo" ? LoggingActionType.MoreInfo : LoggingActionType.Home;
            var userIPAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            if (string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(SessionKeyName)))
                _httpContextAccessor.HttpContext.Session.SetString(SessionKeyName, _httpContextAccessor.HttpContext.Session.Id);

            var name = _httpContextAccessor.HttpContext.Session.GetString(SessionKeyName);

            if (ActionType == "SignUp" || ActionType == "MoreInfo")
            {
                ispOfferId = Convert.ToInt32(context.ActionArguments.Values.First().ToString());
                if (ispOfferId > 0)
                    ispId = IspOfferItemDTO.FromIspOfferItem(await _ispOfferService.GetOfferById(ispOfferId)).Ispid;
            }
            if (ActionType == "Compare")
            {
                address = context.ActionArguments.Values.First().ToString();
            }
         

            var data = new UserHistory()
            {
                ActionDatetime = DateTime.Now,
                SessionId = name,
                EnquiryId = "0",
                ActionType = ActionTypeResult.ToString(),
                ActionDetails = "",
                IspId = ispId,
                IspOfferId = ispOfferId,
                UserAddress = address,
                IPAddress = userIPAddress
            };
            await _userHistoryService.UserHistoryDetailsAsync(data);

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            await next(); // the actual action

            // logic after the action goes here
        }


    }
}
