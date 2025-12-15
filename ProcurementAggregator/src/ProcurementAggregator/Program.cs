using System.Text.Json;
using ProcurementAggregator.Models;
using ProcurementAggregator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ITedSearchService, TedSearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Transparent proxy endpoint: forwards a fixed request payload to TED API and returns raw JSON
app.MapGet("/search", async (ITedSearchService tedSearchService, CancellationToken ct) =>
{
    var json = await tedSearchService.SearchAsync(ct);

    var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
    {
        PropertyNameCaseInsensitive = true
    };

    var model = JsonSerializer.Deserialize<TedSearchResponse>(json, options);
    if (model is null)
        return Results.Problem("Failed to deserialize TED response.");

    // Return typed object (ASP.NET will serialize it back to JSON)
    return Results.Ok(model);
});

app.Run();