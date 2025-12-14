using System.Text;
using System.Text.Json;
using ProcurementAggregator.Models;

namespace ProcurementAggregator.Services;

public sealed class TedSearchService : ITedSearchService
{
    private const string TedSearchUrl =
        "https://tedweb.api.ted.europa.eu/private-search/api/v1/notices/search";

    private readonly IHttpClientFactory _httpClientFactory;

    public TedSearchService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> SearchAsync(CancellationToken ct)
    {
        var tedRequest = new TedSearchRequest(
            Query: "OJ = ()  SORT BY publication-number DESC",
            Page: 1,
            Limit: 50,
            Fields: new[]
            {
                "publication-number",
                "BT-5141-Procedure",
                "BT-5141-Part",
                "BT-5141-Lot",
                "BT-5071-Procedure",
                "BT-5071-Part",
                "BT-5071-Lot",
                "BT-727-Procedure",
                "BT-727-Part",
                "BT-727-Lot",
                "place-of-performance",
                "procedure-type",
                "contract-nature",
                "buyer-name",
                "buyer-country",
                "publication-date",
                "deadline-receipt-request",
                "notice-title",
                "official-language",
                "notice-type",
                "change-notice-version-identifier"
            },
            Validation: false,
            Scope: "ACTIVE",
            Language: "EN",
            OnlyLatestVersions: false,
            Facets: new TedFacets(
                BusinessOpportunity: Array.Empty<string>(),
                Cpv: Array.Empty<string>(),
                ContractNature: Array.Empty<string>(),
                PlaceOfPerformance: Array.Empty<string>(),
                ProcedureType: Array.Empty<string>(),
                PublicationDate: Array.Empty<string>(),
                BuyerCountry: Array.Empty<string>()
            )
        );

        var requestJson = JsonSerializer.Serialize(tedRequest);

        var client = _httpClientFactory.CreateClient();
        using var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
        using var response = await client.PostAsync(TedSearchUrl, content, ct);

        return await response.Content.ReadAsStringAsync(ct);
    }
}