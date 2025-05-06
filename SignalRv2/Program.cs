using Microsoft.AspNetCore.ResponseCompression;
using SignalRv2.Hubs;
using SignalRv2.Client.Pages;
using SignalRv2.Components;
using SignalRv2.Client.ChatServices;
using SignalRv2.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SignalRv2.Repos;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<ChatRepo>();
builder.Services.AddSignalR();
builder.Services.AddScoped<ChatService>();
builder.Services.AddHttpClient();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        ["application/octet-stream"]);
});




var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SignalRv2.Client._Imports).Assembly);
app.MapControllers();
app.MapHub<ChatHub>("/chathub");

app.Run();
