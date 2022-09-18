using App.Middlewares;
using ASP.NET_Core_Middleware.Data;
using ASP.NET_Core_Middleware.Lib.Interfaces;
using ASP.NET_Core_Middleware.Lib.Object;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

// Transient : ��û ���� ������ �����մϴ�.
builder.Services.AddTransient<IActionTransient, LifeTime>();
// Scoped : ��û �� �� �� �����մϴ�.
builder.Services.AddScoped<IActionScoped, LifeTime>();
// Singleton : ó�� ��û �޾� ������ �ν��Ͻ��� ��Ÿ���� ���� ������ ����մϴ�.
builder.Services.AddSingleton<IActionSingleton, LifeTime>();
builder.Services.AddSingleton<IActionSingletonInstance>(new LifeTime(Guid.Empty));

// DI : Dependency Injection
// ���Ӽ� ���� : ����(�������̽�) Ÿ������ ����(Ŭ����) Ÿ���� �����մϴ�.
builder.Services.AddTransient<IUser, UserList>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

app.UseMyCustomMiddleware();