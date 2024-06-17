using ContactManagementAPI.Model;
using ContactManagementAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;


namespace ContactManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        ContactService _contactService = new ContactService();      
        // GET api/<ContactsController>/1
        [HttpGet("{id}")]
        public ActionResult GetContactById(int id)
        {
            var data = _contactService.GetContactById(id);
            if (data.ID == 0)
                return NoContent();
            else
                return Ok(data);    
        }

        [HttpGet]
        public ActionResult GetAllContacts()
        {
            var data = _contactService.GetAllContacts();
            if (data == null)
                return NoContent();
            else
                return Ok(data);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public ActionResult CreateContact([FromBody] ContactModel model)
        {
            var result = _contactService.CreateContact(model);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Update([FromBody] ContactModel model)
        {
            var result = _contactService.UpdateContact(model);
            return Ok(result);
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var result = _contactService.DeleteContact(id);
        }
    }
}
