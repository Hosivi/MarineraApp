using Domain.Entities;
using SharedKernel;

namespace Domain.Aggregates;
/// <summary>
/// Register of participants
/// </summary>
public class RegisterOffice:EntityBase
{
    public RegisterOffice(Concourse? concourse)
    {
        Concourse = concourse;
        ConcourseId = concourse.Id;
    }

    public RegisterOffice()
    {
    }

    public List<Modality> Modalities { get; set; }
    public Concourse? Concourse { get; set; }
    public Guid ConcourseId { get; set; }

}

public class Modality:EntityBase
{
    public string Name { get; set; }
    public List<Category> Categories { get; set;} 

}

public class Category:EntityBase
{
    public string Name { get; set; }
    public Modality Modality { get; set; }
    public List<ConcourseRule> ConcourseRules { get; set; }
}

public class ConcourseRule : EntityBase
{

}