using Microsoft.EntityFrameworkCore;
using racing_webApp.Data;
using racing_webApp.Helpers;
using racing_webApp.Inerfaces;
using racing_webApp.Repository;
using racing_webApp.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Db_context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IClubRepo, ClubRepo>();
builder.Services.AddScoped<IRaceRepo, RaceRepo>();
builder.Services.AddScoped<IphotoService, PhotoService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    // todo: add sycn user and roles later
    Seed.SeedData(app);
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
