using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YounicornApp.SharedKernel;

namespace YounicornApp.Core.Entities
{
    [Table("tbl_UserHistory")]
    public class UserHistory : BaseEntity
    {
        public long ActionId { get; set; }

        public DateTime ActionDatetime { get; set; }

        [MaxLength(50)]
        public string SessionId { get; set; }

        [MaxLength(50)]
        public string EnquiryId { get; set; }

        [MaxLength(100)]
        public string ActionType { get; set; }

        [MaxLength(500)]
        public string ActionDetails { get; set; }

        public long? IspId { get; set; }

        public long? IspOfferId { get; set; }

        [MaxLength(500)]
        public string UserAddress { get; set; }

        [MaxLength(30)]
        public string IPAddress { get; set; }
    }
}
