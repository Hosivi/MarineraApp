using SharedKernel;

namespace SharedEntities.DTOs;

public class ConcourseDto:EntityBase
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public Guid OrganizationId { get; set; }
    public string? PhoneNumber { get; set; }
    public TimeSpan? OpeningTime { get; set; }
    public TimeSpan? ClosingTime { get; set; }
    public string? AdressLine1 { get; set; }
    public string? AdressLine2 { get; set; }
    public string? District { get; set; }

}



