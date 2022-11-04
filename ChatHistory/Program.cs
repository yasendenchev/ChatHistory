using ChatHistory.Domain.Services.Interfaces;
using ChatHistory.Infrastructure.Data;
using ChatHistory.Infrastructure.Services;
using ChatHistory.Infrastructure.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IChatEventsService, ChatEventService>();
builder.Services.AddScoped<IChatEventRepository, ChatEventRepository>();
builder.Services.AddScoped<IChatEventContext, ChatEventContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
