namespace BlazorAuto.Shared;

public class JobListing
{
    public int Id { get; set; }

    public DateTimeOffset DatePosted { get; set; }

    public bool IsActive { get; set; }

    public string Category { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
}
