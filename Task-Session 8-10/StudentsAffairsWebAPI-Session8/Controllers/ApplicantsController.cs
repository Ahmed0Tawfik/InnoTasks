namespace StudentsAffairsWebAPI;

[Route("api/[controller]")]
[ApiController]
public class ApplicantsController : BaseController<Applicant>
{
    public ApplicantsController(StudentsAffairsDbContext studentsAffairsDbContext) : base(studentsAffairsDbContext)
    {
    }

    [HttpGet("ApplicantsOverForty")]
    public IEnumerable<Applicant> GetApplicantsOverForty()
    {
        return _studentsAffairsDbContext.Set<Applicant>().Where(e => e.Age >= 40).ToList() ?? new();
    }

    //override public IActionResult Post([FromBody] Applicant entity)
    //{
    //    throw new NotImplementedException();
    //}

}
