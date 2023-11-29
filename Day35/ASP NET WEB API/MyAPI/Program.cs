using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => {
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
               // In addition, you can limit the depth
               // options.MaxDepth = 4;
            });;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDb>(options =>
{
	options.UseSqlite(builder.Configuration.
	GetConnectionString("DefaultConnection"));
});
            
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
