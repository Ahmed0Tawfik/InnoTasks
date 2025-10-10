namespace StudentAffairs.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _studentService.GetAllAsync();
        
        if (response.Success)
            return Ok(response);
        
        return BadRequest(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _studentService.GetByIdAsync(id);
        
        if (response.Success)
            return Ok(response);
        
        return NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
    {
        var response = await _studentService.CreateAsync(dto);

        if (response.Success)
            return Ok(response);
        
        return BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] StudentDto dto)
    {
        var response = await _studentService.UpdateAsync(dto);
        
        if (response.Success)
            return Ok(response);
        
        return BadRequest(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _studentService.DeleteAsync(id);
        
        if (response.Success)
            return Ok(response);
        
        return BadRequest(response);
    }
}
