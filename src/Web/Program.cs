using MusicManagement.Infrastructure.Data;
using MusicManagement.Web.Extensions.Endpoints;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();
builder.Services.AddControllers();
builder.Services.AddSwaggerDocument(config =>
{
    // Configure the Swagger document settings
    config.DocumentName = "v1";
    config.Title = "Music Management";
    config.Version = "v1";
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync(); 
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapFallbackToFile("index.html");
app.UseExceptionHandler(options => { });
app.Map("/", () => Results.Redirect("/swagger/index.html"));
app.MapEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3();
app.Run();

public partial class Program { }
