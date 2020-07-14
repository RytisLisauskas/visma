using System;
using System.Collections;
namespace visma
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ArrayList contacts = Loader.loadContacts();
            ContactManager manager = new ContactManager(contacts);
            UI ui = new UI(manager);
            ui.RunUI();
            Loader.saveContacts(manager.MyContacts);
        }
    }
}
