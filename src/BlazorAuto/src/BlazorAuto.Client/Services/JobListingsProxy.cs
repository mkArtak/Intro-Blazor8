using BlazorAuto.Shared;
using BlazorAuto.Shared.Services;
using System.Net.Http.Json;

namespace BlazorAuto.Client.Services;

public class JobListingsProxy : IJobListingsService
{
    private readonly HttpClient _client;

    public JobListingsProxy(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<JobListing>> GetActiveJobListingsAsync()
    {
        var jobs = await _client.GetFromJsonAsync<List<JobListing>>("jobs");

        return jobs;
    }

    public Task<int> PostJobListyingAsync(JobListing listing)
    {
        throw new NotImplementedException();
    }

    public Task<List<JobListing>> SearchJobListingsAsync(string keyword)
    {
        throw new NotImplementedException();
    }
}
