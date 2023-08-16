using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroSerivce.API.TeacherAPI
{
    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private const string UploadsFolder = "UploadedImages"; // Update the folder name

        [HttpPost]
        public IActionResult UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file selected or invalid file.");
            }

            // Generate a unique file name for the uploaded image
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(UploadsFolder, fileName);
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            // Save the file to the server
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Return the URL to access the uploaded image
            string imageUrl = $"/{UploadsFolder}/{fileName}"; // Use relative URL

            return Ok(new { imageUrl });
        }
    }


}
