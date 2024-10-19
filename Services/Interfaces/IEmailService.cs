using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using riwitalentfrontend.Models;


namespace riwitalentfrontend.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailTest(string Id);
        Task<bool> SendEmailCompany(string groupId);
        // Task SendTermsAndConditions(string Name, string EmailRecipient);
        // Task SendEmailStaff(string Name, string Email, string Message, string groupId);
        // Task SendEmailAll(MimeMessage mimeMessage);
    }
}