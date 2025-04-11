using Api.Middleware;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options=>{
    options.AddPolicy("CORSPolicy",builder =>{
        builder.AllowAnyHeader().
        AllowAnyMethod().
        AllowCredentials().
        WithOrigins("http://localhost:4200");
    });
});


builder.Services.AddMemoryCache();

builder.Services.AddOpenApi();


builder.Services.AddSwaggerGen();

// Add controllers
builder.Services.AddControllers();

// Register infrastructure services
builder.Services.infrastructureRegistration(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
app.UseCors("CORSPolicy");
app.UseStaticFiles();
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

// var connectionString = builder.Configuration.GetConnectionString("GameStore");
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseMySql(
//         connectionString, ServerVersion.AutoDetect(connectionString)
//     ));

app.MapControllers();
app.Run();