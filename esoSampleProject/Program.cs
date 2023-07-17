using Microsoft.Extensions.Configuration;


////getting configuration 

//IConfiguration configuration= new ConfigurationBuilder()
//    .AddJsonFile


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


// configuration details
builder.Configuration.AddJsonFile("appsettings.json",optional: false,reloadOnChange: true);
builder.Configuration.AddJsonFile("secrets/Secret.json", optional: true, reloadOnChange: true);
//builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var name = app.Configuration["Name"];
//var name1 = app.Configuration["Logging:LogLevel:Default"];

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
