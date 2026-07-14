//menu
using System.Transactions;
using System.Xml.Linq;
bool flag = true;
List<List<string>> multiList = new List<List<string>>();

while (flag)
{

    Console.WriteLine("MENU");
    Console.WriteLine("[A]dd contact");
    Console.WriteLine("[S]earch contact");
    Console.WriteLine("[V]iew all contact");
    Console.WriteLine("[E]dit contact");
    Console.WriteLine("[R]emove contact");
    Console.WriteLine("[C]lose contact");

    Console.Write("Enter you choice:");
    string inputstr = Console.ReadLine();
    if(inputstr == null|| inputstr == "") {
        Console.WriteLine("Invalid string");
        continue;
    }
    if (char.TryParse(inputstr, out char res))
    {
        Console.WriteLine($"option choosen: {option(res)}");
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter exactly one charecter of your option");
        continue;
        
    }
    Console.WriteLine();
    char inp = Convert.ToChar(inputstr);
    option(inp);
    switch (inp)
    {
        case 'A' or 'a':
            ADD();
            Console.WriteLine();
            break;
        case 'S' or 's':
            Search().ForEach(Console.WriteLine);
            Console.WriteLine();
            break;
        case 'V' or 'v':
            View();
            Console.WriteLine();
            break;
        case 'E' or 'e':
            Edit(Search());
            Console.WriteLine();
            break;
        case 'R' or 'r':
            Remove();
            Console.WriteLine();
            break;
        case 'C' or 'c':
            Console.WriteLine("Closing the application..");
            flag = false;
            break;
    }
}

void Remove()
{
    bool isvalididx = true;
    while (isvalididx)
    {
        if(multiList.Count==0)
        {
            Console.WriteLine("There are no contacts to remove");
            isvalididx = false;
        }
        else
        {
            View();
        }
        Console.WriteLine("Enter the serial no of the contact to be deleted:");
        var idx = Console.ReadLine();
        bool isidxint = int.TryParse(idx, out int delidx);
        if (!isidxint || idx == "")
        {
            Console.WriteLine("Invalid index");
        }
        else if (delidx > multiList.Count || delidx == 0)
        {
            Console.WriteLine("Index is out of bound! Please enter valid index.");
        }
        else
        { 
            multiList.RemoveAt(delidx - 1);
            Console.WriteLine("Contact is removed. updated list is:");
            View();
            return;
        }
    }
}

void Edit(List<string> a)
{
    Console.WriteLine("what do you want to edit?\n1.name\n2.phone no\n3.emailid\n4.notes");
    int inp = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("enter changes to be made:");
    a[inp - 1] = Console.ReadLine();
}

void View()
{
    int i = 0;
    int j = 0;
    foreach(List<string> s in multiList)
    {
        Console.Write($"{i}:");
        i++;
        foreach(string n in s)
        {
            if (j == 0)
            {
                Console.Write("Name:");
            }
            else if(j == 1)
            {
                Console.Write("Phone number:");
            }
            else if(j == 2) 
            {
                Console.Write("Email id:");
            }
            else {
                    Console.Write("note");
            }
            Console.Write($" {n}");
            j++;
        }
        Console.WriteLine();
    }
}

List<string> Search()
{
    Console.Write("enter the contact to be searched:");
    string req = Console.ReadLine();
    foreach (List<string> s in multiList)
    {
        foreach (string n in s)
        {
            if (n.Equals(req, StringComparison.OrdinalIgnoreCase))
            {
                return s;
            }
        }
    }
    return null;
}

void ADD()
{
    List<string> list = new List<string>();
    bool isconvalid = false;
    while (!isconvalid)
    {
        Console.Write("enter name:");
        string name= Console.ReadLine();
        
        if(!Isnamevalid(name))
        {
            Console.WriteLine("Invalid name!");
            return;
        }
        else if (checkdup(0,name))
        {
            Console.WriteLine("Contact cannot be a duplicate");
        }
        else
        {
            list.Add(name);
        }

        Console.Write("Phone no:");
        string phn_no= Console.ReadLine();
        if (!Isphnvalid(phn_no))
        {
            Console.WriteLine("Invalid phone number!");
            return;
        }
        else if (checkdup(1, phn_no))
        {
            Console.WriteLine("Contact cannot be a duplicate");
        }
        else
        {
            list.Add(phn_no);
        }

        Console.Write("email id:");
        string e_ID = Console.ReadLine();
        if (!Iseidvalid(e_ID))
        {
            Console.WriteLine("Invalid email id!");
            return;
        }
        else if (checkdup(2, e_ID))
        {
            Console.WriteLine("Contact cannot be a duplicate");
        }
        else
        {
            list.Add(e_ID);
        }

        Console.Write("Do you want to add notes[y/n]:");
        char res = Console.ReadKey().KeyChar;

        if (res == 'y')
        {
            Console.WriteLine("\nenter notes for the contact");
            list.Add(Console.ReadLine());
        }

        multiList.Add(list);
        isconvalid= true;
    }
}

bool checkdup(int v, string s)
{
    foreach(List<string> c in multiList)
    {
        if (c[v] == s)
        {
            return true;
        }
    }
    return false;
}

bool Iseidvalid(string e_ID)
{
    if (e_ID == null || e_ID == "" || char.IsSymbol(e_ID[0]) )
    {
        return false;
    }
    return true;
}

bool Isphnvalid(string phn_no)
{ 
    if (phn_no == null || !(phn_no.All(char.IsDigit)) || phn_no.Length!= 10 )
    {
        return false;
    }
    return true;
}

bool Isnamevalid(string name)
{

    if (name == null || name == "" || !(name.All(char.IsLetter)) )
    {
        return false;
    }
    return true;
}

string option(char res)
{
    return res switch
    {
        'A' or 'a' => "Adding new contact",
        'S' or 's' => "Searching exisiting contact",
        'V' or 'v' => "Viewing all contacts",
        'E' or 'e' => "Edit selected contact",
        'R' or 'r' => "Remove selected contact",
        'C' or 'c' => "Closing the application",
        _ => "Invalid option",
    };
}
