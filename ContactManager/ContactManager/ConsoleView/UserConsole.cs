using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Models;
using ContactManager.Service;
using ContactManager.Repository;

namespace ContactManager.ConsoleView
{
    public class UserConsole
    {
        Repo repo = new Repo();
        public void Menu()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("MENU");
            Console.WriteLine("[A]dd contact");
            Console.WriteLine("[S]earch contact");
            Console.WriteLine("[V]iew all contact");
            Console.WriteLine("[E]dit contact");
            Console.WriteLine("[R]emove contact");
            Console.WriteLine("[C]lose contact");
            Console.WriteLine("------------------");
        }
        public string GetChoice() // check if choice is valid
        {
            Console.WriteLine("Enter a choice:");
            string? userChoice= Console.ReadLine();
            Helper validChoice = new Helper();
            string outChoice = validChoice.IsChoiceValid(userChoice);
            if(outChoice == null)
            {
                return userChoice;
            }
            return null;
        }

        public void GetAdd()
        {
            Helper strval = new Helper();

            Console.WriteLine("Enter your name");
            string? name = Console.ReadLine();
            strval.CheckStrValidity(name);

            Console.WriteLine("Enter your Phone number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            strval.CheckNumValidity(phoneNumber);

            Console.WriteLine("Enter your email address");
            string? emailAddress = Console.ReadLine();
            strval.CheckEmailValidity(emailAddress);

            Console.WriteLine("Enter additional notes");
            string? addNotes = Console.ReadLine();
            strval.CheckNoteslValidity(addNotes);

            ContactInfo contact = new ContactInfo(name, phoneNumber, emailAddress, addNotes);

            ContactConsole con = new ContactConsole();
            con.AddContact(contact);
        }
    }
}
