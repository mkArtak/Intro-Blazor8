using BlazorAuto.Shared;
using BlazorAuto.Shared.Services;

namespace BlazorAuto.Services;

public class ListingsService : IJobListingsService
{
    private static List<JobListing> allListings = new List<JobListing>
    {
        CreateJobListing(0, "Software Engineer", "IT", "Develop and optimize code across platforms, ensuring robust and scalable applications."),
        CreateJobListing(1, "Software Engineer", "IT", "Engineer software solutions from concept to deployment, focusing on performance and security."),
        CreateJobListing(2, "Software Engineer", "IT", "Collaborate in agile teams to design, test, and iterate on enterprise-level software."),
        CreateJobListing(3, "Senior Software Engineer", "IT", "Integrate systems and APIs, improve software architecture, and support deployment processes."),
        CreateJobListing(4, "Senior Software Engineer", "IT", "Build front-end and back-end systems for real-time data processing and analytics."),
        CreateJobListing(5, "Software Program Manager", "IT", "Oversee product lifecycle, define vision, and align teams to strategic goals."),
        CreateJobListing(6, "Senior Software Program Manager", "IT", "Lead cross-functional teams to launch products that meet market and user needs."),
        CreateJobListing(7, "Software Program Manager", "IT", "Analyze market trends to position products competitively and drive innovation."),
        CreateJobListing(8, "Software Program Manager", "IT", "Manage product roadmaps, prioritize features, and ensure timely delivery."),
        CreateJobListing(9, "Software Program Manager", "IT", "Coordinate with stakeholders to refine product offerings and improve user satisfaction."),
    };

    public Task<List<JobListing>> GetActiveJobListingsAsync() => Task.FromResult(allListings);

    public Task<int> PostJobListyingAsync(JobListing listing)
    {
        listing.DatePosted = DateTime.UtcNow;
        listing.Id = allListings.Count;
        allListings.Add(listing);
        return Task.FromResult(listing.Id);
    }

    public Task<List<JobListing>> SearchJobListingsAsync(string keyword)
    {
        return Task.FromResult(allListings.Where(listing => listing.Title.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)).ToList());
    }

    private static JobListing CreateJobListing(int id, string title, string category, string description)
        => new JobListing
        {
            Id = id,
            IsActive = true,
            DatePosted = DateTimeOffset.UtcNow,
            Category = category,
            Title = title,
            Description = description
        };
}
