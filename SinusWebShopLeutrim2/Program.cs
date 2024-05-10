using SinusWebShopLeutrim2;
using SinusWebShopLeutrim2.API;

var builder = WebApplication.CreateBuilder(args);

// L�gg till tj�nster i containern.
builder.Services.AddRazorComponents().AddInteractiveServerComponents(); // L�gg till AddInteractiveServerComponents() f�r interaktiva komponenter

// Registrera DataFetcher som en scoped tj�nst
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

// L�gg till Anti-forgery middleware0
app.UseAntiforgery();

// L�gg till Blazor-komponenter och konfigurera routning
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // L�gg till renderl�ge h�r

// K�r applikationen
app.Run();
