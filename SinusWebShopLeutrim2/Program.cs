using SinusWebShopLeutrim2;
using SinusWebShopLeutrim2.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registrera DataFetcher som en scoped tj�nst
builder.Services.AddScoped<DataFetcher>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://dummyjson.com/") });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// L�gg till Blazor-komponenter och konfigurera routning
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


