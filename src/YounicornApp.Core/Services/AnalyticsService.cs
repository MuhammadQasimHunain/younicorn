using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YounicornApp.Core.Interfaces;
using YounicornApp.Core.Models;
using System.Linq;
namespace YounicornApp.Core.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IUserHistoryService _userHistoryService;
        public AnalyticsService(IUserHistoryService userHistoryService)
        {
            _userHistoryService = userHistoryService;
        }
        public async Task<List<SiteChartResponse>> GetAnalytics(SiteAnalyticsRequest request)
        {
            try
            {
                List<SiteChartResponse> siteChartRespoceData = new List<SiteChartResponse>();
                var result = await _userHistoryService.GetUserHistories();
                var userHistories = result.userHistories;
                var ispDetail = result.ispDetail;
                var ispOffers = result.ispOffers;
                var data = from hist in userHistories
                           join ispD in ispDetail on hist.IspId equals ispD.Id
                           join ispO in ispOffers on hist.IspOfferId equals ispO.Id
                           select new SiteAnalyticsResponse
                           {
                               Id = hist.Id,
                               ISPId = hist.IspId,
                               ISPOfferId = hist.IspOfferId,
                               ActionType = hist.ActionType,
                               DateTime = hist.ActionDatetime,
                               ISPDisplayName = ispD.Displayname,
                               ISPOfferDisplayName = ispO.Displayname,
                           };
                if (request.DateFrom != new DateTime())
                    data = data.Where(d => d.DateTime >= request.DateFrom);
                if (request.DateTo != new DateTime())
                    data = data.Where(d => d.DateTime <= request.DateTo);
                if (request.Provider != null)
                    data = data.Where(d => d.ISPId == request.Provider);
                if (request.Plan != null)
                    data = data.Where(d => d.ISPOfferId == request.Plan);
                foreach (var line in data.GroupBy(info => info.ActionType)
                        .Select(group => new SiteChartResponse
                        {
                            IndexLabel = group.Key,
                            Y = group.Count(),
                            Label = string.Format("{0}", group.Count())

                        })
                        .OrderBy(x => x.Y))
                {
                    siteChartRespoceData.Add(line);
                }
                    return siteChartRespoceData.ToList();
            }
            catch (Exception exp)
            {
                return new List<SiteChartResponse>();
            }
        }
    }
}
