namespace StudentsAffairsWebAPI;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : BaseController<Applicant>
{
    public DoctorsController(StudentsAffairsDbContext studentsAffairsDbContext) : base(studentsAffairsDbContext)
    {
    }
}
