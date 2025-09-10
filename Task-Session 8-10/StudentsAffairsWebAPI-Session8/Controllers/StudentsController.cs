//EntityFramework8 ORM object relational mapper =>
//DDL(Create table, Alter view, drop table),
//DML(Insert,Select,Update,Delete),
//DCL(Grant Update on table students to wael,revoke)

namespace StudentsAffairsWebAPI;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    Student student = new();
    const int maxStudentsCount = 15;
    private readonly StudentsAffairsDbContext _studentsAffairsDbContext;
    public StudentsController(StudentsAffairsDbContext studentsAffairsDbContext)
    {
        _studentsAffairsDbContext = studentsAffairsDbContext;

        if (_studentsAffairsDbContext.Students is null || !_studentsAffairsDbContext.Students.Any())
            FillStudents(maxStudentsCount);
    }
    public void FillStudents(int desiredCount)
    {
        for (int i = 1; i <= desiredCount; i++)
        {
            Student student = new() { Id = i, Name = $"Student{i}", Age = Convert.ToByte(i + 30), Mobile = $"012784512{i}" };
            _studentsAffairsDbContext.Students.Add(student);
        }

        _studentsAffairsDbContext.SaveChanges();
    }

    [HttpPost]
    public IActionResult Post([FromBody] Student student)
    {
        _studentsAffairsDbContext.Students.Add(student);
        _studentsAffairsDbContext.SaveChanges();

        return Created();
    }

    [HttpGet]
    public IEnumerable<Student> GetAll()
    {
        return _studentsAffairsDbContext.Students.ToList() ?? new();
    }


    [HttpGet("{id}")]
    public IActionResult GetBuId([FromRoute] string id)
    {
        bool isParsedAsInt = int.TryParse(id, out int idParsed);
        if (!isParsedAsInt)
            return BadRequest($"The value {id} can't be parsed as int");

        try
        {
            Student? studentFromDb = _studentsAffairsDbContext.Students.FirstOrDefault(e => e.Id.Equals(idParsed));

            return Ok(studentFromDb);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] Student student)
    {
        if (student is null || string.IsNullOrEmpty(student.Name)) throw new Exception("The student can't be null or its name can't be empty");

        try
        {
            Student? studentFromDB = _studentsAffairsDbContext.Students.FirstOrDefault(e => e.Id.Equals(student.Id));
            
            if (studentFromDB is null) return NotFound(student);

            studentFromDB.Name = student.Name;
            studentFromDB.Age = student.Age;
            studentFromDB.Mobile = student.Mobile;

            _studentsAffairsDbContext.Students.Update(studentFromDB);
            _studentsAffairsDbContext.SaveChanges();

            return Ok(studentFromDB);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        bool isParsedAsInt = int.TryParse(id, out int idParsed);
        if (!isParsedAsInt)
            return BadRequest($"The value {id} can't be parsed as int");

        try
        {
            Student? toBeDeletedStudent = _studentsAffairsDbContext.Students.FirstOrDefault(e => e.Id.Equals(idParsed));

            if (toBeDeletedStudent is not null)
            {
                _studentsAffairsDbContext.Students.Remove(toBeDeletedStudent);
                _studentsAffairsDbContext.SaveChanges();
            }

            return Ok(toBeDeletedStudent);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
    [HttpDelete]
    public IActionResult Delete([FromBody] Student student)
    {
        if (student is null) throw new Exception("The student can't be null");

        try
        {
            Student? studentFromDB = _studentsAffairsDbContext.Students.FirstOrDefault(e => e.Id.Equals(student.Id));
            if (studentFromDB is null) return NotFound(student);

            _studentsAffairsDbContext.Students.Remove(studentFromDB);

            return Ok(student);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
}
