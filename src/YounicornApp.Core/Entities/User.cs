using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YounicornApp.SharedKernel;

namespace YounicornApp.Core.Entities
{
    [Table("tbl_Users")]
    public partial class User : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
        public bool IsActive { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }


    }
}
