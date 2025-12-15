using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProcurementAggregator.Models;

public sealed record TedSearchResponse(
    [property: JsonPropertyName("notices")] IReadOnlyList<TedSearchResponse.TedNotice> Notices,
    [property: JsonPropertyName("facets")] TedSearchResponse.TedFacetsResponse? Facets,
    [property: JsonPropertyName("highlightedNotices")] JsonElement? HighlightedNotices,
    [property: JsonPropertyName("searchTerms")] IReadOnlyList<string>? SearchTerms,
    [property: JsonPropertyName("timedOut")] bool TimedOut
)
{
    // Keeps any unexpected top-level properties (so we don't lose data if API adds fields)
    [JsonExtensionData] public Dictionary<string, JsonElement>? AdditionalProperties { get; init; }

    public sealed record TedNotice
    {
        [JsonPropertyName("publication-number")] public string? PublicationNumber { get; init; }
        [JsonPropertyName("publication-date")] public string? PublicationDate { get; init; }

        [JsonPropertyName("notice-type")] public ValueLabel? NoticeType { get; init; }
        [JsonPropertyName("procedure-type")] public ValueLabel? ProcedureType { get; init; }

        [JsonPropertyName("place-of-performance")] public IReadOnlyList<ValueLabel>? PlaceOfPerformance { get; init; }
        [JsonPropertyName("buyer-country")] public IReadOnlyList<ValueLabel>? BuyerCountry { get; init; }
        [JsonPropertyName("official-language")] public IReadOnlyList<ValueLabel>? OfficialLanguage { get; init; }
        [JsonPropertyName("contract-nature")] public IReadOnlyList<ValueLabel>? ContractNature { get; init; }

        [JsonPropertyName("deadline-receipt-request")] public IReadOnlyList<string>? DeadlineReceiptRequest { get; init; }

        [JsonPropertyName("BT-5141-Procedure")] public IReadOnlyList<ValueLabel>? Bt5141Procedure { get; init; }
        [JsonPropertyName("BT-5141-Part")] public IReadOnlyList<ValueLabel>? Bt5141Part { get; init; }
        [JsonPropertyName("BT-5141-Lot")] public IReadOnlyList<ValueLabel>? Bt5141Lot { get; init; }

        [JsonPropertyName("BT-5071-Procedure")] public IReadOnlyList<ValueLabel>? Bt5071Procedure { get; init; }
        [JsonPropertyName("BT-5071-Part")] public IReadOnlyList<ValueLabel>? Bt5071Part { get; init; }
        [JsonPropertyName("BT-5071-Lot")] public IReadOnlyList<ValueLabel>? Bt5071Lot { get; init; }

        [JsonPropertyName("BT-727-Procedure")] public IReadOnlyList<ValueLabel>? Bt727Procedure { get; init; }
        [JsonPropertyName("BT-727-Part")] public IReadOnlyList<ValueLabel>? Bt727Part { get; init; }
        [JsonPropertyName("BT-727-Lot")] public IReadOnlyList<ValueLabel>? Bt727Lot { get; init; }

        [JsonPropertyName("buyer-name")] public Dictionary<string, string[]>? BuyerName { get; init; }
        [JsonPropertyName("notice-title")] public Dictionary<string, string>? NoticeTitle { get; init; }

        [JsonPropertyName("change-notice-version-identifier")] public string? ChangeNoticeVersionIdentifier { get; init; }

        [JsonPropertyName("links")] public Links? Links { get; init; }

        // Keeps any unexpected notice properties (so we still "fully" deserialize the payload)
        [JsonExtensionData] public Dictionary<string, JsonElement>? AdditionalProperties { get; init; }
    }

    public sealed record ValueLabel(
        [property: JsonPropertyName("value")] string Value,
        [property: JsonPropertyName("label")] string Label
    );

    public sealed record Links
    {
        [JsonPropertyName("xml")] public Dictionary<string, string>? Xml { get; init; }
        [JsonPropertyName("pdf")] public Dictionary<string, string>? Pdf { get; init; }
        [JsonPropertyName("pdfs")] public Dictionary<string, string>? Pdfs { get; init; }
        [JsonPropertyName("html")] public Dictionary<string, string>? Html { get; init; }
        [JsonPropertyName("htmlDirect")] public Dictionary<string, string>? HtmlDirect { get; init; }

        [JsonExtensionData] public Dictionary<string, JsonElement>? AdditionalProperties { get; init; }
    }

    public sealed record TedFacetsResponse
    {
        [JsonPropertyName("contract-nature")] public IReadOnlyList<FacetItem>? ContractNature { get; init; }
        [JsonPropertyName("procedure-type")] public IReadOnlyList<FacetItem>? ProcedureType { get; init; }
        [JsonPropertyName("place-of-performance")] public IReadOnlyList<FacetItem>? PlaceOfPerformance { get; init; }
        [JsonPropertyName("cpv")] public IReadOnlyList<FacetItem>? Cpv { get; init; }
        [JsonPropertyName("publication-date")] public IReadOnlyList<FacetItem>? PublicationDate { get; init; }
        [JsonPropertyName("buyer-country")] public IReadOnlyList<FacetItem>? BuyerCountry { get; init; }
        [JsonPropertyName("business-opportunity")] public IReadOnlyList<FacetItem>? BusinessOpportunity { get; init; }

        [JsonExtensionData] public Dictionary<string, JsonElement>? AdditionalProperties { get; init; }
    }

    public sealed record FacetItem
    {
        [JsonPropertyName("value")] public string? Value { get; init; }
        [JsonPropertyName("label")] public string? Label { get; init; }
        [JsonPropertyName("count")] public int? Count { get; init; }

        [JsonExtensionData] public Dictionary<string, JsonElement>? AdditionalProperties { get; init; }
    }
}
