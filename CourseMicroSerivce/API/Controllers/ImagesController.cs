using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace CourseMicroSerivce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHostEnvironment _env;
        public ImagesController(IWebHostEnvironment hostingEnvironment, IHostEnvironment env)
        {
            _hostingEnvironment = hostingEnvironment;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("No file uploaded.");
                string webRootPath = _env.ContentRootPath;
                string uploadsFolder = Path.Combine(webRootPath, "Uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok("Image uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
       }



        [HttpGet("images/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            var imagePath = Path.Combine(_env.ContentRootPath, "upload", imageName);

            // Check if the image file exists
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            // Read the image file and return it as a response
            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(imageBytes, "image/jpeg"); // Adjust the content type as per your image type
        }

    }
}
