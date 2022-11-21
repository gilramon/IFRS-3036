using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;



namespace Monitor
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneBookContact
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Contact_Name")]
        public string Name;
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Contact_Phone")]
        public string Phone;
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Contact_Notes")]
        public string Notes;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Contact_Password")]
        public string Password;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Contact_UnitID")]
        public string UnitID;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + " (" + Phone + ")" + "[" + Notes + "]";
        }
    }

    class PhoneBook
    {
        List<PhoneBookContact> Contacts = new List<PhoneBookContact>();
        public PhoneBook(string[] i_Phones)
        {
            try
            {
                foreach (string str in i_Phones)
                {
                    PhoneBookContact Contact = new PhoneBookContact();

                    string[] strsplit = str.Split(new string[] { ";;;;" }, StringSplitOptions.None);
                    Contact.Phone = strsplit[0];
                    Contact.Name = strsplit[1];
                    Contact.Notes = strsplit[2];
                    Contact.Password = strsplit[3];
                    Contact.UnitID = strsplit[4];

                    Contacts.Add(Contact);

                }
            }
            catch
            {

            }
        }

        public void SortPhoneBookByNotes()
        {
            Contacts = Contacts.OrderBy(q => q.Notes).ToList();
        }

        public PhoneBook(List<PhoneBookContact> i_Phones)
        {
            Contacts = i_Phones.ToList();
        }

        public void AddContactToPhoneBook(PhoneBookContact i_Contact)
        {
            Contacts.Add(i_Contact);
        }

        public void RemoveContactFromPhoneBook(PhoneBookContact i_Contact)
        {
            Contacts.Remove(i_Contact);
        }

        public PhoneBookContact IsNumberExist(string i_Number)
        {
            foreach (PhoneBookContact cont in Contacts)
            {
                if (cont.Phone == i_Number)
                {
                    return cont;
                }
            }
            return null;
        }

        public PhoneBookContact GetContactByUnitID(string i_UnitID)
        {
            foreach (PhoneBookContact cont in Contacts)
            {
                if (cont.UnitID == i_UnitID)
                {
                    return cont;
                }
            }
            return null;
        }

        public List<PhoneBookContact> GetContacts()
        {
            return Contacts;
        }

        //static void SerializeToXML(List<PhoneBookContact> movies)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<PhoneBookContact>));
        //    TextWriter textWriter = new StreamWriter(@".\PhoneContacts.xml");
        //    serializer.Serialize(textWriter, movies);
        //    textWriter.Close();
        //}

        //static List<PhoneBookContact> DeserializeFromXML()
        //{
        //    XmlSerializer deserializer = new XmlSerializer(typeof(List<PhoneBookContact>));
        //    TextReader textReader = new StreamReader(@".\PhoneContacts.xml");
        //    List<PhoneBookContact> movies;
        //    movies = (List<PhoneBookContact>)deserializer.Deserialize(textReader);
        //    textReader.Close();

        //    return movies;
        //}
        public void ExportToXML(Stream myStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PhoneBookContact>));
            TextWriter textWriter = new StreamWriter(myStream);
            serializer.Serialize(textWriter, Contacts);
            textWriter.Close();
        }

        public void ImportToXML(string i_Name)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<PhoneBookContact>));
            TextReader textReader = new StreamReader(i_Name);
            List<PhoneBookContact> ImportedContacts;
            ImportedContacts = (List<PhoneBookContact>)deserializer.Deserialize(textReader);
            textReader.Close();

            foreach (PhoneBookContact Contact in ImportedContacts)
            {
                Contacts.Add(Contact);
            }

        }



    }
}
