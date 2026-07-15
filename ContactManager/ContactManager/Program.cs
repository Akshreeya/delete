using ContactManager.ConsoleView;
using ContactManager.Service;

namespace ContactManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserConsole userConsole = new UserConsole();
            ContactConsole contactConsole = new ContactConsole();

            userConsole.Menu();

            char character = char.Parse(userConsole.GetChoice());

            switch (character)
            {
                case 'A' or 'a':
                    userConsole.GetAdd();
                    break;
                case 'S' or 's':
                    Console.WriteLine();
                    break;
                case 'V' or 'v':
                    Console.WriteLine();
                    break;
                case 'E' or 'e':
                    Console.WriteLine();
                    break;
                case 'R' or 'r':
                    Console.WriteLine();
                    break;
                case 'C' or 'c':
                    break;
            }

            Console.ReadKey();
        }
    }
}