using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class FakeEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Do nothing, just return completed task
            return Task.CompletedTask;
        }
    }
}
