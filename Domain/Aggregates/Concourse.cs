using Domain.Entities;
using SharedKernel;

namespace Domain.Aggregates;

/// <summary>
/// Concourse of the organization
/// </summary>
public class Concourse : EntityBase
{

    public Concourse(string name, DateTime? date) 
    {
        Name = name;
        Date = date;
    }

    public void CreateTicketOffice(Concourse concourse)
    {
        TicketOffice = new TicketOffice(concourse);
    }
    public void CreateRegisterOffice(Concourse concourse)
    {
        RegisterOffice = new RegisterOffice(concourse);
    }
    public string Name { get; set; }
    /// <summary>
    /// Date of the concourse should be a list or object
    /// </summary>
    public DateTime? Date { get; set; }
    public string Description { get; set; }
    public Organization? Organization { get; set; }
    public Guid OrganizationId { get; set; }
    public string? PhoneNumber { get; set; }
    public TimeSpan? OpeningTime { get; set; }
    public TimeSpan? ClosingTime { get; set; }
    public string? AdressLine1 { get; set; }
    public string? AdressLine2 { get; set; }
    public string? District { get; set; }
    public TicketOffice? TicketOffice { get; set; }
    public RegisterOffice? RegisterOffice { get; set; }
    
    
}