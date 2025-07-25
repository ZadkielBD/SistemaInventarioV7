﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.Utilidades
{
    public class EmailSender : IEmailSender
    {

        public string SendGridSecret { get; set; }
        public string Name { get; set; }

        public EmailSender(IConfiguration _config) 
        {
            SendGridSecret = _config.GetValue<string>("Sendgrid:SecretKey");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(SendGridSecret);
            var from = new EmailAddress("supportOnline@ratshop.com");
            var to = new EmailAddress(email, Name);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

            return client.SendEmailAsync(msg);
        }
    }
}
