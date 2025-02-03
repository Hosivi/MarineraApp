using Domain.Entities;
using SharedKernel;

namespace Domain.Aggregates;
/// <summary>
/// Management of ticket sales
/// </summary>
public class TicketOffice : EntityBase
{
    public TicketOffice(Concourse? concourse)
    {
        Concourse = concourse;
        ConcourseId = concourse.Id;
    }

    public TicketOffice()
    {
    }

    public Concourse? Concourse { get; set; }
    public Guid ConcourseId { get; set; }
    public void SellTicket()
    {
        // Sell ticket
    }

    public void SellTickets()
    {

    }
    public void CancelTicket()
    {
        // Cancel ticket
    }
    public void ChangeTicket()
    {
        // Change ticket
    }
}