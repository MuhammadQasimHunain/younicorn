using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YounicornApp.SharedKernel;

namespace YounicornApp.Core.Entities
{
    [Table("tbl_ContactForms")]
    public class ContactForms : BaseEntity
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
        public string Email { get; set; }
    }
}
