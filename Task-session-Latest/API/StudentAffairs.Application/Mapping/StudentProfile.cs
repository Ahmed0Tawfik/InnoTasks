namespace StudentAffairs.Application;
public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDto>().ReverseMap();

        CreateMap<CreateStudentDto, Student>();
    }
}
