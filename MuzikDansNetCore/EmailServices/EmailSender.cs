using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace MuzikDansNetCore.EmailServices
{
    public class EmailSender 
    {
        public static bool SendMail(string FromAdress, string ToAddress, string subject, string context)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var configuration = builder.Build();
                var host = configuration["Gmail:Host"];
                var port = int.Parse(configuration["Gmail:Port"]);
                var username = configuration["Gmail:Username"];
                var password = configuration["Gmail:Password"];
                var enable = bool.Parse(configuration["Gmail:SMTP:Starttls:Enable"]);

                var smtp = new SmtpClient()
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enable,
                    Credentials = new NetworkCredential(username, password)
                };

                var message = new MailMessage(FromAdress, ToAddress)
                {
                    Subject = subject,
                    Body = context,
                    IsBodyHtml = true
                };
                smtp.Send(message);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }


        //public string SendEmail(string Name, string Email, string Message)
        //{
        //    try
        //    {
        //        // Credentials
        //        var credentials = new NetworkCredential("denizmaildeneme@gmail.com", "passwordgir");
        //        // Mail message
        //        var mail = new MailMessage
        //        {
        //            From = new MailAddress("noreply@codinginfinite.com"),
        //            Subject = "Email Sender App",
        //            Body = Message,
        //            IsBodyHtml = true
        //        };
        //        mail.To.Add(new MailAddress(Email));
        //        // Smtp client
        //        var client = new SmtpClient()
        //        {
        //            Port = 587,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = false,
        //            Host = "smtp.gmail.com",
        //            EnableSsl = true,
        //            Credentials = credentials
        //        };
        //        client.Send(mail);
        //        return "Email Sent Successfully!";
        //    }
        //    catch (System.Exception e)
        //    {
        //        return e.Message;
        //    }

        //}
    }

}