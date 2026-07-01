using GarageAI.Web.Components;
using GarageAI.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<CustomerApiService>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(
        configuration["ApiSettings:BaseUrl"]!);
});

builder.Services.AddHttpClient<VehicleApiService>((sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

builder.Services.AddHttpClient<BookingApiService>((sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

builder.Services.AddHttpClient<MechanicApiService>((sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

builder.Services.AddHttpClient<ServiceApiService>((sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});
builder.Services.AddHttpClient<ServicePackageApiService>((sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});


builder.Services.AddHttpClient<DashboardApiService>((sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

builder.Services.AddHttpClient<AIApiService>((sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
