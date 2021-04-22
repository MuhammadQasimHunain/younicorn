using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YounicornApp.Core.Interfaces;
using YounicornApp.SharedKernel.Interfaces;
using YounicornApp.Core.Entities;
using YounicornApp.Core.Models;
using System.Linq;
using IspOffer = YounicornApp.Core.Entities.IspOffer;
namespace YounicornApp.Core.Services
{
    public class UserHistoryService : IUserHistoryService
    {
        private readonly ILogger<UserHistory> _logger;
        private readonly IRepository<UserHistory> _repository;
        private readonly IRepository<IspOffer> _ispofferrepository;
        private readonly IRepository<Provider> _ispdetailrepository;

        public UserHistoryService(ILogger<UserHistory> logger, IRepository<UserHistory> repository, IRepository<IspOffer> isprepository, IRepository<Provider> ispdetailrepository)
        {
            _repository = repository;
            _logger = logger;
            _ispofferrepository = isprepository;
            _ispdetailrepository = ispdetailrepository;
        }

        public async Task<List<ISP>> GetActionType()
        {
            var userHistories = await _repository.ListAsync();
            List<ISP> lst = new List<ISP>();
            var result = (await _repository.ListAsync()).GroupBy(d => d.ActionType)
                .Select(grp => grp.First());
            foreach (var item in result)
            {
                lst.Add(new ISP { Id = 0, Value = item.ActionType });
            }
            return lst;
        }

        public async Task<List<ISP>> GetISP()
        {
            List<ISP> lst = new List<ISP>();
            var result = (await _ispdetailrepository.ListAsync()).GroupBy(d => d.Id)
                .Select(grp => grp.First());
            foreach (var item in result)
            {
                lst.Add(new ISP { Id = item.Id, Value = item.Ispname });
            }
            return lst;
        }

        public async Task<ISP> GetISP(int id)
        {
            var isp = await _ispdetailrepository.GetByIdAsync(id);
            if (isp != null)
            {
                return new ISP { Id = isp.Id, Value = isp.Ispname };
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ISPOffer>> GetISPOffers()
        {
            List<ISPOffer> lst = new List<ISPOffer>();
            var result = (await _ispofferrepository.ListAsync()).GroupBy(d => d.Id)
                .Select(grp => grp.First());
            foreach (var item in result)
            {
                lst.Add(new ISPOffer { Id = item.Id, Value = item.Displayname });
            }
            return lst;
        }

        public async Task<ISPOffer> GetISPOffers(int id)
        {
            var isp= await _ispofferrepository.GetByIdAsync(id);
            if (isp != null)
            {
                return new ISPOffer { Id = isp.Id, Value = isp.Displayname };
            }
            else
            {
                return null;
            }
        }

        public async Task<(List<UserHistory> userHistories,List<Provider> ispDetail,List<IspOffer> ispOffers)> GetUserHistories()
        {
            var userHistories = await _repository.ListAsync();
            var ispOffers = await _ispofferrepository.ListAsync();
            var ispDetails = await _ispdetailrepository.ListAsync();

            return (userHistories,ispDetails,ispOffers);
        }

        public async Task<UserHistory> GetUserHistory(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<UserHistory> UserHistoryDetailsAsync(UserHistory details)
        {
            return await _repository.AddAsync(details);
        }
    }
}
