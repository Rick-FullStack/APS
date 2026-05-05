using APS.Components;
using APS.Hubs;
using APS.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddSignalR();

builder.Services.AddSingleton<TcpServerService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<TcpServerService>());

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.MapHub<EnvironmentalHub>("/environmentalHub");

app.Run();