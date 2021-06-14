using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UGIM.Server.Services.Abstract
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}
