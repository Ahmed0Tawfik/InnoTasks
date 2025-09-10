using StudentsAffairsWebAPI;

const string corsPolicy = "allowAllOrigins";

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//List<Teacher>? teachers = new List<Teacher>();
//builder.Services.AddSingleton(teachers);

string connectingString =
    "Data Source=.;Initial Catalog=StudentsAffairsDB;User Id=omar;Password=O@123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;";

builder.Services.AddDbContext<StudentsAffairsDbContext>(options => options
                .UseSqlServer(connectingString)
                .EnableServiceProviderCaching()
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .EnableThreadSafetyChecks());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
       .AddCors(corsOptions => corsOptions
       .AddPolicy(corsPolicy , corsPlicyBuilder => corsPlicyBuilder
       .AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod()));

WebApplication? webApplication = builder.Build();

webApplication.UseCors(corsPolicy);

// Configure the HTTP request pipeline.
if (webApplication.Environment.IsDevelopment())
{
    webApplication.UseSwagger();
    webApplication.UseSwaggerUI();
}

webApplication.UseHttpsRedirection();

webApplication.UseAuthorization();

webApplication.MapControllers();

webApplication.Run();
