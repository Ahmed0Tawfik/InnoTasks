namespace StudentAffairs.Application; 


public interface IStudentService
{
    Task<ApiResponse<IEnumerable<StudentDto>>> GetAllAsync();
    Task<ApiResponse<StudentDto>> GetByIdAsync(Guid id);
    Task<ApiResponse<StudentDto>> CreateAsync(CreateStudentDto dto);
    Task<ApiResponse> UpdateAsync(StudentDto dto);
    Task<ApiResponse> DeleteAsync(Guid id);
}
