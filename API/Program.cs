using API.Exceptions;
using Application;
using Infrastructure;
using Presentation.Controllers;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseExceptionHandler();

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
