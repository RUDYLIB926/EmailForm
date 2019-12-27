using System.Collections.Generic;
using System.Xml.Linq;

namespace KriyaEmailForm
{
    internal class XMLAddressParser
    {
        XDocument _document;
        public XMLAddressParser(string path)
        {
            _document = XDocument.Load(path);
        }
        internal HostAddress GetHostAddress()
        {
            var addressesTab = _document.Root;
            var hostTab = addressesTab.Element("Host");
            var nameTag = hostTab.Element("NAME");
            var emailTag = hostTab.Element("EMAIL");
            var passwordTag = hostTab.Element("PASSWORD");
            var addressTag = hostTab.Element("ADDRESS");
            var portTag = hostTab.Element("PORT");

            var name = nameTag.Value;
            var email = emailTag.Value;
            var password = passwordTag.Value;
            var address = addressTag.Value;
            var port = System.Convert.ToInt32(portTag.Value);

            return new HostAddress(name, email, password, address, port);
        }

        internal List<EmailAddress> GetRecipiantAddresses()
        {
            List<EmailAddress> addresses = new List<EmailAddress>();
            var addressesTab = _document.Root;
            var allAddresses = addressesTab.Descendants("Address");

            foreach(var element in allAddresses)
            {
                var nameTag = element.Element("NAME");
                var emailTag = element.Element("EMAIL");

                var name = nameTag.Value;
                var email = emailTag.Value;

                EmailAddress address = new EmailAddress(name, email);
                addresses.Add(address);
            }

            addresses.Add(GetHostAddress());

            return addresses;
        }
    }
}
