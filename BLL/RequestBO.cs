using DAL;
using DAL.Utility;
using DataStructure;
using EASendMail;
using System;
using static DataStructure.Tools.Enums;

namespace BLL
{
    public class RequestBO : BusinessBase<Request>
    {
        public override void CheckConstraint(Request obj)
        {
            if (string.IsNullOrEmpty(obj.Phone))
            {
                throw new Exception("لطفا نام خود را وارد کنید");
            }
            if (string.IsNullOrEmpty(obj.Address))
            {
                throw new Exception("لطفا آدرس خود را وارد کنید");
            }
         
            if (obj.ApplicationType == ApplicationType.None)
            {
                throw new Exception("لطفا مورد پرس و جوی خود را وارد کنید");
            }
        }

        public override bool Insert(Request obj)
        {
            if (base.Insert(obj))
            {
                SendEMail(obj);
                return true;
            }

            return false;
        }
        public void SendEMail(Request request)
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Set sender email address, please change it to yours
            oMail.From = "info@dinaservice.com";

            // Set recipient email address, please change it to yours
            oMail.To = "mhazami94@gmail.com";

            // Set email subject
            oMail.Subject = $"درخواست تعمیر {request.ApplicationType.GetDescription()}";


            string message = $"نام : {request.Name} | تلفن : {request.Phone} | آدرس: {request.Address} | موضوع پیام : {request.ApplicationType.GetDescription()} | زمان درخواست : {DateTime.Now.CurrentDate("fa-IR")}";
            // Set email body
            oMail.TextBody = message;

            // Your SMTP server address
            SmtpServer oServer = new SmtpServer("webmail.dinaservice.com")
            {

                // User and password for ESMTP authentication, if your server doesn't require
                // User authentication, please remove the following codes.
                User = "info@dinaservice.com",
                Password = "Dinaservice1451045",

                // some SMTP servers uses 587 port, you can change it to 587
                Port = 587
            };
            oSmtp.SendMail(oServer, oMail);

        }

    }
}
