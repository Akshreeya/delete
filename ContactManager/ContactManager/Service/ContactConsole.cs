using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Models;
using ContactManager.Repository;

namespace ContactManager.Service
{
    internal class ContactConsole
    {
        private Repo repo;

        public void AddContact(ContactInfo contact)
        {
            contact.Id = Guid.NewGuid();
            repo.AppendContact(contact);
            
        }

        public void RemoveContact(ContactInfo contact)
        {

        }

        public void EditContact(ContactInfo contact)
        {

        }

        public void SearchContact(ContactInfo contact)
        {

        }
    }
}
