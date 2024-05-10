using SinusWebShopLeutrim2;
using SinusWebShopLeutrim2.API;

var builder = WebApplication.CreateBuilder(args);

// Lägg till tjänster i containern.
builder.Services.AddRazorComponents().AddInteractiveServerComponents(); // Lägg till AddInteractiveServerComponents() för interaktiva komponenter

// Registrera DataFetcher som en scoped tjänst
builder.Services.AddScoped<DataFetcher>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://dummyjson.com/") });

var app = builder.Build();

// Konfigurera HTTP-requestpipelinen.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Lägg till Anti-forgery middleware0
app.UseAntiforgery();

// Lägg till Blazor-komponenter och konfigurera routning
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Lägg till renderläge här

// Kör applikationen
app.Run();
