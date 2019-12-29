using System.Collections.Generic;
using System.Xml.Linq;

namespace KriyaEmailForm
{
    internal class XMLAddressParser
    {
        XDocument _document;

        public XMLAddressParser(string path, Enumerators.FileType fileType)
        {
            if(fileType == Enumerators.FileType.CSV)
            {
                convertCSVToXML(); // overwrites AddressList.xml if it exists
            }
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

        private void convertCSVToXML()
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string addressesFilePath = currentDirectory + "/AddressList.csv";
            string[] lines = System.IO.File.ReadAllLines(addressesFilePath);
            XDocument document = new XDocument();
            XElement root = new XElement("Addresses");
            document.AddFirst(root);
            foreach (var line in lines)
            {
                string[] lineWithoutComma = line.Split(',');
                if (lineWithoutComma[2] != "")
                {
                    XElement host = new XElement("Host");
                    host.Add(new XElement("EMAIL", lineWithoutComma[0]));
                    host.Add(new XElement("NAME", lineWithoutComma[1]));
                    host.Add(new XElement("PASSWORD", lineWithoutComma[2]));
                    host.Add(new XElement("ADDRESS", lineWithoutComma[3]));
                    host.Add(new XElement("PORT", lineWithoutComma[4]));
                    root.Add(host);
                }
                else
                {
                    XElement address = new XElement("Address");
                    address.Add(new XElement("EMAIL", lineWithoutComma[0]));
                    if (lineWithoutComma.Length > 1)
                    {
                        address.Add(new XElement("NAME", lineWithoutComma[1]));
                    }
                    root.Add(address);
                }
            }
            var filePath = currentDirectory + "/AddressList.xml";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            document.Save(filePath);
        }
    }
}
