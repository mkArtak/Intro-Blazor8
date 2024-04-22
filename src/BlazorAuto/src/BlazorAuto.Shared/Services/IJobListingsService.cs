namespace BlazorAuto.Shared.Services;

public interface IJobListingsService
{
    Task<int> PostJobListyingAsync(JobListing listing);

    Task<List<JobListing>> GetActiveJobListingsAsync();

    Task<List<JobListing>> SearchJobListingsAsync(string keyword);
}
