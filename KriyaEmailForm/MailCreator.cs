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
        private XMLAddressParser _addressParser;
        private HostAddress Host { get; set; }
        private string Message { get; set; }
        private string Subject { get; set; }
        public bool Stopped { get; set; } = false;
        
        public MailCreator(string addressFilePath, string subject, string body)
        {
            Subject = subject;
            Message = body;
            _addressParser = new XMLAddressParser(addressFilePath);
            Host = _addressParser.GetHostAddress();
        }

        public bool SendMail()
        {
            List<MailAddress> toAddressList = getToAddresses();
            return sendMail(toAddressList);
        }
        private bool sendMail(IEnumerable<MailAddress> addresses)
        {
            bool sent;
            // set up the SMTP client
            using (SmtpClient client = new SmtpClient(Host.Address, Host.Port))
            {
                client.SendCompleted += new
                SendCompletedEventHandler(sendCompletedCallback);

                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(Host.Email, Host.Password);

                // set up the message
                MailAddress from = new MailAddress(Host.Email, Host.Name, Encoding.UTF8);

                MailMessage message = new MailMessage();
                message.From = from;
                foreach (var address in addresses)
                {
                    message.Bcc.Add(address);
                }
                writeMessage(message);

                sent = sendMessage(client, message);
            }
            return sent;
        }

        private void writeMessage(MailMessage message)
        {
            message.Body = "Hello," + Environment.NewLine + Environment.NewLine;
            message.Body += Message;
            message.Body += Environment.NewLine + Environment.NewLine + "Peace and Love," + Environment.NewLine + "The Cleveland Kriya Yoga Group";
            message.BodyEncoding = Encoding.UTF8;
            message.Subject = Subject;
            message.SubjectEncoding = Encoding.UTF8;
        }
        private bool sendMessage(SmtpClient client, MailMessage message)
        {
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
            List<EmailAddress> emailAddresses = _addressParser.GetRecipiantAddresses();

            foreach(var email in emailAddresses)
            {
                MailAddress address = new MailAddress(email.Email, email.Name);
                mailAddresses.Add(address);
            }

            return mailAddresses;
        }
    }
}
