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
    x.Password.RequireUppercase = false; // Anlam� B�y�k Harf olmak zorunda de�il
    x.Password.RequiredLength = 8; // Anlam� �ifre uzunlu�u 8 olmal�
}).AddEntityFrameworkStores<Context>();

// Authorize i�in Yaz�lan k�s�m 
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
              .RequireAuthenticatedUser()
              .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

// Sayfada izinsiz giri� yap�lma olay�nda Logindeki index sayfas�na g�ndericez
// Mesela anasayfa da blog vs ye t�klasak dahi hata almicaz direkt login sayfas�na g�ndericez
builder.Services.AddMvc();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    {   // Eri�im Reddedildi�i Zaman Nereye Gidecek Onu belirlemek i�in
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

// E�er Hata ile kar��la��l�r ise Buraya y�nledirmesini sa�lad�k
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
