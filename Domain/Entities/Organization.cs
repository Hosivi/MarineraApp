using Domain.Aggregates;

using SharedKernel;

namespace Domain.Entities;

public class Organization:EntityBase
{
    public string? Name { get; set; }
    public  List<Concourse>  Concourses { get; set; }

}