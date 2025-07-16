using Infrastructure;
using Application;
using Presentation.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers().AddApplicationPart(typeof(StudentController).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddApplicationPart(typeof(StudentController).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration).AddApplication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMe", policy =>
    {
        policy.WithOrigins("https://localhost:7181")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowMe");
app.UseAuthorization();

app.MapControllers();

app.Run();
