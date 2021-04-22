using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YounicornApp.SharedKernel;

namespace YounicornApp.Core.Entities
{
    [Table("tbl_SignUps")]
    public class SignUpDetails: BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [ForeignKey("IspOffer")]
        public int IspOfferId { get; set; }

        public virtual IspOffer IspOffer { get; set; }
    }
}
