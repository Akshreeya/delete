using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ContactManager.Repository
{
    public class Repo
    {
        List<ContactInfo> Contacts = new List<ContactInfo>();
        ContactInfo conStuct ;
        public void AppendContact(ContactInfo contact)
        {
            Contacts.Add(contact);
            contact.Display();
        }

    }
}

