using System;
using System.Collections.Generic;
using System.Text;

namespace YounicornApp.Core.Models
{
    public class SiteAnalyticsResponse
    {
        public int Id { get; set; }
        public string ActionType { get; set; }
        public long? ISPId { get; set; }
        public string ISPDisplayName { get; set; }
        public long? ISPOfferId { get; set; }
        public string ISPOfferDisplayName { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class SiteAnalyticsRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public long? Provider { get; set; }
        public long? Plan { get; set; }
    }
    public class SiteChartResponse
    {
        public int Y { get; set; }
        public string Label { get; set; }
        public string IndexLabel { get; set; }
    }
}
