using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YounicornApp.SharedKernel;

namespace YounicornApp.Core.Entities
{
    [Table("tbl_EmailTemplates")]
    public class EmailTemplate : BaseEntity
    {
        public string Subject { get; set; }
        public string SendCC { get; set; }
        public string SendBCC { get; set; }
        public string Body { get; set; }
    }
}
