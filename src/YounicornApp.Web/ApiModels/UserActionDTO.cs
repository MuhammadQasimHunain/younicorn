using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Web.ApiModels
{
    public class UserActionDTO
    {
        public long ActionId { get; set; }

        public DateTime ActionDatetime { get; set; }

        public string SessionId { get; set; }

        public string EnquiryId { get; set; }

        public string ActionType { get; set; }

        public string ActionDetails { get; set; }

        public long? IspId { get; set; }

        public long? IspOfferId { get; set; }

        public string UserAddress { get; set; }

        public string ISPDetail { get; set; }

        public string ISPOfferDetail { get; set; }

        public UserActionDTO()
        {

        }
        public static UserActionDTO FromUserHistory(UserHistory item,string ispDetail, string ispOfferDetail)
        {
            if (item != null)
            {
                return new UserActionDTO {
                     ActionDatetime = item.ActionDatetime,
                     ActionDetails = item.ActionDetails,
                     ActionId = item.Id,
                     ActionType = item.ActionType,
                     EnquiryId = item.EnquiryId,
                     IspId = item.IspId,
                     IspOfferId = item.IspOfferId,
                     SessionId = item.SessionId,
                     UserAddress = item.UserAddress,
                     ISPDetail = ispDetail,
                     ISPOfferDetail = ispOfferDetail
                };
            }
            return null;
        }

    }
}
