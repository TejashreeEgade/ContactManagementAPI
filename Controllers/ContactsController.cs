using ContactManagementAPI.Model;
using ContactManagementAPI.Service;
using Microsoft.AspNetCore.Cors;
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
        [HttpGet,Route("GetContactById/{id}")]
        public ActionResult GetContactById(int id)
        {
            var data = _contactService.GetContactById(id);
            if (data.ID == 0)
                return NoContent();
            else
                return Ok(data);    
        }


        [HttpGet,Route("GetAllContacts")]
        public ActionResult GetAllContacts()
        {
            var data = _contactService.GetAllContacts();
            if (data == null)
                return NoContent();
            else
                return Ok(data);
        }

        // POST api/<ContactsController>
        [HttpPost,Route("CreateContact")]
        public ActionResult CreateContact([FromBody] ContactModel model)
        {
            var result = _contactService.CreateContact(model);
            return Ok(result);
        }

        [HttpPut,Route("Update")]
        public ActionResult Update([FromBody] ContactModel model)
        {
            var result = _contactService.UpdateContact(model);
            return Ok(result);
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete,Route("Delete/{id}")]
        public void Delete(int id)
        {
            var result = _contactService.DeleteContact(id);
        }
    }
}
