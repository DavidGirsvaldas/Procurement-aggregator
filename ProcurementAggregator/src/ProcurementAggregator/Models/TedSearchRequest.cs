using System.Text.Json.Serialization;

namespace ProcurementAggregator.Models;

public record TedSearchRequest(
    [property: JsonPropertyName("query")] string Query,
    [property: JsonPropertyName("page")] int Page,
    [property: JsonPropertyName("limit")] int Limit,
    [property: JsonPropertyName("fields")] string[] Fields,
    [property: JsonPropertyName("validation")] bool Validation,
    [property: JsonPropertyName("scope")] string Scope,
    [property: JsonPropertyName("language")] string Language,
    [property: JsonPropertyName("onlyLatestVersions")] bool OnlyLatestVersions,
    [property: JsonPropertyName("facets")] TedFacets Facets
);