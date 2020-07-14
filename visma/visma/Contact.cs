using System;
namespace visma
{
    [Serializable]
    public class Contact
    {

        public Contact(string name,string lastName, string phoneNumber, string address)
        {
            this.LastName = lastName;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
        }
        public Contact(string name, string lastName, string phoneNumber)
        {
            this.LastName = lastName;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        
    }
}
