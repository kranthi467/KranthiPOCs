using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {
        private List<Contact> contacts = new List<Contact>
        {
            new Contact {Id=1,Name="ABC",Gender="M" },
            new Contact {Id=2,Name="DEF" ,Gender="F" }
        };

        
        [WebGet(UriTemplate = "/contact/{id}")]
        public Contact GetContact(int id)
        {
            Contact contact = contacts.Find(_ => _.Id == id); ;        
            return contact;
        }

       
        [WebInvoke(Method = "PUT", UriTemplate = "/contact/{id}")]
        public bool PutContact(int id, Contact contactRequest)
        {
            var contact = contacts.FirstOrDefault(_ => _.Id == id);
            if(contact!=null)
            {
                contact.Name = contactRequest.Name;
                contact.Gender = contactRequest.Gender;
                return true;
            }
            return false;
        }

      
        [WebInvoke(Method = "DELETE", UriTemplate = "/contact/{id}")]
        public bool DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(_ => _.Id == id);
            if (contact != null)
            {
                return contacts.Remove(contact);
            }
            return false;
        }
    }
}

