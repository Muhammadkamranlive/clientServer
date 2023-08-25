using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class VideoPost_Repo : Repo<VideoContent>, IVideoPost_Repo
    {
        public VideoPost_Repo(SchoolContext coursecontext) : base(coursecontext)
        {

        }
    }
    
}
