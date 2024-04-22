using BlazorAuto.Components;
using BlazorAuto.Services;
using BlazorAuto.Shared;
using BlazorAuto.Shared.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSingleton<IJobListingsService, ListingsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapGet("/jobs", ([FromServices] IJobListingsService ls) => ls.GetActiveJobListingsAsync());
app.MapPost("/jobs", ([FromServices] IJobListingsService ls, JobListing listing) => ls.PostJobListyingAsync(listing));
app.MapGet("/jobs/{key}", ([FromServices] IJobListingsService ls, string key) => ls.SearchJobListingsAsync(key));

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorAuto.Client._Imports).Assembly);

app.Run();
