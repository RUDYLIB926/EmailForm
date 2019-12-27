using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KriyaEmailForm
{
    public partial class MessageForm : Form
    {
        MailCreator _mail;

        public MessageForm()
        {
            InitializeComponent();
            sendButton.BackColor = Color.Green;
            clearButton.BackColor = Color.Yellow;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if(messageSubject.Text != "" && messageBody.Text != "")
            {
                sendButton.Enabled = false;
                sendButton.BackColor = Color.DarkGreen;
                string currentDirectory = Directory.GetCurrentDirectory();
                string addressesFilePath = currentDirectory + "/AddressList.xml";
                _mail = new MailCreator(addressesFilePath, messageSubject.Text, messageBody.Text);
                bool sent = _mail.SendMail();
                if (sent)
                {
                    messageBody.ForeColor = Color.Green;
                    messageBody.Text = "Message sent!" + Environment.NewLine + "Press Clear All to reset...";
                }
                else
                {
                    messageBody.ForeColor = Color.Red;
                    messageBody.Text = "Message failed to send..." + Environment.NewLine + "Press Clear All to reset...";
                }
            }
            else
            {
                messageBody.ForeColor = Color.Red;
                messageBody.Text = "Please enter a Subject and Message to send..." + Environment.NewLine + "Press Clear All to reset...";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            messageSubject.Text = "";
            messageBody.Text = "";
            messageBody.ForeColor = Color.Black;
            sendButton.Enabled = true;
            sendButton.BackColor = Color.Green;
        }
    }
}
