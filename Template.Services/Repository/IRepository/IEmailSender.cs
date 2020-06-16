using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Services.Repository.IRepository
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}