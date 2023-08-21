using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;


////getting configuration 

//IConfiguration configuration= new ConfigurationBuilder()
//    .AddJsonFile


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


// configuration details
builder.Configuration.AddJsonFile("appsettings.json",optional: false,reloadOnChange: true);
builder.Configuration.AddJsonFile("secrets/secrets.json", optional: true, reloadOnChange: true);
//builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddMvc(options => options.EnableEndpointRouting = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
    

var app = builder.Build();


app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
    });
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
});

var name = app.Configuration["firstname01"];
//var name1 = app.Configuration["Logging:LogLevel:Default"];

//add opentelemetry custome loggin


//var appResourceBuilder= ResourceBuilder.CreateDefault().AddService("esoSampleProject","1.0");
//using var loggerFactory = LoggerFactory.Create(builder =>
//{
//    builder.AddOpenTelemetry(options =>
//    {
//        options.SetResourceBuilder(appResourceBuilder);
//        options.AddOtlpExporter(options =>
//        {
//            options.Endpoint = new Uri("http://otel-collector.otel.svc.cluster.local:4317");
//        });
//    });
//});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
