using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Bookswagon.Pages;
using Bookswagon.Credentials;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Security.Policy;
using System.Net.Mail;
using System.Net;

namespace Bookswagon.MailReport
{
    public class Mail
    {
        public void SendMail(string subject,string contentBody)
        {
            // Sender's email, Sender's password, To/receiver's email, subject, body, cc, attachment
            // Smtp  simple mail transper protocol (smtp server,port no.) for outlook
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.live.com");

            // Senders mail
            mail.From = new MailAddress(JsonData.data.outlookMail);
            // reciever's email
            mail.To.Add(JsonData.data.UserEmail);
            mail.Subject = subject;
            mail.Body = contentBody;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment("file:///C:/Users/Admin/source/repos/Bookswagon/Bookswagon/ExtentReports/index.html"));

            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(JsonData.data.outlookMail, JsonData.data.outlookPassword);
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }
    }
}
