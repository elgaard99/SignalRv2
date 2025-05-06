using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SignalRv2.Client.ChatServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<ChatService>();
await builder.Build().RunAsync();
