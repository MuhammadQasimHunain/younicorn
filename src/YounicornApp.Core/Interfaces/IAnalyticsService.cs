using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YounicornApp.Core.Models;

namespace YounicornApp.Core.Interfaces
{
    public interface IAnalyticsService
    {
        Task<List<SiteChartResponse>> GetAnalytics(SiteAnalyticsRequest request);
    }
}
