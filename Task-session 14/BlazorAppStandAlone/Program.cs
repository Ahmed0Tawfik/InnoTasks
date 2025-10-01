var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddValidatorsFromAssemblyContaining<StudentValidator>();

builder.Services.AddScoped<IApiClient>(provider =>
    new ApiClient("https://students.innopack.app/api/students"));


await builder.Build().RunAsync();
