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

    // Return raw JSON as a string (no extra handling)
    return Results.Text(json, "application/json");
});

app.Run();