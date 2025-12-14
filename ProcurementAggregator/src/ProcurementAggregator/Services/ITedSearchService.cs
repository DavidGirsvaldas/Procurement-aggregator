namespace ProcurementAggregator.Services;

public interface ITedSearchService
{
    Task<string> SearchAsync(CancellationToken ct);
}