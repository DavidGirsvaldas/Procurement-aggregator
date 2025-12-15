using ProcurementAggregator.Models;

namespace ProcurementAggregator.Services;

public static class TedTenderMapper
{
    public static Tender ToTender(this TedSearchResponse.TedNotice notice)
    {
        var buyerName =
            notice.BuyerName?
                .FirstOrDefault(kvp => kvp.Value is { Length: > 0 })
                .Value?
                .FirstOrDefault();

        var linkEng =
            GetDictValue(notice.Links?.Pdf, "ENG")
            ?? GetDictValue(notice.Links?.Html, "ENG")
            ?? GetDictValue(notice.Links?.HtmlDirect, "ENG");

        return new Tender(
            PublicationDate: notice.PublicationDate,
            DeadlineReceiptRequest: notice.DeadlineReceiptRequest?.FirstOrDefault(),
            Title: GetDictValue(notice.NoticeTitle, "eng"),
            BuyerCountryLabel: notice.BuyerCountry?.FirstOrDefault()?.Label,
            Link: linkEng,
            BuyerName: buyerName
        );
    }

    private static string? GetDictValue(IReadOnlyDictionary<string, string>? dict, string key)
        => dict is not null && dict.TryGetValue(key, out var value) ? value : null;
}
