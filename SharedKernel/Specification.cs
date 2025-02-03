using System.Linq.Expressions;

namespace SharedKernel;

public class Specification<TEntity>                            
{
	public Specification()
	{
		
	}
    public Specification(ISpecificationBuilder<TEntity> specificationBuilder)
    {
        SpecificationBuilder = specificationBuilder;
    }

    public Specification(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }
    public List<Expression<Func<TEntity, bool>>> Filters { get; set; } = new();
    public ISpecificationBuilder<TEntity> SpecificationBuilder { get; }
    public Expression<Func<TEntity, bool>> Criteria { get; set; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new();                               
    public List<Expression<Func<TEntity, object>>> Excludes { get; } = new();
    public List<Expression<Func<TEntity, object>>> OrderBy { get; } = new();             
    public List<Expression<Func<TEntity, object>>> OrderByDesending { get; } = new();
}
public interface ISpecificationBuilder<TEntity>
{
    
}


