using Microsoft.EntityFrameworkCore;
using test;
using test.Repository;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

/*
builder.Services.AddScoped<IStudentRepository, StudentRepositoryInMemory>();
*/
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddControllers();

var connectionstring = builder.Configuration.GetConnectionString("MyDatabase");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();