using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TRY;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApi.Helpers.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase") ?? throw new InvalidOperationException("Connection string 'WebApiDatabase' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
 app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=users}/{action=Index}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "FrontPage",
        pattern: "users/FrontPage/{id}/{nic}/{Loyalty}",
        defaults: new { controller = "users", action = "FrontPage" });

    // Additional endpoints can be defined here if needed
});

app.Run();
