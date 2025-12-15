namespace ProcurementAggregator.Models;

public sealed record Tender(
    string? PublicationDate,
    string? DeadlineReceiptRequest,
    string? Title,
    string? BuyerCountryLabel,
    string? Link,
    string? BuyerName
);
