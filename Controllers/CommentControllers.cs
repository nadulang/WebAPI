using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Group2Comment.Model;
using Microsoft.AspNetCore.JsonPatch;


namespace Group2.Controllers
{
    [ApiController]
    [Route("comment")]
    public class CommentController : ControllerBase
    { 
        private static List<UserComment> Comments = new List<UserComment>()
        {
            new UserComment{Id=1, Content="Return the DVD", Photo_Id=1, Contact_Id= 1},
            new UserComment{Id=2, Content="Return the DVD", Photo_Id=2, Contact_Id= 2},
            new UserComment{Id=3, Content="Return the DVD", Photo_Id=3, Contact_Id= 3},
            new UserComment{Id=4, Content="Return the DVD", Photo_Id=4, Contact_Id= 4},
            new UserComment{Id=5, Content="Return the DVD", Photo_Id=1, Contact_Id= 5}
        };

        private readonly ILogger<CommentController> _logger;

        public CommentController(ILogger<CommentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Comments);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(Comments.Find(e => e.Id == id));
        }

        [HttpPost]
        public IActionResult AddANewComment(CommentRequest user)
        {
            var userAdd = new UserComment(){Id=6, Content=user.Content, Photo_Id=6, Contact_Id= 6};

            Comments.Add(userAdd);

            return Ok(new {status = "success", message = "success add Data", data = Comments});
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAComment(int id)
        {
            return Ok(Comments.RemoveAll(e => e.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult patchComment( [FromBody]JsonPatchDocument<UserComment> patchComment, int id)
        {
            patchComment.ApplyTo(Comments.Find(e => e.Id == id));
            return Ok(Comments.Find(e => e.Id == id));
        }
    }

}

