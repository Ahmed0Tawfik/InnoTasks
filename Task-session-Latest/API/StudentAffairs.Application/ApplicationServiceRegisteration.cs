namespace StudentAffairs.Application;

public static class ApplicationServiceRegisteration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentService,StudentService>();
        services.AddAutoMapper(cfg => { }, typeof(StudentValidator));
    }

}
