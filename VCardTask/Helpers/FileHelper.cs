using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCardTask.Models;

namespace VCardTask.Helpers
{
    public class FileHelper
    {
        const string NewLine = "\r\n";
        const string Separator = ";";
        const string Header = "BEGIN:VCARD\r\nVERSION:4.0";
        const string Name = "N:";
        const string FullName = "FN:";
        const string PhonePrefix = "TEL;TYPE=work";
        const string PhoneSubPrefix = ",voice;VALUE=uri:tel:";
        const string AddressPrefix = "ADR;TYPE=home;LABEL=";
        const string AddressSubPrefix = ":;;";
        const string EmailPrefix = "EMAIL:";
        const string Footer = "END:VCARD";

        public static string CreateVCard(User user)
        {
            StringBuilder fw = new StringBuilder();
            fw.Append(Header);
            fw.Append(NewLine);

            //Name
            if (!string.IsNullOrEmpty(user.Name.First) || !string.IsNullOrEmpty(user.Name.Last))
            {
                fw.Append(Name);
                fw.Append(user.Name.Last);
                fw.Append(Separator);
                fw.Append(user.Name.First);
                fw.Append(Separator);
                fw.Append(Separator);
                fw.Append(Separator);
                fw.Append(NewLine);
            }

            //Full Name
            if (!string.IsNullOrEmpty(user.Name.First) || !string.IsNullOrEmpty(user.Name.Last))
            {
                fw.Append(FullName);
                fw.Append(user.Name.First);
                fw.Append(" ");
                fw.Append(user.Name.Last);
                fw.Append(NewLine);
            }

            //Phone
            if (!string.IsNullOrEmpty(user.Phone))
            {
                fw.Append(PhonePrefix);
                fw.Append(PhoneSubPrefix);
                fw.Append(user.Phone);
                fw.Append(NewLine);
            }

            //Adress
            if (!string.IsNullOrEmpty(user.Location.Country) || !string.IsNullOrEmpty(user.Location.City))
            {
                fw.Append(AddressPrefix);
                fw.Append(user.Location.City);
                fw.Append(Separator);
                fw.Append(user.Location.Country);
                fw.Append(AddressSubPrefix);
                fw.Append(user.Location.City);
                fw.Append(Separator);
                fw.Append(user.Location.Country);
                fw.Append(";;;;");
                fw.Append(NewLine);
            }

            //Email
            if (!string.IsNullOrEmpty(user.Email))
            {
                fw.Append(EmailPrefix);
                fw.Append(user.Email);
                fw.Append(NewLine);
            }
            fw.Append(Footer);

            return fw.ToString();
        }
    }
}
