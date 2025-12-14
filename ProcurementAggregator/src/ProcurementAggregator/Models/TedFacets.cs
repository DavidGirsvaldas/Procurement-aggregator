using System.Text.Json.Serialization;

namespace ProcurementAggregator.Models;

public record TedFacets(
    [property: JsonPropertyName("business-opportunity")] string[] BusinessOpportunity,
    [property: JsonPropertyName("cpv")] string[] Cpv,
    [property: JsonPropertyName("contract-nature")] string[] ContractNature,
    [property: JsonPropertyName("place-of-performance")] string[] PlaceOfPerformance,
    [property: JsonPropertyName("procedure-type")] string[] ProcedureType,
    [property: JsonPropertyName("publication-date")] string[] PublicationDate,
    [property: JsonPropertyName("buyer-country")] string[] BuyerCountry
);