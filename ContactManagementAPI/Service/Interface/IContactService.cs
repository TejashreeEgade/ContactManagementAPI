using ContactManagementAPI.Model;

namespace ContactManagementAPI.Service
{
    public interface IContactService
    {
        public bool CreateContact(ContactModel model);
        public ContactModel GetContactById(int id);
        public List<ContactModel> GetAllContacts();
        public bool UpdateContact(ContactModel model);
        public bool DeleteContact(int id);
    }
}
