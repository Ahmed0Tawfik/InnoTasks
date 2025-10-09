var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddValidatorsFromAssemblyContaining<StudentValidator>();

builder.Services.AddScoped<IApiClient>(provider =>
    new ApiClient("https://localhost:7058/api/Student"));


await builder.Build().RunAsync();
