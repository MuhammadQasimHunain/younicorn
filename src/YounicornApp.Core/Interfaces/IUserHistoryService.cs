using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Models;

namespace YounicornApp.Core.Interfaces
{
    public interface IUserHistoryService
    {
        Task<(List<UserHistory> userHistories, List<Provider> ispDetail, List<IspOffer> ispOffers)> GetUserHistories();
        Task<UserHistory> GetUserHistory(int id);
        Task<List<ISP>> GetISP();
        Task<List<ISP>> GetActionType();
        Task<List<ISPOffer>> GetISPOffers();
        Task<ISP> GetISP(int id);
        Task<ISPOffer> GetISPOffers(int id);
        Task<UserHistory> UserHistoryDetailsAsync(UserHistory details);
    }
}
