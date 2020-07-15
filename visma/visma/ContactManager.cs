using System;
using System.Collections;
using System.Collections.Generic;

namespace visma
{
    public class ContactManager
    {
        public ContactManager(ArrayList contacts)
        {
            this.MyContacts = contacts;
        }
        public ArrayList MyContacts { get; set; }

        public int AddContact(Contact contact) {
            if (IsContactValid(contact))
            {
                MyContacts.Add(contact);
                return 1;
            }
            else return 0;
        }

        public Boolean IsContactValid(Contact contact) {
            foreach (Contact con in this.MyContacts) {
                if (!con.Name.ToLower().Equals(contact.Name) || !con.LastName.ToLower().Equals(contact.LastName)) { 
                        if (con.PhoneNumber.Equals(contact.PhoneNumber)) {
                            return false;
                        }
                    }
                    
                if (con.Name.Equals(contact.Name) && con.LastName.Equals(contact.LastName) && con.PhoneNumber.Equals(contact.PhoneNumber)) {
                    return false;
                }
            }
            return true;
        }

        public void ShowContacts() {
            int index = 1;
            foreach (Contact con in MyContacts) {
                Console.Write(index+". "+con.Name+" "+con.LastName+" "+con.PhoneNumber+" ");
                if (con.Address != null)
                {
                    Console.Write(con.Address);
                }
                Console.WriteLine();
                index++;
            }
        }

        public void DeleteContact(int index) {

            MyContacts.RemoveAt(index-1);
            return;
          }
        public void EditContact(int index, string update, string field) {            
            Contact con = retrieveContact(index);
            Console.WriteLine();
            if (field.Equals("name")) {
                con.Name = update;
                if (IsContactValid(con))
                {
                    DeleteContact(index);
                    AddContact(con);
                }
                
                return;
                }
            if (field.Equals("lastname")) {
                con.LastName = update;
                if (IsContactValid(con))
                {
                    DeleteContact(index);
                    AddContact(con);
                }
                return;
            }
            if (field.Equals("number"))
            {
                Contact tempCont = new Contact(con.Name, con.LastName, update, con.Address);              
                if (IsContactValid(tempCont))
                {
                    con.PhoneNumber = update;
                    DeleteContact(index);
                    AddContact(con);
                    
                    
                }
                return;
            }
            if (field.Equals("address"))
            {
                con.Address = update;
                if (IsContactValid(con))
                {
                    DeleteContact(index);
                    AddContact(con);
                }
                return;
            }

        }
        public Contact retrieveContact(int index) {
            int i = 0;
            foreach (Contact con in MyContacts) {
                if (i == index-1) {
                    return con;
                }
                i++;
            }
            return null;

        }

    }
        
}

