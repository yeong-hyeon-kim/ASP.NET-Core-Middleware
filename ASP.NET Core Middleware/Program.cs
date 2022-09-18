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

// Transient : 요청 받을 때마다 생성합니다.
builder.Services.AddTransient<IActionTransient, LifeTime>();
// Scoped : 요청 당 한 번 생성합니다.
builder.Services.AddScoped<IActionScoped, LifeTime>();
// Singleton : 처음 요청 받아 생성된 인스턴스를 런타임이 끝날 때까지 사용합니다.
builder.Services.AddSingleton<IActionSingleton, LifeTime>();
builder.Services.AddSingleton<IActionSingletonInstance>(new LifeTime(Guid.Empty));

// DI : Dependency Injection
// 종속성 주입 : 상위(인터페이스) 타입으로 하위(클래스) 타입을 생성합니다.
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