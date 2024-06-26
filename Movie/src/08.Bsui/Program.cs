using FluentValidation;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using System.Reflection;
using Zeta.Movie.Bsui.Common.Constants;
using Zeta.Movie.Bsui.Services;
using Zeta.Movie.Bsui.Services.Logging;
using Zeta.Movie.Client;
using Zeta.Movie.Shared;
using Zeta.Movie.Shared.Common.Constants;

Console.WriteLine($"Starting {CommonValueFor.EntryAssemblySimpleName}...");

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLoggingService();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddShared();
builder.Services.AddClient(builder.Configuration);
builder.Services.AddBsui(builder.Configuration);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Running {AssemblyName}", CommonValueFor.EntryAssemblySimpleName);

if (app.Environment.IsEnvironment(EnvironmentNames.Local) || app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage(CommonRouteFor.Host);
app.Run();
