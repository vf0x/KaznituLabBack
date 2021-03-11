using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using KaznituLab.Repositories.Interfaces.UnitOfWork;
using KaznituLab.Services.Interfaces.Email;
using Microsoft.Extensions.Configuration;

namespace KaznituLab.Services.Email
{
    public class EmailSendService : IEmailSendService
    {
        private readonly string _smtpAddress, _emailFrom, _email, _emailPassword;
        private readonly IUnitOfWork Db;
        public EmailSendService(IUnitOfWork db, IConfiguration Configuration)
        {
            Db = db;
            _smtpAddress = Configuration.GetSection("Email:Address").Value;
            _emailFrom = Configuration.GetSection("Email:From").Value;
            _email = Configuration.GetSection("Email:Email").Value; 
            _emailPassword = Configuration.GetSection("Email:Password").Value; 
        }
        public void SendEquipmentTechnicalMaintenance()
        {
            var data = Db.Equipments.GetHaveMaintenance();
            if(data != null && data.Count() > 0)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_emailFrom);
                mail.Subject = "SU Lab";
                string htmlBody = "<html><body>";
                htmlBody += "Настало время для технического обслуживаний: <br>";
                //mail.Body = notification.Body;
                int row = 1;
                foreach (var item in data)
                {
                    htmlBody += $"{row})  {item.Equipment.Title} <br>";
                    row++;
                    item.Equipment.EquipmentStatusId = 2;
                }
                htmlBody += @"<span style='font-size:0.85em'>Отправитель: SU LAB";
                htmlBody += "</body></html>";
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody);
                htmlView.ContentType = new System.Net.Mime.ContentType("text/html");

                mail.AlternateViews.Add(htmlView);
                mail.BodyEncoding = Encoding.UTF8;
                mail.SubjectEncoding = Encoding.UTF8;
                //foreach (var to in EmailList)
                //{
                mail.To.Add("doskhan007@mail.ru");
                //}
                SmtpClient smtp = new SmtpClient(_smtpAddress);
                smtp.EnableSsl = false;
                smtp.Credentials = new NetworkCredential(_email, _emailPassword);
                try
                {
                    smtp.Send(mail);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    mail.Dispose();
                    smtp.Dispose();
                }
                Db.Complete();

            }
        }
    }
}
