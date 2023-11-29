using ProjectLeader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjectLeader.Helpers
{
    public class EmailHelper
    {
        public bool SendEmail(EmailModel emailModel)
        {
            try
            {
                string sendEmailsFrom = "maksimovic.petar991@gmail.com";
                string sendEmailsFromPassword = "petar991";
                MailMessage mail = new MailMessage();

                mail.To.Add(new MailAddress(emailModel.To));

                mail.From = new MailAddress(sendEmailsFrom);
                mail.Subject = emailModel.Subject;
                mail.Body = emailModel.Message;

                using (var smtp = new SmtpClient())
                {
                    var credentila = new NetworkCredential
                    {
                        UserName = sendEmailsFrom,
                        Password = sendEmailsFromPassword
                    };
                    smtp.Credentials = credentila;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                }
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
