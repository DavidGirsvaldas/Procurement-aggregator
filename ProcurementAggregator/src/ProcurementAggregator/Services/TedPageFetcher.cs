using System.Net.Http;

namespace ProcurementAggregator.Services;

public class TedPageFetcher
{
    private readonly HttpClient _httpClient;
    private const string Url = "https://ted.europa.eu/en/search/result?search-scope=ACTIVE&scope=ACTIVE&onlyLatestVersions=false&sortColumn=publication-number&sortOrder=DESC&page=1";

    public TedPageFetcher(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> FetchAsync(CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.GetAsync(Url, cancellationToken);
        response.EnsureSuccessStatusCode();
        var html = await response.Content.ReadAsStringAsync(cancellationToken);
        return html;
    }
}
