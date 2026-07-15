using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Models
{
    public class Helper
    {
        public string IsChoiceValid(string choice)
        {
            if (string.IsNullOrEmpty(choice) || string.IsNullOrWhiteSpace(choice))
            {
                return "Error! Invalid choice";
            }
            else if (!char.TryParse(choice, out var c))
            {
                return "Enter valid charecter";
            }
            else
            {
                return null;
            }
        }

        public void CheckStrValidity(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || !(str.All(char.IsLetter)))
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                return;
            }
        }
        public void CheckNumValidity(long num)
        {
            int length = num.ToString().Length;
            if (length != 10)
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                return;
            }
        }
        public void CheckEmailValidity(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || char.IsSymbol(email[0]))
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                return;
            }
        }
        public void CheckNoteslValidity(string notes)
        {
            if (string.IsNullOrWhiteSpace(notes))
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                return;
            }
        }
    }
}
