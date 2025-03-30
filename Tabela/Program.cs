using Microsoft.AspNetCore.Http.Features;
using Tabela;
using Tabela.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Konfiguracja limitu rozmiaru pliku
//builder.Services.Configure<FormOptions>(options =>
//{
//    options.ValueLengthLimit = int.MaxValue;//20971520;  // Ustawienie limitu na 20 MB
//    options.MultipartBodyLengthLimit = int.MaxValue;//20971520;  // Limit na wielkoœæ pliku w ¿¹daniu
//});

// Dodatkowa konfiguracja serwera Kestrel (opcjonalnie)
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.Limits.MaxRequestBodySize = int.MaxValue;  // Ustawienie limitu na 20 MB
//});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
