var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<EmployeeManagementApi.Services.LiteDbService>();

var app = builder.Build();

app.UseCors("AllowAll");
app.MapControllers();

app.Run();