using ContactManagementAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace ContactManagementAPI.Service
{
    public class ContactService : IContactService
    {
        private readonly string jsonPath = "contact.json";
        public bool CreateContact(ContactModel model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                List<ContactModel> contacts = new List<ContactModel>();
                if (System.IO.File.Exists(jsonPath))
                {
                    var json = System.IO.File.ReadAllText(jsonPath);
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json) ?? new List<ContactModel>();
                }
                if (contacts.Any())
                {
                    model.ID = contacts.Max(x => x.ID) + 1;
                }
                else
                {
                    model.ID = 1;
                }
                contacts.Add(model);
                System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(contacts, Formatting.Indented));
           
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public ContactModel GetContactById(int id)
        {
            var result = new ContactModel();
            try
            {
               List<ContactModel> contacts = new List<ContactModel>();
                if (System.IO.File.Exists(jsonPath))
                {
                    var json = System.IO.File.ReadAllText(jsonPath);
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json) ?? new List<ContactModel>();
                }
                var contact = contacts.FirstOrDefault(x => x.ID == id);
                if (contact != null)
                {
                    result = JsonConvert.DeserializeObject<ContactModel>(JsonConvert.SerializeObject(contact));
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return result;
        }

        public List<ContactModel> GetAllContacts()
        {
            var result = new List<ContactModel>();
            try
            {
                if (System.IO.File.Exists(jsonPath))
                {
                    var json = System.IO.File.ReadAllText(jsonPath);
                    result = JsonConvert.DeserializeObject<List<ContactModel>>(json) ?? new List<ContactModel>();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool UpdateContact(ContactModel model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                List<ContactModel> contacts = new List<ContactModel>();
                if (System.IO.File.Exists(jsonPath))
                {
                    var json = System.IO.File.ReadAllText(jsonPath);
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json) ?? new List<ContactModel>();
                }
                var contactId = contacts.FirstOrDefault(x => x.ID == model.ID);
                if (contactId != null)
                {
                    contactId.FirstName = model.FirstName;  
                    contactId.LastName = model.LastName;
                    contactId.Email = model.Email;
                }
                System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(contacts, Formatting.Indented));
               
            }
            catch (Exception ex) {
                throw ex;
            }
            return true;
        }

        public bool DeleteContact(int Id)
        {
            try
            {
                var result = new ContactModel();
                List<ContactModel> contacts = new List<ContactModel>();
                if (System.IO.File.Exists(jsonPath))
                {
                    var json = System.IO.File.ReadAllText(jsonPath);
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json) ?? new List<ContactModel>();
                }
                var contact = contacts.FirstOrDefault(x => x.ID == Id);
                contacts.Remove(contact);
                System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeObject(contacts, Formatting.Indented));
            }
            catch (Exception ex) {
                throw ex;
            }
            return true;
        }
    }
}
