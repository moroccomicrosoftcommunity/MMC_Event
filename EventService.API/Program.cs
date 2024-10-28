using Azure.Storage.Blobs;
using EventServices.API.Services;
using EventServices.Application;
using EventServices.Infrastructure;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;
using System.Text.Json.Serialization;
//
var options = new WebApplicationOptions
{
    WebRootPath = "wwwroot" // Sets the default web root folder
};
var builder = WebApplication.CreateBuilder(options);
//var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseWebRoot("wwwroot");
#region Serialization
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.Configure<JsonSerializerOptions>(options =>
{
    options.ReferenceHandler = ReferenceHandler.Preserve;
});
#endregion
builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration.GetConnectionString("StorageAccount")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin();
    });
});
builder.Services.AddScoped<IRabbitMQ, RpcClient>();
builder.Services.AddScoped<IEventSpeakers, EventSpeakers>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

string filesDirectory = Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "Files");
if (!Directory.Exists(filesDirectory))
{
    Directory.CreateDirectory(filesDirectory);
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(filesDirectory),
    RequestPath = "/Resources"
});

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();