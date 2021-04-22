using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using YounicornApp.SharedKernel;

namespace YounicornApp.Core.Entities
{
    [Table("tbl_ISPdetails")]
    public partial class Provider : BaseEntity
    {
        public Provider()
        {
            TblIspoffers = new HashSet<IspOffer>();
        }

        public string Ispname { get; set; }
        public string Displayname { get; set; }
        public float Isprating { get; set; }
        public string LogoUrl { get; set; }

        public virtual ICollection<IspOffer> TblIspoffers { get; set; }
    }
}
