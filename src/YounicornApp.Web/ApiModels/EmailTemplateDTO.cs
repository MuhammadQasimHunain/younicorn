using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YounicornApp.Web.ApiModels
{
    public class EmailTemplateDTO
    {
        #region Properties
        public string Type { get; set; }
        public string Subject { get; set; }
        public string SendCC { get; set; }
        public string SendBCC { get; set; }
        public string Body { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        #endregion

        public bool isValid()
        {
            return !string.IsNullOrEmpty(Subject) && !string.IsNullOrEmpty(Body);
        }
    }

    public class EmailResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
