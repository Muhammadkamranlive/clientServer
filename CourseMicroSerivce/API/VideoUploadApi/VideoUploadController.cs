using AutoMapper;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using CourseMicroSerivce.Models.TeacherPortal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Controllers;

namespace CourseMicroSerivce.API.VideoUploadApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoUploadController : ParentController<VideoContent,VideoModel>
    {
        private const string UploadsFolder = "Video";
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IVideo_Service      _videoService;
        private readonly IMapper             _mapper;
        public VideoUploadController
        (
            IVideo_Service video_Service,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment
        ) :base(video_Service,mapper)
        {
                _webHostEnvironment = webHostEnvironment;
                _videoService       = video_Service;
                _mapper = mapper;
        }

        [HttpPost()]
        [Route("CourseVideoUpload")]
        public async Task<IActionResult> CourseVideoUpload([FromForm] VideoWrapperModel videoModel)
        {
            if (videoModel.VideoFile == null || videoModel.VideoFile.Length == 0)
            {
                return BadRequest("Invalid video file");
            }

            var uniqueFileName = $"{Guid.NewGuid().ToString()}_{videoModel.VideoFile.FileName}";
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, UploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await videoModel.VideoFile.CopyToAsync(fileStream);
            }

            var videoUrl = uniqueFileName;
           
            if (videoUrl!="")
            {
                VideoModel ob= new VideoModel()
                {
                    Title=videoModel.Title,
                    SchoolCourseId=videoModel.SchoolCourseId,
                    status=videoModel.Status,
                    video=videoUrl
                };
                await genericService.InsertAsync(_mapper.Map<VideoContent>(ob));
                await genericService.CompleteAync();
                var message = "Data Inserted Successfully for " + typeof(VideoModel)?.Name;
                return Content($"{{ \"message\": \"{message}\" }}", "application/json");
            }

            return BadRequest("Video not uploaded");
           
        }

        [HttpGet()]
        [Route("getVideo")]
        public IActionResult GetVideo(string fileName)
        {
            var video = "Video/"+fileName;
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, UploadsFolder, fileName);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return File(stream, "video/mp4"); 
        }

    }
}
