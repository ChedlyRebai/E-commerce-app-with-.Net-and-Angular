using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();


builder.Services.AddSwaggerGen();

// Add controllers
builder.Services.AddControllers();

// Register infrastructure services
builder.Services.infrastructureRegistration(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root (optional)
    });
}
// var connectionString = builder.Configuration.GetConnectionString("GameStore");
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseMySql(
//         connectionString, ServerVersion.AutoDetect(connectionString)
//     ));

app.MapControllers();
app.Run();