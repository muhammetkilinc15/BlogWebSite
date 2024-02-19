using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Concreate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireUppercase = false; // Anlamý Büyük Harf olmak zorunda deðil
    x.Password.RequiredLength = 8; // Anlamý Þifre uzunluðu 8 olmalý
}).AddEntityFrameworkStores<Context>();

// Authorize için Yazýlan kýsým 
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
              .RequireAuthenticatedUser()
              .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

// Sayfada izinsiz giriþ yapýlma olayýnda Logindeki index sayfasýna göndericez
// Mesela anasayfa da blog vs ye týklasak dahi hata almicaz direkt login sayfasýna göndericez
builder.Services.AddMvc();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    {   // Eriþim Reddedildiði Zaman Nereye Gidecek Onu belirlemek için
        x.LoginPath = "/Login/Index";
    });

builder.Services.ConfigureApplicationCookie(x =>
{
    x.Cookie.HttpOnly = true;
    x.ExpireTimeSpan = TimeSpan.FromSeconds(10);
    x.LoginPath = "/login/Index";
    x.AccessDeniedPath = new PathString("/Login/AccessDenied/");
    x.SlidingExpiration = true;
});
// Session Ekledik
builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Eðer Hata ile karþýlaþýlýr ise Buraya yönledirmesini saðladýk
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

// Authontication kullan dedik :D 
app.UseAuthentication();

// Session Kullan dedik
app.UseSession();
app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    _ = endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"

    );

});




app.Run();
