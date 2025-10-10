namespace StudentAffairs.Application
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ApiResponse<IEnumerable<StudentDto>>> GetAllAsync()
        {
            var students = await _unitOfWork.Repository<Student>().GetAllAsync();
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return ApiResponse<IEnumerable<StudentDto>>.SuccessResult(studentDtos);
        }

        public async Task<ApiResponse<StudentDto>> GetByIdAsync(Guid id)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(id);

            if (student is null)
                return ApiResponse<StudentDto>.ErrorResult($"Student with ID not found.");

            var studentDto = _mapper.Map<StudentDto>(student);
            return ApiResponse<StudentDto>.SuccessResult(studentDto);
        }

        public async Task<ApiResponse<StudentDto>> CreateAsync(CreateStudentDto dto)
        {
            if (dto is null)
                return ApiResponse<StudentDto>.ErrorResult("Student data is required.");

            var entity = _mapper.Map<Student>(dto);
            await _unitOfWork.Repository<Student>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            var studentDto = _mapper.Map<StudentDto>(entity);
            return ApiResponse<StudentDto>.SuccessResult(studentDto);
        }

        public async Task<ApiResponse> UpdateAsync(StudentDto dto)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(dto.Id);

            if (student == null)
                return ApiResponse.ErrorResult("Student not found");

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;
            student.Message = dto.Message;

            await _unitOfWork.SaveChangesAsync();
            return ApiResponse.SuccessResult();
        }

        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(id);
            if (student is null)
                return ApiResponse.ErrorResult($"Student with ID not found.");

            _unitOfWork.Repository<Student>().Delete(student);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse.SuccessResult();
        }
    }
}
