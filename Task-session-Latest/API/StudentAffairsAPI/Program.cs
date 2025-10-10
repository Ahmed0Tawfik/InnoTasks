using StudentAffairs.API.Filters;

namespace StudentAffairsAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<ValidationFilter>();
        });
        
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddApplicationDbContext(builder.Configuration);
        builder.Services.AddRepositories();



      
        builder.Services.AddValidatorsFromAssembly(typeof(CreateStudentDto).Assembly);

        builder.Services.AddApplicationServices();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy
                    .AllowAnyOrigin()   
                    .AllowAnyMethod()   
                    .AllowAnyHeader();  
            });
        });


        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseCors("AllowAll");


        app.UseMiddleware<ExceptionMiddleware>();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
