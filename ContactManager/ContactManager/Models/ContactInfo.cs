using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Models
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public long? PhoneNumber { get; set; }
        public string? EmailId { get; set; }
        public string? Notes { get; set; }

        public ContactInfo(string name, long phoneNumber, string emailId, string notes)
        {

            Name = name;
            PhoneNumber = phoneNumber;
            EmailId = emailId;
            Notes = notes;
        }
        public void Display()
        {
            Console.WriteLine($"The entered data is : {Name}, {PhoneNumber}, {EmailId}, {Notes}");
        }
    }
}
