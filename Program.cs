using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlyAssetsFinal.Data;
using OnlyAssetsFinal.Data.Services;
using ustaTickets.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql")
    );
});

//Service Configuration
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<ICreatorService, CreatorService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

AppDbInitializer.Seed(app);

app.Run();
