using System;
using System.Collections.Generic;
using System.Text;

namespace KriyaEmailForm
{
    public class EmailAddress
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public EmailAddress(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    public class HostAddress : EmailAddress
    {
        public string Password { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public HostAddress(string name, string email, string password, string address, int port) : base(name, email)
        {
            Password = password;
            Address = address;
            Port = port;
        }
    }
}
