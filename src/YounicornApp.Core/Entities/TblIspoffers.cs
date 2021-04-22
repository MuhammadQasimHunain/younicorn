using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using YounicornApp.SharedKernel;

namespace YounicornApp.Core.Entities
{
    [Table("tbl_ISPoffers")]
    public partial class IspOffer : BaseEntity
    {
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
        public int Ispid { get; set; }
        public bool Adsl { get; set; }
        public bool Vdsl { get; set; }
        public bool Fibre { get; set; }
        public bool Fibreplus { get; set; }

        public virtual Provider Isp { get; set; }
    }
}
