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

    public async Task<int> PostJobListyingAsync(JobListing listing)
    {
        var response = await _client.PostAsJsonAsync<JobListing>("jobs", listing);
        var id = await response.Content.ReadFromJsonAsync<int>();
        return id;
    }

    public async Task<List<JobListing>> SearchJobListingsAsync(string keyword)
    {
        var jobs = await _client.GetFromJsonAsync<List<JobListing>>($"jobs/{keyword}");

        return jobs;
    }
}
