using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Models;

namespace YounicornApp.Web.ApiModels
{
    public class AnalyticsRequestDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public long? Provider { get; set; }
        public long? Plan { get; set; }

        public SiteAnalyticsRequest ToRequest() 
        {
            return new SiteAnalyticsRequest 
            {
                DateFrom = this.DateFrom,
                DateTo = this.DateTo,
                Plan = this.Plan,
                Provider = this.Provider,
                
            };
        }
    }
}
