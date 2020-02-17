using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Group2Photo.Model;


namespace Group2.Controllers
{
    [ApiController]
    [Route("photo")]
    public class PhotoController : ControllerBase
    { 
        private static List<UserPhoto> Photos = new List<UserPhoto>()
        {
            new UserPhoto{Id=1, Caption="hello", Url= "banana.io", Contact_Id= 1},
            new UserPhoto{Id=2, Caption="hello", Url= "banana.io", Contact_Id= 2},
            new UserPhoto{Id=3, Caption="hello", Url= "banana.io", Contact_Id= 3},
            new UserPhoto{Id=4, Caption="hello", Url= "banana.io", Contact_Id= 4},
            new UserPhoto{Id=5, Caption="hello", Url= "banana.io", Contact_Id= 5}
        };

        private readonly ILogger<PhotoController> _logger;

        public PhotoController(ILogger<PhotoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Photos);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(Photos.Find(e => e.Id == id));
        }

        [HttpPost]
        public IActionResult AddANewPhoto(PhotoRequest user)
        {
            var userAdd = new UserPhoto(){Id=6, Caption=user.Caption, Url= user.Url, Contact_Id= 6};

            Photos.Add(userAdd);

            return Ok(new {status = "success", message = "success add Data", data = Photos});
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAPhoto(int id)
        {
            return Ok(Photos.RemoveAll(e => e.Id == id));
        }

        // [HttpPatch("{id})")]
        // public IActionResult UpdateCaption(PhotoRequest user, int id)
        // {
        //     return Ok(Photos.Find(e => e.Id == id));
        // }
    }

}

