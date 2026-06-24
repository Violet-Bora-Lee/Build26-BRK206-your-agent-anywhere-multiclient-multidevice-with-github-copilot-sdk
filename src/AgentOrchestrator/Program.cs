using AgentOrchestrator;
using AgentOrchestrator.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var dataDir = builder.Environment.IsDevelopment()
    ? AppContext.BaseDirectory
    : Path.Combine(Environment.GetEnvironmentVariable("HOME") ?? AppContext.BaseDirectory, "data");
Directory.CreateDirectory(dataDir);

var dbPath = builder.Configuration["PROPERTY_DB_PATH"];
if (string.IsNullOrWhiteSpace(dbPath))
{
    dbPath = Path.Combine(dataDir, "properties.db");
}
builder.Services.AddDbContextFactory<PropertyDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));
builder.Services.AddSingleton<PropertyDatabase>();
builder.Services.AddSingleton<AppState>();

var app = builder.Build();
PropertyDatabase.EnsureSeeded(app.Services);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
