using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace CodeLock.Helper
{
    public class EmailConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool SslEnabled { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FromMailAddress { get; set; }
    }
    public class EmailHelper
    {
        public static bool SendEmail(string fromMailAddress, string toMailAddress, string subject, string body,bool isBodyHTML, string attachmentPath, string host, int port, string userName, string password, bool isSslEnabled)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromMailAddress);
                    foreach (var toMailId in toMailAddress.Split(','))
                    {
                        mail.To.Add(toMailId.Trim());
                    }

                    mail.Subject = subject;
                    mail.IsBodyHtml = isBodyHTML;
                    mail.Body = body;

                    if (!string.IsNullOrEmpty(attachmentPath))
                        mail.Attachments.Add(new Attachment(attachmentPath));

                    using (SmtpClient client = new SmtpClient(host, port))
                    {
                        client.Credentials = new NetworkCredential(userName, password);
                        client.EnableSsl = isSslEnabled;
                        client.Send(mail);
                        mail.Attachments.Dispose();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Send Mail", SessionUtility.LoginUserId, nameof(EmailHelper));
                return false;
            }
        }
    }


}