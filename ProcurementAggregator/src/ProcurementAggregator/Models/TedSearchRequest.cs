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

public record TedFacets(
    [property: JsonPropertyName("business-opportunity")] string[] BusinessOpportunity,
    [property: JsonPropertyName("cpv")] string[] Cpv,
    [property: JsonPropertyName("contract-nature")] string[] ContractNature,
    [property: JsonPropertyName("place-of-performance")] string[] PlaceOfPerformance,
    [property: JsonPropertyName("procedure-type")] string[] ProcedureType,
    [property: JsonPropertyName("publication-date")] string[] PublicationDate,
    [property: JsonPropertyName("buyer-country")] string[] BuyerCountry
);