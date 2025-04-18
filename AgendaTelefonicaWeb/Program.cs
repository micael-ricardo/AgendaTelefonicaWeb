using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AgendaTelefonicaWeb.Data;
using AgendaTelefonicaWeb.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AgendaTelefonicaWebContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("AgendaTelefonicaWebContext") ?? throw new InvalidOperationException("Connection string 'AgendaTelefonicaWebContext' not found."),
    MySqlServerVersion.AutoDetect(builder.Configuration.GetConnectionString("AgendaTelefonicaWebContext"))));



// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<TelefoneService>();
builder.Services.AddScoped<ContatoService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contatoes}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
