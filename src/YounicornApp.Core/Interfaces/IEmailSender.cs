using System.Collections.Generic;
using System.Threading.Tasks;

namespace YounicornApp.Core.Interfaces
{
    public interface IEmailSender
    {
        Task<string> SendEmailAsync(string to, List<string> cc, List<string> bcc, string subject, string body);


    }
}
