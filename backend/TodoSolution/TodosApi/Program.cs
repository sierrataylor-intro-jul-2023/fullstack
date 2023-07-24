using Marten;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => 
    { 
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dataConnectionString = builder.Configuration.GetConnectionString("todos") ?? throw new Exception("Need a database connection string");
builder.Services.AddMarten(options =>
{
    options.Connection(dataConnectionString);
    Console.WriteLine($"Using the connection string {dataConnectionString}");
    options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All; //good for development environment- creates enverything
}); //add marten database without hard coding db info in the application

//everything above this line is configuring "Services" in the application
var app = builder.Build();
/*
 this is configuring the moddleware- this code will
 see the incoming HTTP request and make a response
 */

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //this is OpenAPI (Swagger)- it generates the API documentation in a JSON file
    app.UseSwaggerUI(); //adds middleware that lets you interact with the documentation
}

app.UseAuthorization();

app.MapControllers(); //during startup, the API looks through our controllers folder, reads those attributes, and creates a "route table"

app.Run(); //start teh Kestrel web server and listen for requests
