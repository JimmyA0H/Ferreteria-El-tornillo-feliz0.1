
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// HttpClient para llamar a la API
builder.Services.AddHttpClient("FerreteriaApi", client =>
{
    // IMPORTANTE: Cambia la URL base si corres la API en otro puerto
    client.BaseAddress = new Uri(builder.Configuration["FerreteriaApiBaseUrl"] 
        ?? "https://localhost:7150/");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Herramientas}/{action=Index}/{id?}");

app.Run();
