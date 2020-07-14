using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
namespace visma
{
    public class Loader
    {
        public Loader()
        {
        }

        public static ArrayList loadContacts() {
            if (!File.Exists("contacts.txt")) {
                File.Create("contacts.txt");
                    }
            var formatter = new BinaryFormatter();
            ArrayList list = new ArrayList();
            Stream str = new FileStream("contacts.txt", FileMode.OpenOrCreate, FileAccess.Read);
            if (str.Length == 0) {
                return list;
            }
           list = (ArrayList) formatter.Deserialize(str);
            return list;
        }

        public static void saveContacts(ArrayList list) {
            Stream stream = new FileStream("contacts.txt", FileMode.Open, FileAccess.Write);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, list);
        }

    }
}
