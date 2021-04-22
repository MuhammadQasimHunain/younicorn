using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YounicornApp.SharedKernel;

namespace YounicornApp.Core.Entities
{
    [Table("tbl_Roles")]
    public partial class Role : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        [MaxLength(100)]
        public string RedirectUrl { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
