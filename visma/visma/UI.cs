using System;
namespace visma
{
    public class UI
    {
        public ContactManager Contacts { get; set; }
        public UI(ContactManager contacts)
        {
            this.Contacts = contacts;
        }

        public void RunUI() {
          
            int Input = 6;
            int index = 0;
            do
            {
                PrintMenu();
                Input = RequestInput();
                switch (Input)
                {
                    case 1:
                        //add contact
                        string name = AskForName();
                        string lastName = AskForLastName();
                        string number = AskForNumber();
                        string address = AskForAdress();
                        int didSucceed = 0;
                        if (address.Equals("0"))
                        {
                            didSucceed = Contacts.AddContact(new Contact(name, lastName, number));
                        }
                        else didSucceed = Contacts.AddContact(new Contact(name, lastName, number, address));
                        if (didSucceed == 0) {
                            Console.WriteLine("Contact not added, check if there are no duplicate numbers");
                        }
                        break;
                    case 2:
                        //delete contact
                        if (Contacts.MyContacts.Count == 0) {
                            Console.WriteLine("No contacts left");
                            break;
                        }
                        Console.WriteLine("Which contact would you like to delete?");
                        Contacts.ShowContacts();
                        index = AskforIndex(1,Contacts.MyContacts.Count);
                        while (index == -1) {
                            Console.WriteLine("Invalid input, try again.");
                            index = AskforIndex(1, Contacts.MyContacts.Count);
                        }
                        Contacts.DeleteContact(index);
                        Console.WriteLine("Contact deleted.");
                        break;
                    case 3:
                        //contact edit
                        Contacts.ShowContacts();
                        Console.WriteLine("Which contact would you like to edit?");
                        index = AskforIndex(1,Contacts.MyContacts.Count);
                        while (index == -1)
                        {
                            Console.WriteLine("Invalid input, try again.");
                            index = AskforIndex(1, Contacts.MyContacts.Count);
                        }
                        Console.WriteLine("Which field would you like to edit?\r\n1.Name\r\n2.last name\r\n3.number\r\n4.address");
                        int field = AskforIndex(1, 4);
                        while (field == -1) {
                            Console.WriteLine("Invalid input, try again.");
                            field = AskforIndex(1, 4);
                        }
                        Console.WriteLine("New value:");
                        string update = Console.ReadLine().Trim();
                        if (field == 1) {
                            Contacts.EditContact(index,update,"name");
                        }
                        if (field == 2)
                        {
                            Contacts.EditContact(index, update, "lastname");
                        }
                        if (field == 3)
                        {
                            Contacts.EditContact(index, update, "number");
                        }
                        if (field == 4)
                        {
                            Contacts.EditContact(index, update, "address");
                        }
                        break;
                    case 4:
                        //print contacts
                        this.Contacts.ShowContacts();
                        break;
                    case 5:
                        //exit UI
                        return;
                    default:
                        //bad input
                        Console.WriteLine("Invalid input, repeat");
                        PrintMenu();
                        RequestInput();
                        break;
                }
            } while (Input != 5);
        }

        public void PrintMenu() {
            Console.WriteLine("Press numbers, to: \r\n1. Add contact \r\n2. Delete contact \r\n3.Update contact\r\n4.Show contacts\r\n5. exit");
        }

        public int RequestInput() {
            bool isValid = Int32.TryParse(Console.ReadLine(), out int i);
            while (!isValid) {
                isValid = Int32.TryParse(Console.ReadLine(), out  i);
            }
            return i;
        }

        public string AskForName() {
            Console.WriteLine("Contact's name:");
            return Console.ReadLine().Trim();
        }
        public string AskForLastName()
        {
            Console.WriteLine("Contact's last name:");
            return Console.ReadLine().Trim();
        }
        public string AskForNumber()
        {
            Console.WriteLine("Contact's number:");
            return Console.ReadLine().Trim();
        }
        public string AskForAdress()
        {
            Console.WriteLine("Contact's address, if not present, press 0:");
            return Console.ReadLine().Trim();
        }

        public int AskforIndex(int lowest, int highest) {
            
            bool didSucceed = Int32.TryParse(Console.ReadLine(), out int index);
            if (didSucceed) {
                if (index >= lowest && index <= highest) {
                    return index;
                }
            }
            return -1;
        }
    }
}
