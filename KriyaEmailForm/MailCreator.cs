using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;

namespace KriyaEmailForm
{
    internal class MailCreator
    {
        static bool mailSent = false;

        private string HostAddress { get; set; }
        private int HostPort { get; set; }
        private string HostUsername { get; set; }
        private string HostPassword { get; set; }
        private string Message { get; set; }
        private string Subject { get; set; }
        public bool Stopped { get; set; } = false;
        
        public MailCreator(string subject, string body)
        {
            Subject = subject;
            Message = body;
            HostUsername = "clekriyayoga@gmail.com";
            HostPassword = "W47chTh3Br3ath:)";
            HostAddress = "smtp.gmail.com";
            HostPort = 587;
        }

        public bool SendMail()
        {
            List<MailAddress> toAddressList = getToAddresses();
            return sendMail(toAddressList);
        }
        private bool sendMail(IEnumerable<MailAddress> addresses)
        {
            // set up the SMTP client
            using (SmtpClient client = new SmtpClient(HostAddress, HostPort))
            {
                client.SendCompleted += new
                SendCompletedEventHandler(sendCompletedCallback);

                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(HostUsername, HostPassword);

                // set up the message
                MailAddress from = new MailAddress(HostUsername, "Cleveland Kriya Group", Encoding.UTF8);

                MailMessage message = new MailMessage();
                message.From = from;
                foreach (var address in addresses)
                {
                    message.Bcc.Add(address);
                }
                message.Body = Message;
                message.BodyEncoding = Encoding.UTF8;
                message.Subject = Subject;
                message.SubjectEncoding = Encoding.UTF8;

                try
                {
                    client.Send(message);

                    Console.WriteLine("Sending message...");
                    if (Stopped && !mailSent)
                    {
                        client.SendAsyncCancel();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                // Clean up.
                message.Dispose();
            }
            return true;
        }

        private static void sendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }

        private List<MailAddress> getToAddresses()
        {
            List<MailAddress> mailAddresses = new List<MailAddress>();
            List<EmailAddress> emailAddresses = XMLAddressParser.GetAddresses();

            foreach(var email in emailAddresses)
            {
                MailAddress address = new MailAddress(email.Address, email.Name);
                mailAddresses.Add(address);
            }

            return mailAddresses;
        }
    }
}
