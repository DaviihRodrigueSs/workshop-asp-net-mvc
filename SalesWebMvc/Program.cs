using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Globalization;
using SalesWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do DbContext com MySQL
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("SalesWebMvcContext"),
        new MySqlServerVersion(new Version(8, 0, 30)), 
        b => b.MigrationsAssembly("SalesWebMvc")));

// Registro do SeedingService no cont�iner de depend�ncias
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();

// Adicionando os servi�os MVC ao cont�iner
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��o de Cultura
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

app.UseRequestLocalization(localizationOptions);

// Cria��o de um escopo de servi�o para executar o seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seedingService = services.GetRequiredService<SeedingService>();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        seedingService.Seed(); // Certifique-se de que esse m�todo n�o seja ass�ncrono ou ajuste para usar await se for
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }
}

// Configura��o do pipeline de requisi��es HTTP
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
