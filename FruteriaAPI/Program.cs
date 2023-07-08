using FruteriaAPI.Data.Repositories.Core;
using FruteriaAPI.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => 
{
    //options.AddPolicy("default", builder => 
    //{ 
    //    builder.AllowAnyOrigin()
    //    .AllowAnyMethod()
    //    .AllowAnyHeader(); 
    //}); 
    options.AddPolicy("default", builder =>
    {
        builder.WithOrigins("http://example.com",
                                         "http://localhost:4200",
                                         "https://www.example.com")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
    });     
});

//Add dependencies
var connectionString = builder.Configuration.GetConnectionString("Fruteria");
builder.Services.AddSingleton<DbConnectionFactory>(x => new DbConnectionFactory(connectionString));
builder.Services.AddCustomServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
