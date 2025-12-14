
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Transparent proxy endpoint: forwards request body to TED API and returns raw JSON
app.MapPost("/search", async (HttpRequest request, IHttpClientFactory httpClientFactory, CancellationToken ct) =>
{
    using var reader = new StreamReader(request.Body, Encoding.UTF8);
    var requestBody = await reader.ReadToEndAsync(ct);

    var client = httpClientFactory.CreateClient();
    using var content = new StringContent(requestBody ?? string.Empty, Encoding.UTF8, "application/json");
    using var response = await client.PostAsync("https://tedweb.api.ted.europa.eu/private-search/api/v1/notices/search", content, ct);
    var json = await response.Content.ReadAsStringAsync(ct);

    // Return raw JSON as a string (no extra handling)
    return Results.Text(json, "application/json");
});

app.Run();
