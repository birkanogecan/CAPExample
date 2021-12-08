using CAPExample.UI;
using DotNetCore.CAP.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<PersonHandler>();
//builder.Services.AddSingleton<ISerializer, CAPSerializer>();
builder.Services.AddCap(x =>
{
    x.UseEntityFramework<AppDbContext>();
    x.UseRabbitMQ("localhost");
    x.UseDashboard();
    
    x.FailedRetryCount = 5;
    //x.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
    //x.FailedThresholdCallback = failed =>
    //{
    //    var logger = failed.ServiceProvider.GetService<ILogger<Startup>>();
    //    logger.LogError($@"A message of type {failed.MessageType} failed after executing {x.FailedRetryCount} several times, 
    //                    requiring manual troubleshooting. Message name: {failed.Message.GetName()}");
    //};
}).AddSubscribeFilter<CAPFilter>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
