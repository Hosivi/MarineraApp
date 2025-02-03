namespace SharedKernel;

public abstract class EntityBase<TEntity>
{
    public TEntity? Id { get; set; }
    public DateTimeOffset CreationDate { get; protected set;  }= DateTimeOffset.UtcNow;
    public List<EventBase> Events = new(); 

}
public class EntityBase : EntityBase<Guid>
{
    public EntityBase()
    {
        Id = Guid.NewGuid();
    }
}
public class EventBase
{
}        