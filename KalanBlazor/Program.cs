using CurrieTechnologies.Razor.SweetAlert2;
using KalanBlazor.BL.Compras;
using KalanBlazor.BL.Compras.Interfaces;
using KalanBlazor.BL.Financiero;
using KalanBlazor.BL.Financiero.Interfaces;
using KalanBlazor.Components;
using KalanBlazor.Data;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Kalan.Componentes;
using Shared.Kalan.Contextos;
using Shared.Utilerias.Excel;
using System.Globalization;
using Tewr.Blazor.FileReader;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();
builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<KalanDB>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddComponentesKalan();
builder.Services.AddScoped<LoadingService>();
builder.Services.AddFileReaderService();
builder.Services.AddScoped<IContabilidad, Contabilidad>();
builder.Services.AddScoped<ICompras, Compras>();
builder.Services.AddScoped<Excel>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddSignInManager().AddDefaultTokenProviders();
builder.Services.AddSweetAlert2();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddSignalR(e =>
{
    e.MaximumReceiveMessageSize = 102400000;
});
builder.Services.AddApplicationInsightsTelemetry();
var app = builder.Build();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseForwardedHeaders();
    app.UseHsts();
}
else
{
    //app.UseDeveloperExceptionPage();
    app.UseForwardedHeaders();
}
app.UseDeveloperExceptionPage();
app.MapRazorComponents<App>()
    .AllowAnonymous()
    .AddInteractiveServerRenderMode();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-MX");
app.Run();