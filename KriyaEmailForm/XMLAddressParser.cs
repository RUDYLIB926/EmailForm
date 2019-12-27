using System.Collections.Generic;
using System.Xml.Linq;

namespace KriyaEmailForm
{
    internal static class XMLAddressParser
    {
        internal static List<EmailAddress> GetAddresses()
        {
            List<EmailAddress> addresses = new List<EmailAddress>();
            var xmlDoc = XDocument.Load("C:/Repositories/Kriya/KriyaEmailForm/KriyaEmailForm/AddressList.xml");

            var addressesTab = xmlDoc.Root;
            var allAddresses = addressesTab.Descendants("Address");

            foreach(var element in allAddresses)
            {
                var nameTag = element.Element("NAME");
                var addressTag = element.Element("EMAIL");

                var name = nameTag.Value;
                var address = addressTag.Value;

                EmailAddress email = new EmailAddress(name, address);
                addresses.Add(email);
            }

            return addresses;
        }
    }
}
