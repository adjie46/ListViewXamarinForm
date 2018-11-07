using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    

    public class Contact
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }

    }

    public class ContactList
    {
        public List<Contact> foos { get; set; }
    }
}
