using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Entities;

namespace YounicornApp.Web.ApiModels
{
    public class IspOfferItemDTO
    {
        #region Properties
        public int Id { get; set; }

        public string Offername { get; set; }
        public string Displayname { get; set; }
        public string Speed { get; set; }
        public string Data { get; set; }
        public float Pricemonth { get; set; }
        public float Priceannual { get; set; }
        public string Discountdetails { get; set; }
        public string Bundledetails { get; set; }
        public string Bullet1 { get; set; }
        public string Bullet2 { get; set; }
        public string Bullet3 { get; set; }
        public string Bullet4 { get; set; }
        public string Bullet5 { get; set; }
        public float Installationcost { get; set; }
        public float Modemcost { get; set; }
        public float Terminationfee { get; set; }
        public float Offerrating { get; set; }
        public int Favourite { get; set; }
        public float Offerid { get; set; }
        public int Ispid { get; set; }
        public bool Adsl { get; set; }
        public bool Vdsl { get; set; }
        public bool Fibre { get; set; }
        public bool Fibreplus { get; set; }
        public Provider Isp { get; set; }
        #endregion

        public static IspOfferItemDTO FromIspOfferItem(IspOffer item = null)
        {
            if (item != null)
            {
                return new IspOfferItemDTO()
                {
                    Id = item.Id,
                    Offername = item.Offername,
                    Displayname = item.Displayname,
                    Speed = item.Speed,
                    Data = item.Data,
                    Pricemonth = item.Pricemonth,
                    Priceannual = item.Priceannual,
                    Discountdetails = item.Discountdetails,
                    Bullet1 = item.Bullet1,
                    Bullet2 = item.Bullet2,
                    Bullet3 = item.Bullet3,
                    Bullet4 = item.Bullet4,
                    Bullet5 = item.Bullet5,
                    Installationcost = item.Installationcost,
                    Modemcost = item.Modemcost,
                    Offerrating = item.Offerrating,
                    Bundledetails = item.Bundledetails,
                    Favourite = item.Favourite,
                    Ispid = item.Ispid,
                    Terminationfee = item.Terminationfee,
                    Adsl = item.Adsl,
                    Vdsl = item.Vdsl,
                    Fibre = item.Fibre,
                    Fibreplus = item.Fibreplus,
                    Isp = item.Isp
                };
            }
            return new IspOfferItemDTO();
        }
    }
}
