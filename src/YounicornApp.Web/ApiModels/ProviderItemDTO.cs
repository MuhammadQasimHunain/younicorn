using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Web.ApiModels
{
    public class ProviderItemDTO
    {
        public int Id { get; set; }
        public string Ispname { get; set; }
        public string Displayname { get; set; }
        public float Isprating { get; set; }
        public string LogoUrl { get; set; }
        public IFormFile LogoFile { get; set; }

        public static ProviderItemDTO FromProviderItem(Provider item)
        {
            return new ProviderItemDTO()
            {
                Id = item.Id,
                Ispname = item.Ispname,
                Displayname = item.Displayname,
                Isprating = item.Isprating,
                LogoUrl = item.LogoUrl
            };
        }

        public static Provider ToProviderItem(ProviderItemDTO item)
        {
            return new Provider()
            {
                Id = item.Id,
                Ispname = item.Ispname,
                Displayname = item.Displayname,
                Isprating = item.Isprating,
                LogoUrl = item.LogoUrl
            };
        }
    }
}
