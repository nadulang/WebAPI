using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Group2Contact.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace Group2.Controllers
{
    [ApiController]
    [Route("contact")]
    public class ContactController : ControllerBase
    { 
        private static List<UserContact> Contacts = new List<UserContact>()
        {
            new UserContact{Id=1, Username="darwinwatterson", Password="sassywizard", Email="darwin.watterson@elmoreplus.com", Full_name="Darwin Watterson"},
            new UserContact{Id=2, Username="darwinwatterson", Password="sassywizard", Email="darwin.watterson@elmoreplus.com", Full_name="Darwin Watterson"},
            new UserContact{Id=3, Username="darwinwatterson", Password="sassywizard", Email="darwin.watterson@elmoreplus.com", Full_name="Darwin Watterson"},
            new UserContact{Id=4, Username="darwinwatterson", Password="sassywizard", Email="darwin.watterson@elmoreplus.com", Full_name="Darwin Watterson"},
            new UserContact{Id=5, Username="darwinwatterson", Password="sassywizard", Email="darwin.watterson@elmoreplus.com", Full_name="Darwin Watterson"}

        };

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Contacts);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(Contacts.Find(e => e.Id == id));
        }

        [HttpPost]
        public IActionResult AddANewContact(ContactRequest user)
        {
            var userAdd = new UserContact(){Id=6, Username=user.Username, Password=user.Password, Email=user.Email, Full_name=user.Full_name};

            Contacts.Add(userAdd);

            return Ok(new {status = "success", message = "success add Data", data = Contacts});
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAContact(int id)
        {
            return Ok(Contacts.RemoveAll(e => e.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult patchContact( [FromBody]JsonPatchDocument<UserContact> patchContact, int id)
        {
            patchContact.ApplyTo(Contacts.Find(e => e.Id == id));
            return Ok(Contacts.Find(e => e.Id == id));
        }


    }
	

}

