using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Webapi_01.Models;

namespace Webapi_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsadsController : Controller
    {
            
           
            private static List<Postads> posts = new List<Postads>();
            private static int idCounter = 1;

            // Get all posts
            [HttpGet]
            public ActionResult<IEnumerable<Postads>> GetPosts()
            {
                return Ok(posts);
            }

            // Create a new post with an image upload
            [HttpPost("upload")]
            public async Task<IActionResult> CreatePost([FromForm] string title, [FromForm] string description, [FromForm] IFormFile image)
            {
                if (image == null || image.Length == 0)
                    return BadRequest("Image is required");

                // Save the image to wwwroot/uploads
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                Directory.CreateDirectory(uploadsPath);
                var filePath = Path.Combine(uploadsPath, image.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                // Create the new post
                var post = new Postads
                {
                    Id = idCounter++,
                    Title = title,
                    Description = description,
                    ImageUrl = $"/uploads/{image.FileName}"
                };

                posts.Add(post);
                return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, post);
            }
        }
    }